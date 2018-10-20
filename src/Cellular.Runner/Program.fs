open System
open Cellular.Types
open Cellular.Rules

[<EntryPoint>]
let main argv =
    let exitWithMessage message =
        printfn message
        Environment.Exit(0)

    match argv.Length with
    | 0 -> exitWithMessage "Parameters are not supplied"
    | 1 -> exitWithMessage "Iterations not supplied"
    | _ ->
        match argv.[0] |> Int32.TryParse with
        | false,_ -> 
            exitWithMessage "Rule name isn't a number"
        | true, name -> 
            match argv.[1] |> Int32.TryParse with
            | false,_ -> exitWithMessage "Iterations isn't a number"
            | true, iterations ->
                let rule = namedRule name
                let mutable state = Row.Initialize 76
                state.Print()

                for _ in 1..iterations do
                    state <- state.Evolve rule
                    state.Print()

    if Diagnostics.Debugger.IsAttached then
        Console.ReadKey() |> ignore
    0 

