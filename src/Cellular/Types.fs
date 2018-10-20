namespace Cellular

module Types =
    open System
    open System.Text
    open FSharp.Core.Printf

    type Cell =
    | O
    | X
        override x.ToString() =
            match x with
            | O -> "."
            | X -> "x"

    let randomCell (random: Random) _ =
        match random.Next(2) with
        | 0 -> O
        | 1 -> X
        | _ -> failwith "Maths is broken"

    type Rule = Cell * Cell * Cell -> Cell

    type Row = {
        State: Cell array
        Iteration: int64
    } with
        static member Initialize size =
            let r = Random()
            { 
                State = Array.init size (randomCell r)
                Iteration = 0L
            }

        member this.Evolve (rule: Rule) =
            let row = this.State
            let getNeighbours index (cell: Cell)=
                match index, row.Length with
                | _ when index = 0 ->
                    (row.[row.Length - 1], cell, row.[index + 1])
                | _ when index = (row.Length - 1) ->
                    (row.[index - 1], cell, row.[0])
                | _ -> 
                    (row.[index - 1], cell, row.[index + 1])
            {
                State = row |> Array.mapi (fun i c -> getNeighbours i c |> rule)
                Iteration = this.Iteration + 1L
            }

        member this.Print () =
            let buffer = StringBuilder(this.State.Length)
            this.State |> Array.iter (bprintf buffer "%O")
            Console.WriteLine buffer


    
