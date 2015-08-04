module Sequence

let countToTen = seq { 1..10 }
let countToTenLength = countToTen |> Seq.length


let alphabets = seq { 'a'..'z' }

alphabets |> Seq.exists (fun c -> c = 'x') 


//#time
let nationalDebt = seq { 1I .. 18000000000000I };;
//#time
//#time
let myShare = Seq.truncate 186233 nationalDebt
//#time
//#time
myShare |> Seq.toList |> List.length
//#time
//#time

//let nationalDebt = seq { 1I .. 18000000000000I };;
//nationalDebt |> Seq.length
//printfn "Hello World"
