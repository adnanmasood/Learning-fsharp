module LazyEvaluation

let divide x =
    let inverse = 1.0 / x
    if x = 0.0 then
        printfn "Divide by 0 error." 
    else
        printfn "1/x is: %f" inverse
