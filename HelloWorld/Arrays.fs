module Arrays


let Philosophers = [| "Aquinas" ; "Alfarabi"; "Avicenna"; "Averroes"; "Maimonides"|]


let PhilosophersTyped : string [] = 
    [| "Aquinas" ; "Alfarabi"; "Avicenna"; "Averroes"; "Maimonides"|]

let Philosopher = Philosophers.[1]

let CountTo100 = [|1..100|]

let CountTo1000By100 = [|1..100..1000|]

let ReverseCount100 = [|100..-1..1|]

let SixSixers = Array.create 6 6
   
let zeroToSixty = [| 0.0 .. 4.5 .. 60.0 |]

let ArrayofCubes = (Array.init 10 (fun index -> index * index * index))

let Senators : string[] = Array.zeroCreate 100;;
let HouseReps : string array = Array.zeroCreate 435;;
let OriginalColonies = Array.zeroCreate<string> 13;;

let imdbtop10 : string[] = [|"The Shawshank Redemption (1994)"; 
                              "The Godfather (1972)";
                              "The Godfather: Part II (1974)";
                              "Il buono, il brutto, il cattivo. (1966)";
                              "Pulp Fiction (1994)";
                              "Inception (2010)";
                              "Schindler's List (1993)";
                              "12 Angry Men (1957)";
                              "One Flew Over the Cuckoo's Nest (1975)";
                              "The Dark Knight (2008)"
                              |]

let TopThree = imdbtop10.[1..3];; 
let TopFive = imdbtop10.[..5];; 
let BottomFive = imdbtop10.[5..];; 
let list = imdbtop10.[0..];; 

let wolfenstein3d = Array3D.zeroCreate<float> 11 11 11;;

wolfenstein3d.[0,0,0] <- 1.1;;