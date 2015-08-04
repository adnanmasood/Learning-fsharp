module Sorting

// Quick Sort
let rec quickSort = function
    | [] -> []
    | n::ns -> let lessthan, greaterEqual = List.partition ((>) n) ns
               quickSort lessthan @ n :: quickSort greaterEqual

let rand = new System.Random()

let data = List.init 10 (fun _  -> rand.Next())
//#time
let result = quickSort data
//#time

//#time
let result2 = List.sort data
//#time

// Functional implementation of quick sort - lazy and incremental.
let rec quickSort_func (pxs:seq<_>) = 
    seq {
        match Seq.toList pxs with
        | p::xs -> let lessthan, greaterEqual = List.partition ((>=) p) xs
                   yield! quickSort lessthan; yield p; yield! quickSort greaterEqual
        | _ -> ()
    }
//let rand = new System.Random()
//let data = List.init 10 (fun _  -> rand.Next())
//let result = Seq.toList (quickSort data)



let result_func = List.sort data
printfn "%A" result_func 

data |> quickSort |> Seq.take 1    // sub second

data |> quickSort |> Seq.length 

quickSort [2, 9, 8, 10, 15]


let sortedProcs =
    query {
        for proc in System.Diagnostics.Process.GetProcesses() do
        let isWindowed = proc.MainWindowHandle <> nativeint 0
        sortBy isWindowed
        thenBy proc.ProcessName
        select proc }


/////////////////////////
// Bubble Sort
////////////////////////

let swap x y (array : 'arr []) =
    let temp = array.[x]
    array.[x] <- array.[y]
    array.[y] <- temp
 
let bubbleSort array =
    let rec loop (array : 'arr []) =
        let mutable swaps = 0
        for i = 0 to array.Length - 2 do
            if array.[i] > array.[i+1] then
                swap i (i+1) array
                swaps <- swaps + 1
 
        if swaps > 0 then loop array else array
    loop array

////////////////////More functional implementation
let rec getHighest list = 
    match list with
    | head1 :: head2 :: tail when head1 > head2 -> getHighest (head1 :: tail)
    | head1 :: head2 :: tail -> getHighest (head2::tail)
    | head1 :: [] -> head1
    | _ -> failwith "Unrecognized pattern"

let bubbleSort_func list = 
        let rec innerBubbleSort sorted = function
        | [] -> sorted
        | l -> 
            let h = getHighest l
            let (x, y) = List.partition (fun i -> i = h) l
            innerBubbleSort (x @ sorted) y
        innerBubbleSort [] list

//////////////////Merge Sort
let split list =
    let rec aux l acc1 acc2 =
        match l with
            | [] -> (acc1,acc2)
            | [x] -> (x::acc1,acc2)
            | x::y::tail ->
                aux tail (x::acc1) (y::acc2)
    in aux list [] []
 
let rec merge l1 l2 =
    match (l1,l2) with
        | (x,[]) -> x
        | ([],y) -> y
        | (x::tx,y::ty) ->
            if x <= y then x::merge tx l2
            else y::merge l1 ty

let rec mergesort list = 
    match list with
        | [] -> []
        | [x] -> [x]
        | _ -> let (l1,l2) = split list
               in merge (mergesort l1) (mergesort l2)

let testdata = List.init 10000 (fun _  -> rand.Next())
//#time
let ms_result = mergesort data
//#time