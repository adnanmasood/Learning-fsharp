module Stacks

type Stack<'T>() =  
    let mutable _stack : List<'T> = []

    member this.Push value =
      _stack <- value :: _stack

    member this.Pop =
      match _stack with
      | result :: remainder ->
         _stack <- remainder
         result
      | [] -> failwith "Stack is Empty"

     member this.TryPop =
      match _stack with
      | result :: remainder ->
         _stack <- remainder
         result |> Some
      | [] -> None
 
let PickProgrammingParadigm (x : int) =
   match x with
   | 1 -> "Imperative"
   | 2 -> "Procedural"
   | 3 -> "Declarative"
   | 4 -> "Functional"
   | 5 -> "Object Oriented"
   | 6 -> "Event Driven"
   | 7 -> "Automata Based"
   | _ -> x.ToString()


let MatchArray arr =
   match arr with
   | [||] -> "An Empty Array"
   | [|x|] -> sprintf "Single Value: %A" x
   | [|x;y|] -> sprintf "A Pair: %A and %A" x y
   | _ -> sprintf ">2 Array"


let MatchList list =
   match list with
   | [] -> "An Empty List"
   | head::tail -> sprintf "List %A has %i more elements" head (tail.Length)



let isBalanced str = 
    let rec loop xs stack = 
        match (xs, stack) with
        | '(' :: ys,  stack -> loop ys ('(' :: stack)
        | ')' :: ys, '(' :: stack -> loop ys stack
        | ')' :: _, _ -> false
        | _ :: ys, stack -> loop ys stack
        | [], [] -> true
        | [], _ -> false
    loop (Seq.toList str) []