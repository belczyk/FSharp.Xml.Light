namespace FSharp.Xml.Light.Tests

open System
open Xunit
open Xunit.Abstractions
open FSharp.Xml.Light.Parser
type SnippetTests( output:  ITestOutputHelper  ) =
    
    
    [<Fact>]
    member this.``Generates snippet`` () =
        let snippet = generateSnippet  90 Fixtures.xml
        output.WriteLine snippet
    