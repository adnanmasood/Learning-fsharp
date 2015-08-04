module Main

let Multiply x y = x * y

let x = 10
let result = lazy (x + 10)
printfn "%d" (result.Force())


let rec quickSort (data:int list) =
    match data with
    | [] -> []
    | [a] -> [a]
    | head::tail ->
        let l0 =
            tail
            |> List.filter ((<=) head)
        let l1 =
            tail
            |> List.filter ((>) head)
        quickSort(l0) @ [head] @ quickSort(l1)

let myval = quickSort [-2; -3; 4; -1; 0; 1; 5; 7; -2]

let rec qsort = function
    | [] -> []
    | x::xs -> let lt, ge = List.partition ((>) x) xs
               qsort lt @ x :: qsort ge
