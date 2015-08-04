module Basics


let byte b = 10uy
let sbyte sb = -128y
let int16 i = -100s
let uint16 ui = 100us
let int life = -42
let uint lifehex = 0x42u
let int64 dist = 238900L
let uint64 dist = 2,660,000,000UL
let float pif = 3.14159265359
let double ed = 2.718281828459045
let float32 efl = 2.7182818
let decimal pi = 3.14159265358979323846264338
let bignum gogol = 10I ** 100

let string = "nà, méi guānxi"

let cubeMe x = x * x * x;;

let rec fib n =
   if n <= 2 then 1
   else fib (n - 1) + fib (n - 2)

let Mult x y = x * y ;;

let Mult_typed (x: float) (y: float) = x * y ;;

let areaOfCircle r = 
     let square r = r * r
     System.Math.PI * square r;;

let areaOfCircle_typed (r: float) = 
     let square r = r * r
     System.Math.PI * square r;;

let Mod10 n = 
   if n % 10 = 0 then
      printfn "Number ends in 0"
   else
      printfn "Number does not end in zero";;

let t = ("cats", "dogs", System.Math.PI, 42, "C#", "Java");;

let GuardiansOfGalaxy = [| "Peter Quill";"Gamora";"Drax";"Groot";"Rocket";"Ronan";"Yondu Udonta";"Nebula";"Korath"; "Corpsman Dey";"Nova Prime";"The Collector";"Meredith Quill" |];;

let iAmGroot = GuardiansOfGalaxy.[4];

let str = "Lǎo péngyǒu, nǐ kànqǐlái hěn yǒu jīngshén."
printfn "%c" str.[9]

let OneToHundred = [|1..100|];;

let TopThree = OneToHundred.[0..2];; 

let GOOG = 516.35;; 

let add x y = x + y;;

(add 10) 4;;

let Add10 = add 10; 

Add10 42

let increament n = n + 1
let divideByTwo n = n / 2

let InvokeThrice n (f:int->int) = f(f(f(n)))

let res = InvokeThrice 6 increament

let res_2 = InvokeThrice 80 divideByTwo

let InvokeThriceEx n (f:double->double) = f(f(f(n)))
let x = InvokeThriceEx 2.0 (fun n -> n ** 3.0) 
   

let nums = [|0..99|]

let squares = 
   nums
   |> Array.map (fun n -> n * n)

let sum = Array.fold(fun acc n ->  acc + n ) 0 squares   

let castNames = [| "Hofstadter"; "Cooper"; "Wolowitz"; "Koothrappali"; "Fowler"; "Rostenkowski";  |]
let longNames = Array.filter (fun (name: string) -> name.Length > 6) castNames


let firstNames = [| "Leonard"; "Sheldon"; "Howard"; "Penny"; "Raj"; "Bernadette"; "Amy" |]
let lastNames = [| "Hofstadter"; "Cooper"; "Wolowitz"; ""; "Koothrappali"; "Rostenkowski"; "Fowler" |]

let fullNames = Array.zip(firstNames) lastNames

3 |> cubeMe
cubeMe 2

2 |> cubeMe |> cubeMe |> cubeMe 


let divide x y = 
    printfn "dividing %d by %d" x y
    x / y
let answer = lazy(divide 8 2)
printfn "%d" (answer.Force()) 
printfn "%d" (answer.Force())

