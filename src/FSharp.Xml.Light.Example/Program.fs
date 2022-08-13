
open FSharp.Text.Parsing
open FSharp.Text.Lexing
open FSharp.Xml.Light
open System.Diagnostics
open System.IO
open XmlParser
open Errors

// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let di = DirectoryInfo("./Examples")

let astrata = File.ReadAllText("./Examples/data2.xml")

try
   XmlParser.parse astrata |> printf "%A"
   
with
| ParsingError e ->
    System.Console.WriteLine(e.ToString())
| e ->
    System.Console.WriteLine(e.ToString())
        
// let sw = Stopwatch.StartNew()
//
//
// di.GetFiles()
// |> List.ofArray
// |> List.map (fun f ->
//     File.ReadAllText f.FullName, f.Name
//     )
//     
// |> List.map (fun (xml , name)->
//     try
//         Some (XmlParser.parse xml)
//         
//      with
//      | ParsingError e ->
//          System.Console.WriteLine(e.ToString())
//          System.Console.WriteLine(name)
//          None
//      | e ->
//          System.Console.WriteLine(e.ToString())
//          System.Console.WriteLine(name)
//          None 
//     )
// |> ignore
// sw.Stop()

System.Console.ReadLine() |> ignore

