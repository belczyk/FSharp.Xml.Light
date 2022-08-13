module FSharp.Xml.Light.XmlParser


open System.Collections.Generic
open FSharp.Text.Lexing
open FSharp.Xml.Light.Lexer
open Printf

type XML =
    | Element of (string * (string * string) list * XML list)
    | PCData of string

type ParsingError =
    | UnterminatedComment
    | UnterminatedString
    | UnterminatedEntity
    | IdentExpected
    | CloseExpected
    | NodeExpected
    | AttributeNameExpected
    | AttributeValueExpected
    | EndOfTagExpected of string
    | EOFExpected
    
type ParsingErrorDetails = {
    Error : ParsingError
    
}
    with static member create (error: ParsingError) =
        {
            Error = error
        }

exception XMLParsingException of ParsingErrorDetails


let lexingErrorToParsingError (error : LexingError) =
    match error with
    | ECloseExpected -> CloseExpected
    | EIdentExpected -> IdentExpected
    | ENodeExpected -> NodeExpected
    | EUnterminatedComment -> UnterminatedComment
    | EUnterminatedEntity -> UnterminatedEntity
    | EUnterminatedString -> UnterminatedString
    | EAttributeNameExpected -> AttributeNameExpected
    | EAttributeValueExpected -> AttributeValueExpected

type State =
    { Source: LexBuffer<char>
      Stack: Stack<Lexer.token>
      Original : string  }

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
        raise (XMLParsingException (ParsingErrorDetails.create(NodeExpected)))

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
        | None -> raise (XMLParsingException (ParsingErrorDetails.create EOFExpected))
        | Some s -> raise (XMLParsingException(ParsingErrorDetails.create (EndOfTagExpected s)))

let parse xmlStr =
    read_node
        { Stack = Stack<Lexer.token>()
          Source = LexBuffer<char>.FromString xmlStr
          Original = xmlStr
          }
