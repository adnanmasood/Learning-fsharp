module Lists

let numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]


let yodaQuotesFragment1 = [" Must ";" Unlearn ";" What ";" You "]
 
let yodaQuotesFragment2 = "You "::yodaQuotesFragment1 

let yodaQuotesFragment3 = [yodaQuotesFragment1.[1].[3..7] + "ed"]

let yodaQuote = yodaQuotesFragment2 @ yodaQuotesFragment3

yodaQuote.IsEmpty;;
yodaQuote.Length;;
yodaQuote.Head;;
yodaQuote.Tail;;
yodaQuote.Item (1);;


let FirstNames = ["Walter "; "Skyler"; "Jesse"; "Hank"; "Saul" ]
let LastNames = ["White "; "White"; "Pinkman"; "Schrader"; "Goodman" ]

let BreakingBadCast = List.zip FirstNames LastNames

List.iter (fun x -> printfn "%s" x) FirstNames

[-100..0];;
[1..10..100];;
['A'..'Z'];;

[ for x in 1 .. 10 do
        yield (x * x * x) ];;
