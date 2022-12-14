// Implementation file for parser generated by fsyacc
module FSharp.Xml.Light.DtdParser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "DtdParser.fsy"


open FSharp.Xml.Light


# 12 "DtdParser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | END
  | OPEN
  | CLOSE
  | STAR
  | QUESTION
  | PLUS
  | PCDATA
  | IDENT of (string)
  | NEXT
  | OR
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_END
    | TOKEN_OPEN
    | TOKEN_CLOSE
    | TOKEN_STAR
    | TOKEN_QUESTION
    | TOKEN_PLUS
    | TOKEN_PCDATA
    | TOKEN_IDENT
    | TOKEN_NEXT
    | TOKEN_OR
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startdtd_element
    | NONTERM_dtd_element
    | NONTERM_dtd_full_seq
    | NONTERM_dtd_seq
    | NONTERM_dtd_children
    | NONTERM_dtd_choice
    | NONTERM_dtd_item
    | NONTERM_dtd_member
    | NONTERM_dtd_op
    | NONTERM_dtd_op_item

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | END  -> 0 
  | OPEN  -> 1 
  | CLOSE  -> 2 
  | STAR  -> 3 
  | QUESTION  -> 4 
  | PLUS  -> 5 
  | PCDATA  -> 6 
  | IDENT _ -> 7 
  | NEXT  -> 8 
  | OR  -> 9 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_END 
  | 1 -> TOKEN_OPEN 
  | 2 -> TOKEN_CLOSE 
  | 3 -> TOKEN_STAR 
  | 4 -> TOKEN_QUESTION 
  | 5 -> TOKEN_PLUS 
  | 6 -> TOKEN_PCDATA 
  | 7 -> TOKEN_IDENT 
  | 8 -> TOKEN_NEXT 
  | 9 -> TOKEN_OR 
  | 12 -> TOKEN_end_of_input
  | 10 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startdtd_element 
    | 1 -> NONTERM_dtd_element 
    | 2 -> NONTERM_dtd_full_seq 
    | 3 -> NONTERM_dtd_full_seq 
    | 4 -> NONTERM_dtd_seq 
    | 5 -> NONTERM_dtd_seq 
    | 6 -> NONTERM_dtd_seq 
    | 7 -> NONTERM_dtd_children 
    | 8 -> NONTERM_dtd_children 
    | 9 -> NONTERM_dtd_choice 
    | 10 -> NONTERM_dtd_choice 
    | 11 -> NONTERM_dtd_item 
    | 12 -> NONTERM_dtd_item 
    | 13 -> NONTERM_dtd_member 
    | 14 -> NONTERM_dtd_member 
    | 15 -> NONTERM_dtd_member 
    | 16 -> NONTERM_dtd_member 
    | 17 -> NONTERM_dtd_op 
    | 18 -> NONTERM_dtd_op 
    | 19 -> NONTERM_dtd_op_item 
    | 20 -> NONTERM_dtd_op_item 
    | 21 -> NONTERM_dtd_op_item 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 12 
