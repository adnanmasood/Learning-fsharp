module dijkstra

open System
open System.IO
open Microsoft.FSharp.Collections

let weights = File.ReadAllLines("matrix.txt")
            |> Array.map(fun line -> line.Split(',') |> Array.map int32)
let matrixHeight = weights.Length;
let matrixWidth = weights.[0].Length;

type Node = { 
    Coordinates: int*int
    mutable Parent: Node
    mutable Weight: int 
    }        

let cost sourceNode (x, y) =
    sourceNode.Weight + weights.[y].[x]

let vicinity node =
    let coords = function
        | x, y when (x < matrixWidth - 1 && y < matrixHeight - 1) -> [(x + 1, y); (x, y + 1)]
        | x, y when (x < matrixWidth - 1) -> [(x + 1, y)]
        | x, y when (y < matrixHeight - 1) -> [(x, y + 1)]
        | _ -> []
    coords(node.Coordinates) |> List.map (fun coord -> { node with Coordinates = coord; 
                                                                Parent = node; 
                                                                Weight = cost node coord })

let rec startNode = { Coordinates = 0, 0; Parent = startNode; Weight = weights.[0].[0] }
let rec endNode = { Coordinates = matrixWidth - 1, matrixHeight - 1; Parent = endNode; Weight = Int32.MaxValue }
let currentNode = startNode

let openCollection = new ResizeArray<Node>()
let closedCollection = new ResizeArray<Node>()

let existsIn set node = 
    set |> Seq.exists(fun n -> n.Coordinates = node.Coordinates)

let PathFinder() =
    openCollection.Add(startNode)

    while not(endNode |> existsIn closedCollection) do
      
        let currentNode = openCollection |> Seq.minBy (fun node -> node.Weight)

        openCollection.RemoveAll(fun node -> node.Coordinates = currentNode.Coordinates) |> ignore
        closedCollection.Add(currentNode)

        let vicinityNodes = vicinity currentNode |> List.filter ((existsIn closedCollection) >> not)
        for node in vicinityNodes do            
           
            match openCollection |> Seq.tryFind (fun n -> n.Coordinates = node.Coordinates) with
            | None -> (openCollection.Add(node)
                       node.Parent <- currentNode
                       node.Weight <- cost currentNode node.Coordinates)
            | Some(n) -> (let newCost = cost currentNode n.Coordinates
                          if newCost < n.Weight then
                              n.Parent <- currentNode
                              n.Weight <- newCost)

    let rec walkBack node =
        seq {
            if node.Coordinates <> startNode.Coordinates then
                yield! walkBack node.Parent
            yield node
        }
    walkBack (closedCollection.Find(fun n -> n.Coordinates = endNode.Coordinates))

do
    let path = PathFinder()
    for n in path do
        let x, y = n.Coordinates
        printfn "%A %A" n.Coordinates weights.[y].[x]
    printfn "Weights of the traversed path: %A" (Seq.last path).Weight