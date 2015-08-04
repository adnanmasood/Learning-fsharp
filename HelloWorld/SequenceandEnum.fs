module SequenceandEnum
 
let intExp =
   seq {
      for i in 1..1000 do
         yield i
   }
 
let intExp_yield  =
   seq {
      for i in 1..1000 -> i
   }
 
seq { for i in 0 .. 10 .. 100 do 
        yield! seq {i ..  1 .. i+9}}

 
let integers = Seq.init 1000 (fun i -> i + 1)
 
let intsInf = Seq.initInfinite (fun i -> i + 1)
 
 
seq { 0..10 }
 
seq { 0.0..10.0 }
 
seq { 'a'..'z' }
 
seq { 0..10..100 }
 
seq { 99..-1..0 }
 
seq { 0..9 } |> Seq.iter (printfn "%i");;
 
let arr = [|1..1000|]
 
let odds =
    arr
    |> Seq.filter (fun i -> i%2 <> 0)
 
seq { 0..999 } |> Seq.map (fun i -> i * i);;

let sequence = seq { 10 .. -1 .. 1 } |> Seq.sort;;

seq { 0..999 } |> Seq.length

let seqFromArray_int = [| 1 .. 10 |] :> seq<int>

let seqFromArray = [| 1 .. 10 |] |> Seq.ofArray

seq { 1 .. 100 } |> Seq.fold (fun x y -> x + y) 0;;

seq { 1..100 } |> Seq.fold (+) 0;;

Seq.fold (+) 0.0 [1.0; 2.0; 3.0];;

seq { 1 .. 100 } |> Seq.reduce (+);;

seq { 1..100 } |> Seq.sum;;

seq { 1.0..100.0 } |> Seq.average;;


type ProgrammingLanguage = { id : int; name : string; publishYear : int}
                            override x.ToString() = sprintf "%s (%i)" x.name x.publishYear
type Developer = { id : int; Name : string  }
                            override x.ToString() = sprintf "%s" x.Name
type Developer_PL = { developerID : int; pl_ID : int }
 
let ProgrammingLanguages =   
    [   { id = 1; name = "C"; publishYear = 1972; }
        { id = 2; name = "C++"; publishYear = 1985; }
        { id = 3; name = "C#"; publishYear = 2000; }
        { id = 4; name = "F#"; publishYear = 2005; }
        { id = 5; name = "Java"; publishYear = 1991; }
        { id = 6; name = "Pascal"; publishYear = 1970; }
        { id = 7; name = "Python"; publishYear = 1997; }
        { id = 8; name = "Basic"; publishYear = 1964; }
        { id = 9; name = "COBOL"; publishYear = 1959; }
        { id = 10; name = "FORTRAN"; publishYear = 1957; }
        { id = 11; name = "LISP"; publishYear = 1956; }
        { id = 12; name = "Perl"; publishYear = 1987; }
        { id = 13; name = "JavaScript"; publishYear = 1995; }
        { id = 14; name = "Scheme"; publishYear = 1975; }
        { id = 15; name = "Clojure"; publishYear = 2007; }
        { id = 16; name = "Haskell"; publishYear = 1990; }
        { id = 17; name = "Ruby"; publishYear = 1995; }
        { id = 18; name = "OCaml"; publishYear = 1996; }
        { id = 19; name = "Scala"; publishYear = 2003; }]
 
let Developers =
    [   { id = 1; Name = "Dennis Ritchie"; }
        { id = 2; Name = "Bjarne Stroustrup";}
        { id = 3; Name = "Anders Hejlsberg";}
        { id = 4; Name = "Don Syme";}
        { id = 5; Name = "James A. Gosling";}
        { id = 6; Name = "Nicklaus Wirth";}
        { id = 7; Name = "Guido van Rossum";}
        { id = 8; Name = "Kemeny and Kurtz";}
        { id = 9; Name = "Grace Hopper";}
        { id = 10; Name = "John Backus";}
        { id = 11; Name = "John McCarthy";}
        { id = 12; Name = "Larry Wall";}
        { id = 13; Name = "Brendan Eich";}
        { id = 14; Name = "Steele and Sussman";}
        { id = 15; Name = "Rich Hickey";}
        { id = 16; Name = "Jones, Augustsson, et al";}
        { id = 17; Name = "Yukihiro Matsumoto, et al";}
        { id = 18; Name = "Xavier Leroy et al.";}
        { id = 19; Name = "Martin Odersky";}]
 
 