let _fsyacc_tagOfErrorTerminal = 10

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | END  -> "END" 
  | OPEN  -> "OPEN" 
  | CLOSE  -> "CLOSE" 
  | STAR  -> "STAR" 
  | QUESTION  -> "QUESTION" 
  | PLUS  -> "PLUS" 
  | PCDATA  -> "PCDATA" 
  | IDENT _ -> "IDENT" 
  | NEXT  -> "NEXT" 
  | OR  -> "OR" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | END  -> (null : System.Object) 
  | OPEN  -> (null : System.Object) 
  | CLOSE  -> (null : System.Object) 
  | STAR  -> (null : System.Object) 
  | QUESTION  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | PCDATA  -> (null : System.Object) 
  | IDENT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NEXT  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 2us; 65535us; 0us; 2us; 18us; 19us; 2us; 65535us; 0us; 4us; 18us; 4us; 2us; 65535us; 8us; 9us; 13us; 14us; 2us; 65535us; 10us; 11us; 16us; 17us; 6us; 65535us; 0us; 7us; 8us; 12us; 10us; 15us; 13us; 12us; 16us; 15us; 18us; 7us; 6us; 65535us; 0us; 20us; 8us; 20us; 10us; 20us; 13us; 20us; 16us; 20us; 18us; 20us; 4us; 65535us; 5us; 6us; 21us; 22us; 23us; 24us; 25us; 26us; 4us; 65535us; 5us; 25us; 21us; 25us; 23us; 25us; 25us; 25us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 6us; 9us; 12us; 15us; 22us; 29us; 34us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 1us; 2us; 2us; 3us; 2us; 2us; 3us; 1us; 2us; 3us; 4us; 5us; 6us; 1us; 4us; 1us; 4us; 1us; 5us; 1us; 5us; 2us; 7us; 8us; 1us; 7us; 1us; 7us; 2us; 9us; 10us; 1us; 9us; 1us; 9us; 1us; 11us; 1us; 11us; 1us; 12us; 2us; 13us; 15us; 1us; 13us; 2us; 14us; 16us; 1us; 14us; 2us; 17us; 18us; 1us; 17us; 1us; 19us; 1us; 20us; 1us; 21us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 11us; 14us; 16us; 20us; 22us; 24us; 26us; 28us; 31us; 33us; 35us; 38us; 40us; 42us; 44us; 46us; 48us; 51us; 53us; 56us; 58us; 61us; 63us; 65us; 67us; |]
let _fsyacc_action_rows = 30
let _fsyacc_actionTableElements = [|3us; 32768us; 1us; 18us; 6us; 23us; 7us; 21us; 0us; 49152us; 1us; 32768us; 0us; 3us; 0us; 16385us; 1us; 32768us; 2us; 5us; 3us; 16387us; 3us; 27us; 4us; 28us; 5us; 29us; 0us; 16386us; 2us; 16390us; 8us; 8us; 9us; 10us; 3us; 32768us; 1us; 18us; 6us; 23us; 7us; 21us; 0us; 16388us; 3us; 32768us; 1us; 18us; 6us; 23us; 7us; 21us; 0us; 16389us; 1us; 16392us; 8us; 13us; 3us; 32768us; 1us; 18us; 6us; 23us; 7us; 21us; 0us; 16391us; 1us; 16394us; 9us; 16us; 3us; 32768us; 1us; 18us; 6us; 23us; 7us; 21us; 0us; 16393us; 3us; 32768us; 1us; 18us; 6us; 23us; 7us; 21us; 0us; 16395us; 0us; 16396us; 3us; 16399us; 3us; 27us; 4us; 28us; 5us; 29us; 0us; 16397us; 3us; 16400us; 3us; 27us; 4us; 28us; 5us; 29us; 0us; 16398us; 3us; 16402us; 3us; 27us; 4us; 28us; 5us; 29us; 0us; 16401us; 0us; 16403us; 0us; 16404us; 0us; 16405us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 4us; 5us; 7us; 8us; 10us; 14us; 15us; 18us; 22us; 23us; 27us; 28us; 30us; 34us; 35us; 37us; 41us; 42us; 46us; 47us; 48us; 52us; 53us; 57us; 58us; 62us; 63us; 64us; 65us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 3us; 2us; 3us; 3us; 1us; 3us; 1us; 3us; 1us; 2us; 1us; 2us; 2us; 1us; 1us; 2us; 1us; 1us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; 6us; 6us; 7us; 7us; 7us; 7us; 8us; 8us; 9us; 9us; 9us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 16386us; 65535us; 65535us; 16388us; 65535us; 16389us; 65535us; 65535us; 16391us; 65535us; 65535us; 16393us; 65535us; 16395us; 16396us; 65535us; 16397us; 65535us; 16398us; 65535us; 16401us; 16403us; 16404us; 16405us; |]
let _fsyacc_reductions ()  =    [| 
# 151 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Dtd.dtd_child in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startdtd_element));
# 160 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_full_seq in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 21 "DtdParser.fsy"
                               _1 
                   )
# 21 "DtdParser.fsy"
                 : Dtd.dtd_child));
# 171 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_seq in
            let _3 = parseState.GetInput(3) :?> 'gentype_dtd_op in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 25 "DtdParser.fsy"
                               _3 _1 
                   )
# 25 "DtdParser.fsy"
                 : 'gentype_dtd_full_seq));
