module Fibonacci

open System.Collections.Generic

let rec fibonacci n =
       if n <= 2 then 1
       else fibonacci (n - 1) + fibonacci (n - 2)


let fibonacci_TailRecursive n = 
    let rec fibonacciX (n, x, y) =
       if (n = 0I) then x
       else fibonacciX ((n - 1I), y, (x + y))
    fibonacciX (n, 0I, 1I)


 
let rec fibonacci_Generic  n =
    let cache = Dictionary<_, _>()
    let rec fibonacciX = function 
        | n when n = 0I -> 0I
        | n when n = 1I -> 1I
        | n -> fibonacciX (n - 1I) + fibonacciX  (n - 2I)
    if cache.ContainsKey(n) then cache.[n]
    else
       let result = fibonacciX n
       cache.[n] <- result
       result

 
