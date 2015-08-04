module PreReqs

printfn "Hello World"

//let binding
let poetry = "Roses are #ff0000
                  Violets are #0000ff
              All my base
                 are belong to you"

let pi = 3.141592654

let e, white = 0.5772156, 0xffffff


//mutable values

//let quote = "The Only Thing That Is Constant Is Change -Heraclitus"
// quote <- "Yup! you are right Heraclitus."
//PreReqs.fs(19,1): error FS0027: This value is not mutable
//the destructive assignment operator

let mutable quote = "The Only Thing That Is Constant Is Change -Heraclitus"
quote <- "Yup! you are right Heraclitus."

//All strings are UTF 16 double byte. 
quote.[3]
//val it : char = '!'

let dns = System.Net.Dns.GetHostAddresses("www.packtpub.com")
//val dns : System.Net.IPAddress [] = [|83.166.169.231|]

//Like  C#, verbatim strings can be defined with 
let stmt = @"chown -R us ./base"

//functions

let square n = n * n
let cube n = n * square n

//

let eval =
    if 2+2 = 5 then
        printfn "Does not compute"
    else 
        printfn "Probably Computes";;

//Loops
  
  for i = 1 to 10 do  
      printfn "E/c^2 sqrt(-1) PV=nRT" 

//Tuples contain two or more values of potentially different types
let tuple = ("Godel", "Escher", "Bach") //Or it can also be defined as 
let tuple_terse = "Godel", "Escher", "Bach" 

let diversity = ("Arkanian", "Ewok", 2.0, 0x000000, 0xFF8000, 1I,  4, 0x4, 0b0100, 4L, 4UL, 4u, 4s, 4us, 4y, 4uy, 4.0, 4.0f, 4I)

//Arrays
let bosons =  [|"Photon"; "W boson"; "Z boson"; "Gluon";"Higgs boson"; "Graviton"|]

let _3Threes = Array.create 3 3
let OneToTen = [|1..10|]
let slicendice = OneToTen.[..6]

