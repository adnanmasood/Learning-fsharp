module Stacks

type public Stack<'T>() =  
    let mutable _stack : List<'T> = []

    member public this.Push value =
      _stack <- value :: _stack

    member public this.Pop =
      match _stack with
      | result :: remainder ->
         _stack <- remainder
         result
      | [] -> failwith "Stack is Empty"

    member public this.TryPop =
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




let BalanceExpression expr = 
    let rec balancer xs stack = 
        match (xs, stack) with
        | [], [] -> true
        | [], _ -> false
        | '(' :: ys,  stack -> balancer ys ('(' :: stack)
        | ')' :: ys, '(' :: stack -> balancer ys stack
        | ')' :: _, _ -> false
        | _ :: ys, stack -> balancer ys stack
    balancer (Seq.toList expr) []
