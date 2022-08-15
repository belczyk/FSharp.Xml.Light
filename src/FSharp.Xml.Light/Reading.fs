namespace FSharp.Xml.Light

open FSharp.Xml.Light.Parser

module Reading =
    let private pathStr (path: string list) = path |> String.concat "."

    let filterPCData (children: XmlElement list) =
        children
        |> List.map (fun c ->
            match c with
            | PCData _ -> None
            | XmlElement.Node node -> Some node)
        |> List.choose id

    let rec tryFindNode (path: string list) (node: XmlNode) =
        match path with
        | [] -> Some node
        | childName :: path ->
            let child =
                node.Children
                |> filterPCData
                |> List.tryFind (fun n -> n.Name = childName)

            match child with
            | None -> None
            | Some c -> tryFindNode path c

    let findNode (path: string list) (node: XmlNode) =
        match tryFindNode path node with
        | Some result -> result
        | None -> failwith $"Expected to find node {path |> pathStr} but it was missing."

    let tryGetAttributeValue (name: AttributeName) (node: XmlNode) =
        node.Attributes
        |> List.tryFind (fun (attributeName, _) -> attributeName = name)
        |> Option.map (fun (_, value) -> value)

    let getAttributeValue (name : AttributeName) (node: XmlNode) =
        match tryGetAttributeValue name node with
        | Some v -> v
        | None -> failwith $"Expected to find attribute {name} but it was missing"