let Developers_PLs =
    [ { developerID = 1; pl_ID  = 1; }
      { developerID = 2; pl_ID  = 2; }
      { developerID = 3; pl_ID  = 3; }
      { developerID = 4; pl_ID  = 4; }
      { developerID = 5; pl_ID  = 5; }
      { developerID = 6; pl_ID  = 6; }
      { developerID = 7; pl_ID  = 7; }
      { developerID = 8; pl_ID  = 8; }
      { developerID = 9; pl_ID  = 9; }
      { developerID = 10; pl_ID  = 10; }
      { developerID = 11; pl_ID  = 11; }
      { developerID = 12; pl_ID  = 12; }
      { developerID = 13; pl_ID  = 13; }
      { developerID = 14; pl_ID  = 14; }
      { developerID = 15; pl_ID  = 15; }
      { developerID = 16; pl_ID  = 16; }
      { developerID = 17; pl_ID  = 17; }
      { developerID = 18; pl_ID  = 18; }
      { developerID = 19; pl_ID  = 19 ;}]
 
query { for pl in ProgrammingLanguages do
            where (pl.publishYear = 2005)
            select (pl.ToString()) }
 
let data = seq { use s = new System.IO.StreamReader(@"\\pas-amasood-v1\c$\bck\dropbox\edu\My Books\F# Data Structure Book\github\source\FSDataStructuresandAlgorithms\HelloWorld\ProgrammingLanguages.txt")
           while not s.EndOfStream do yield s.ReadLine() }
          
 
let getPLPageBySize pageSize pageNumber =
    query { for pl in ProgrammingLanguages do
        skip (pageSize * (pageNumber - 1))
        take pageSize
        select (pl.ToString()) }
 
getPLPageBySize 4 2
 
  
let getPLPageByYear year =
    query { for pl in ProgrammingLanguages do
                sortBy pl.publishYear
                skipWhile (pl.publishYear < year)
                takeWhile (pl.publishYear = year)
                select (pl.ToString()) }

getPLPageByYear 2007

query { for f in ProgrammingLanguages do count }
 
query { for pl in ProgrammingLanguages do 
        select pl.publishYear  }

query { for dev in Developers do nth 2 }

query { for pl in ProgrammingLanguages do
        groupBy pl.publishYear into pl
        sortBy pl.Key
        select (pl.Key, pl) } 

seq { 99..-1..0 } 


let int_inf = Seq.initInfinite (fun i -> i + 1)


let seqInfinite = Seq.initInfinite (fun i ->
                    let n = float( i + 1 )
                    1.0 / (n * n * n))
printfn "%A" seqInfinite

let XSVEnumerator(fileName) = 

    seq { use s = System.IO.File.OpenText(fileName)
          while not s.EndOfStream do 
             let line = s.ReadLine() 
             let tokens = line.Split [|'\t'|] 
             yield tokens }

let data = 
    
    seq { use s = new  System.IO.StreamReader(@"C:\src\HelloWorld\ProgrammingLanguages.txt")
          while not s.EndOfStream do yield s.ReadLine() }

let xsv = XSVEnumerator(fileName)  

xsv |> Seq.iter (string >> printfn "line %s");

xsv |> Seq.iter (Array.length >> printfn "line has %d entries");

xsv |> Seq.iter (Array.map (fun s -> s.Length) >> printfn "lengths of entries: %A")

let int_init = Seq.init 1000 (fun i -> i + 1)

xsv |> Seq.iter (Array.map (fun s -> s.ToString()) >> printfn "Entries: %A")


//let integers = Seq.init 1000 (fun i -> i + 1)