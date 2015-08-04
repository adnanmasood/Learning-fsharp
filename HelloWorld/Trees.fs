module Trees

type tree = Node of tree list;;

let rec bal_tree = function
    | 0 -> Node []
    | n -> 
        Node [bal_tree(n-1); bal_tree (n-1)];;


let rec CountLeafNodes = function
    | Node [] -> 1
    | Node list -> 
        Seq.fold (fun s t -> s + CountLeafNodes t) 0 list;;

//
//
//type tree = 
//    |Leaf of string 
//    |Node of tree * tree


type tree <'a> = 
    |Leaf of 'a
    |Node of tree<'a> * tree<'a>

open System
open System.IO
 
type Tree<'a> =
   | Tree of 'a * Tree<'a> * Tree<'a>
   | Leaf of 'a
 
let rec inorder tree =
    seq {
      match tree with
          | Tree(x, left, right) ->
               yield! inorder left
               yield x
               yield! inorder right
          | Leaf x -> yield x
    }   
 
let rec preorder tree =
    seq {
      match tree with
          | Tree(x, left, right) ->
               yield x
               yield! preorder left
               yield! preorder right
          | Empty -> ()
    }   
 
let rec postorder tree =
    seq {
      match tree with
          | Tree(x, left, right) ->
               yield! postorder left
               yield! postorder right
               yield x
          | Empty -> ()
    }   
 
let levelorder tree =
    let rec loop queue =
        seq {
            match queue with
            | [] -> ()
            | (Empty::tail) -> yield! loop tail
            | (Tree(x, l, r)::tail) -> 
                yield x
                yield! loop (tail @ [l; r])
        }
    loop [tree]
 
[<EntryPoint>]
let main _ =
    let tree =
        Tree (1,
              Tree (2,
                    Tree (4,
                          Tree (7, Empty, Empty),
                          Empty),
                    Tree (5, Empty, Empty)),
              Tree (3,
                    Tree (6,
                          Tree (8, Empty, Empty),
                          Tree (9, Empty, Empty)),
                    Empty))
 
    let show x = printf "%d " x
 
    printf "preorder:    "
    preorder tree   |> Seq.iter show
    printf "\ninorder:     "
    inorder tree    |> Seq.iter show
    printf "\npostorder:   "
    postorder tree  |> Seq.iter show
    printf "\nlevel-order: "
    levelorder tree |> Seq.iter show
    0

// Yield the values of a binary tree in a sequence. 
type Tree<'a> =
   | Tree of 'a * Tree<'a> * Tree<'a>
   | Leaf of 'a

// inorder : Tree<'a> -> seq<'a>    
let rec inorder tree =
    seq {
      match tree with
          | Tree(x, left, right) ->
               yield! inorder left
               yield x
               yield! inorder right
          | Leaf x -> yield x
    }   

let mytree = Tree("D", Tree("B", Leaf("A"), Leaf("C")), Leaf("E"))
let myseq = inorder mytree
printfn "%A" myseq


type expression =
    | Integer of int
    | Var of string 
    | Addition of expression * expression
    | Multiply of expression * expression;;

let expr = Addition (Multiply(Integer 2, Integer 3), Integer 1)

let rec eval vars = function
    | Integer n -> n
    | Var v -> List.assoc v vars
    | Add(f, g ) -> eval vars f + eval vars g
    | Mu1 (f, g ) -> eval vars f * eval vars g
