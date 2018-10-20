namespace Cellular

open Cellular.Types

module Rules =
    let Rule110 (cells: Cell * Cell * Cell) =
        match cells with
        | X,X,X -> O
        | X,X,O -> X
        | X,O,X -> X
        | X,O,O -> O
        | O,X,X -> X
        | O,X,O -> X
        | O,O,X -> X
        | O,O,O -> O

    let namedRule (name: int32) (cells: Cell * Cell * Cell) =
        let isSet c =
            match name &&& c with
            | 0 -> O
            | _ -> X

        match cells with
        | X,X,X -> isSet 128
        | X,X,O -> isSet 64
        | X,O,X -> isSet 32
        | X,O,O -> isSet 16
        | O,X,X -> isSet 8
        | O,X,O -> isSet 4
        | O,O,X -> isSet 2
        | O,O,O -> isSet 1
        

