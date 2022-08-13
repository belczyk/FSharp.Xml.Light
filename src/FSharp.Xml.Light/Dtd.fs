module FSharp.Xml.Light.Dtd


type parse_error_msg =
    | InvalidDTDDecl
    | InvalidDTDElement
    | InvalidDTDAttribute
    | InvalidDTDTag
    | DTDItemExpected

type check_error =
    | ElementDefinedTwice of string
    | AttributeDefinedTwice of string * string
    | ElementEmptyConstructor of string
    | ElementReferenced of string * string
    | ElementNotDeclared of string
    | WrongImplicitValueForID of string * string

type prove_error =
    | UnexpectedPCData
    | UnexpectedTag of string
    | UnexpectedAttribute of string
    | InvalidAttributeValue of string
    | RequiredAttribute of string
    | ChildExpected of string
    | EmptyExpected
    | DuplicateID of string
    | MissingID of string

type dtd_child =
    | DTDTag of string
    | DTDPCData
    | DTDOptional of dtd_child
    | DTDZeroOrMore of dtd_child
    | DTDOneOrMore of dtd_child
    | DTDChoice of dtd_child list
    | DTDChildren of dtd_child list

type dtd_element_type =
    | DTDEmpty
    | DTDAny
    | DTDChild of dtd_child

type dtd_attr_default =
    | DTDDefault of string
    | DTDRequired
    | DTDImplied
    | DTDFixed of string

type dtd_attr_type =
    | DTDCData
    | DTDNMToken
    | DTDEnum of string list
    | DTDID
    | DTDIDRef

type dtd_item =
    | DTDAttribute of string * string * dtd_attr_type * dtd_attr_default
    | DTDElement of string * dtd_element_type

type dtd_result =
    | DTDNext
    | DTDNotMatched
    | DTDMatched
    | DTDMatchedResult of dtd_child

type error_pos = {
    eline : int;
    eline_start : int;
    emin : int;
    emax : int;
}

type parse_error = parse_error_msg * error_pos

exception Parse_error of parse_error
exception Check_error of check_error
exception Prove_error of prove_error

type dtd = dtd_item list