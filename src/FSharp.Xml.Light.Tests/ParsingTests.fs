namespace FSharp.Xml.Light.Tests

open Xunit

module ParsingTests =

    open FSharp.Xml.Light
    open FSharp.Xml.Light.Parser

    [<Fact>]
    let ``Parses example xml`` () =
        let { Name = name; Children = children } =
            Parser.parse Fixtures.xml

        Assert.Equal("catalog", name)
        Assert.Equal(12, children |> List.length)

        children
        |> List.iter (fun book ->
            match book with
            | Node { Attributes = [ (name, _) ] } -> Assert.Equal("id", name)
            | _ -> failwith "Unexpected content")
