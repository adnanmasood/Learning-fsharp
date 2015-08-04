module Factorial

//Iterative
let factorialIterative x = 
    let mutable n = x
    let mutable returnVal = 1
    while n >= 1 do
        returnVal <- returnVal * n
        n <- (n - 1)
    returnVal

//Recursive
let rec factorial n =
    if n < 1 then 1
    else n * factorial  (n - 1)

let rec factorial_PatternMatching n =
    match n with
    | 0 | 1 -> 1
    | _ -> n * factorial_PatternMatching(n-1)

//Tail Recursive 
let factorial_TailRecursive n =    
    let rec tailRecFact n accum =
        if n <= 1 then 
            accum
        else 
            tailRecFact (n - 1) (accum * n)
    tailRecFact n 1

    
// Continutaion based factorial
let factorial_continuation n =
    let rec contTailRecFact n f =
        if n <= 1 then
            f()
        else
            contTailRecFact (n - 1) (fun () -> n * f())    
    contTailRecFact n (fun () -> 1)

  
let factorial_fold n = [1..n] 
                    |> List.fold (*) 1
                    
let factorial_reduce n = [1..n] 
                      |> List.reduce (*)
