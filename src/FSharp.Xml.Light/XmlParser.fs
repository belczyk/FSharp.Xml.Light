module FSharp.Xml.Light.XmlParser


open System.Collections.Generic
open FSharp.Text.Lexing
open Printf
open System.Text.RegularExpressions

type ElementName = string
type AttributeName = string
type AttributeValue = string
type ExpectedTag = string
type ActualTag = string


type State =
    { Source: LexBuffer<char>
      Stack: Stack<Lexer.token>
      Original: string }

type XMLElement =
    | Element of (ElementName * (AttributeName * AttributeValue) list * XMLElement list)
    | PCData of string

let getLineNumber (str: string) position =
    let lines =
        Regex.Matches(str, @"\n",RegexOptions.Singleline)
        |> Seq.mapi (fun i (m: Match) -> m.Index, i)
        
    lines
        |> Seq.filter (fun (pos, _) -> pos > position)
        |> Seq.head
        |> (fun (_, line) -> line+1)

let generateSnippet (position: int) (original: string) =
    let n =
        original.Substring(0, position).LastIndexOf("\n")

    let m =
        if position = original.Length then
            position
        else
            original.Substring(n + 1).IndexOf("\n")

    let snippetRaw =
        original.Substring(n + 1, m)

    let snippet =
        if snippetRaw.EndsWith("\r") then
            snippetRaw.Substring(0, snippetRaw.Length - 1)
        else
            snippetRaw

    let indicator =
        "^".PadLeft(position - n - 1, ' ')

    let lineNumber =
        getLineNumber original position

    let lineStr = lineNumber.ToString() + "|"

    let indicatorLineStr =
        "|".PadLeft(lineStr.Length, ' ')

    $"{lineStr}{snippet}\n{indicatorLineStr}{indicator}"
    + $" Line position: {position - n - 1}"


type ParsingError =
    | UnterminatedComment
    | UnterminatedString
    | UnterminatedEntity
    | IdentExpected
    | CloseExpected
    | NodeExpected
    | AttributeNameExpected
    | AttributeValueExpected
    | EndOfTagExpected of ExpectedTag * ActualTag
    | EOFExpected

type ParsingErrorDetails =
    { Error: ParsingError
      Position: int
      Snippet: string }


    static member create(error: ParsingError, position: int, original: string) =


        { Error = error
          Position = position
          Snippet = generateSnippet position original }

exception XMLParsingException of ParsingErrorDetails

let pop s =
    match s.Stack.TryPop() with
    | true, v -> v
    | _ -> Lexer.token s.Source

let push (t: Lexer.token) (s: State) = s.Stack.Push(t)

let rec read_node (s: State) =
    match pop s with
    | Lexer.PCData s -> PCData s
    | Lexer.Tag (tag, attr, true) -> Element(tag, attr, [])
    | Lexer.Tag (tag, attr, false) ->
        Element(
            tag,
            attr,
            read_elems
                (if tag = "" || tag = null then
                     None
                 else
                     Some tag)
                s
        )
    | t ->
        push t s

        raise (
            XMLParsingException(ParsingErrorDetails.create (NodeExpected, s.Source.StartPos.AbsoluteOffset, s.Original))
        )

and read_elems (tag: string option) s =
    let elems = ref [] in

    (try
        while true do
            match true, read_node s, !elems with
            | true, PCData c, (PCData c2) :: q -> elems.Value <- PCData(sprintf "%s\n%s" c2 c) :: q
            | _, x, l -> elems.Value <- x :: l
     with
     | Lexer.Error _ -> ())

    match pop s with
    | Lexer.Endtag s when Some s = tag -> List.rev !elems
    | Lexer.Eof when tag = None -> List.rev !elems
    | t ->
        match tag with
        | None ->
            raise (
                XMLParsingException(
                    ParsingErrorDetails.create (EOFExpected, s.Source.StartPos.AbsoluteOffset, s.Original)
                )
            )
        | Some actualTag ->
            raise (
                XMLParsingException(
                    ParsingErrorDetails.create (
                        (EndOfTagExpected($"%A{tag}", $"%A{Some actualTag}")),
                        s.Source.StartPos.AbsoluteOffset,
                        s.Original
                    )
                )
            )

let parse xmlStr =
    read_node
        { Stack = Stack<Lexer.token>()
          Source = LexBuffer<char>.FromString xmlStr
          Original = xmlStr }
