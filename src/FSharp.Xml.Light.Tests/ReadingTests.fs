namespace FSharp.Xml.Light.Tests

open Xunit
open FSharp.Xml.Light.Parser
open FSharp.Xml.Light.Reading

module ReadingTests =

    [<Fact>]
    let ``findNode returns root node if path is empty list`` () =
        let root = parse Fixtures.xml

        let res = findNode [] root

        Assert.Equal(root, res)


    [<Fact>]
    let ``findNode returns first matched node`` () =
        let root = parse Fixtures.xml

        let res = findNode [ "book" ] root

        Assert.Equal("book", res.Name)
        Assert.Equal("bk101", snd res.Attributes.Head)


    [<Fact>]
    let ``findNode throws if can't find the node`` () =
        let root = parse Fixtures.xml

        Assert.Throws(fun () -> findNode [ "book"; "publisher" ] root |> ignore)
        |> ignore


    [<Fact>]
    let ``getAttribute returns attribute value`` () =
        let id =
            parse Fixtures.xml
            |> findNode [ "book"]
            |> getAttributeValue "id"
            
        Assert.Equal("bk101", id)
        