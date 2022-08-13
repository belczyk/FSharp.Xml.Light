namespace FSharp.Xml.Light

module Buffer =

    open System.Text

    let create (capacity: int) = StringBuilder(capacity)
    let reset (builder : StringBuilder) = builder.Clear() |> ignore

    let add_string (builder: StringBuilder) (str: string) = builder.Append(str) |> ignore

    let contents builder = builder.ToString()

    let add_char (builder: StringBuilder) (c: char) = builder.Append(c) |> ignore