# 183 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_seq in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 27 "DtdParser.fsy"
                               _1 
                   )
# 27 "DtdParser.fsy"
                 : 'gentype_dtd_full_seq));
# 194 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_item in
            let _3 = parseState.GetInput(3) :?> 'gentype_dtd_children in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 31 "DtdParser.fsy"
                               Dtd.DTDChildren (_1 :: _3) 
                   )
# 31 "DtdParser.fsy"
                 : 'gentype_dtd_seq));
# 206 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_item in
            let _3 = parseState.GetInput(3) :?> 'gentype_dtd_choice in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 33 "DtdParser.fsy"
                               Dtd.DTDChoice (_1 :: _3) 
                   )
# 33 "DtdParser.fsy"
                 : 'gentype_dtd_seq));
# 218 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_item in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "DtdParser.fsy"
                               _1 
                   )
# 35 "DtdParser.fsy"
                 : 'gentype_dtd_seq));
# 229 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_item in
            let _3 = parseState.GetInput(3) :?> 'gentype_dtd_children in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "DtdParser.fsy"
                               _1 :: _3 
                   )
# 39 "DtdParser.fsy"
                 : 'gentype_dtd_children));
# 241 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_item in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "DtdParser.fsy"
                               [_1] 
                   )
# 41 "DtdParser.fsy"
                 : 'gentype_dtd_children));
# 252 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_item in
            let _3 = parseState.GetInput(3) :?> 'gentype_dtd_choice in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "DtdParser.fsy"
                               _1 :: _3 
                   )
# 45 "DtdParser.fsy"
                 : 'gentype_dtd_choice));
# 264 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_item in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "DtdParser.fsy"
                               [_1] 
                   )
# 47 "DtdParser.fsy"
                 : 'gentype_dtd_choice));
# 275 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_dtd_full_seq in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "DtdParser.fsy"
                               _2 
                   )
# 51 "DtdParser.fsy"
                 : 'gentype_dtd_item));
# 286 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_member in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "DtdParser.fsy"
                               _1 
                   )
# 53 "DtdParser.fsy"
                 : 'gentype_dtd_item));
# 297 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _2 = parseState.GetInput(2) :?> 'gentype_dtd_op in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "DtdParser.fsy"
                               _2 (Dtd.DTDTag _1) 
                   )
# 57 "DtdParser.fsy"
                 : 'gentype_dtd_member));
# 309 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_dtd_op in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "DtdParser.fsy"
                               _2 Dtd.DTDPCData 
                   )
# 59 "DtdParser.fsy"
                 : 'gentype_dtd_member));
# 320 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "DtdParser.fsy"
                               Dtd.DTDTag _1 
                   )
# 61 "DtdParser.fsy"
                 : 'gentype_dtd_member));
# 331 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "DtdParser.fsy"
                               Dtd.DTDPCData 
                   )
# 63 "DtdParser.fsy"
                 : 'gentype_dtd_member));
# 341 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_op_item in
            let _2 = parseState.GetInput(2) :?> 'gentype_dtd_op in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "DtdParser.fsy"
                               (fun x -> _2 (_1 x)) 
                   )
# 67 "DtdParser.fsy"
                 : 'gentype_dtd_op));
# 353 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_dtd_op_item in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "DtdParser.fsy"
                               _1 
                   )
# 69 "DtdParser.fsy"
                 : 'gentype_dtd_op));
# 364 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "DtdParser.fsy"
                               (fun x -> Dtd.DTDZeroOrMore x) 
                   )
# 73 "DtdParser.fsy"
                 : 'gentype_dtd_op_item));
# 374 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "DtdParser.fsy"
                               (fun x -> Dtd.DTDOptional x) 
                   )
# 75 "DtdParser.fsy"
                 : 'gentype_dtd_op_item));
# 384 "DtdParser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "DtdParser.fsy"
                               (fun x -> Dtd.DTDOneOrMore x) 
                   )
# 77 "DtdParser.fsy"
                 : 'gentype_dtd_op_item));
|]
# 395 "DtdParser.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 13;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let dtd_element lexer lexbuf : Dtd.dtd_child =
    engine lexer lexbuf 0 :?> _
