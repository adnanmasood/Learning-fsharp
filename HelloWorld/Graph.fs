module Graph

type Graph() =   
   let mutable nodes = []  
   let mutable edges = []  
   member this.Nodes with get() = nodes  
   member this.Edges with get() = edges
     
   member this.CreateNode(id) =   
     match this.FindNode(id) with  
       | Some(n) -> None  
       | None ->   
         let node = Node(this, ID=id)  
         nodes <- nodes @ [ node ]  
         Some node
           
   member this.CreateEdgeFromNode(from:Node, ``to``:Node, id) =   
     match this.FindEdge id with  
     | Some(edge) -> None  
     | None ->   
       let edge = Edge(this, from, ``to``, ID=id)  
       from.AddOutgoingEdge(edge)  
       ``to``.AddIncomingEdge(edge)  
       edges <- edges @ [edge]  
       Some edge
         
   member this.CreateEdgeFromID(from, ``to``, id) =   
     let fromNode = this.FindNode(from)  
     let toNode = this.FindNode(``to``)  
     match fromNode, toNode with  
       | Some(n0), Some(n1) -> this.CreateEdgeFromNode(n0, n1, id)  
       | _ -> None  

   member this.FindNode(id) =   
     (nodes:Node list) |> Seq.tryFind(fun n -> n.ID = id)  
   member this.FindEdge(id) =   
     (edges:Edge list) |> Seq.tryFind(fun edge -> edge.ID = id)  

   member this.RemoveEdge(edge:Edge) =   
     (edge.FromNode:Node).RemoveOutgoingEdge(edge)  
     (edge.ToNode:Node).RemoveIncomingEdge(edge)  
     edges <- edges |> List.filter (fun n -> n<>edge)  
   member this.RemoveNode(node:Node) =   
     node.OutgoingEdges @ node.IncomingEdges |> List.iter this.RemoveEdge  
     nodes <- nodes |> List.filter (fun n -> n<>node)    
 and Node(g) =  
   let mutable incomingEdges = []  
   let mutable outgoingEdges = []   
   member val ID = Unchecked.defaultof<_> with get, set  
   member val Data = Unchecked.defaultof<_> with get, set  
   member this.IncomingEdges with get() = incomingEdges  
   member this.OutgoingEdges with get() = outgoingEdges  
   member this.AddIncomingEdge(edge:Edge) =   
     if edge.ToNode = this then  
       incomingEdges <- incomingEdges |> List.append [edge]  
   member this.AddOutgoingEdge(edge:Edge) =   
     if edge.FromNode = this then  
       outgoingEdges <- outgoingEdges |> List.append [edge]  
   member this.RemoveIncomingEdge(edge:Edge) =   
     incomingEdges <- incomingEdges |> List.filter (fun n -> n<>edge)  
   member this.RemoveOutgoingEdge(edge:Edge) =   
     outgoingEdges <- outgoingEdges |> List.filter (fun n -> n<> edge)  
   override this.ToString() =  
     sprintf "Node(%A)" this.ID  
 and Edge(g, from:Node, ``to``:Node) =   
   member val ID = Unchecked.defaultof<_> with get, set  
   member val Data = Unchecked.defaultof<_> with get, set  
   member this.FromNode with get() = from  
   member this.ToNode with get() = ``to``  
   override this.ToString() =   
     sprintf "Edge(%A, %A -> %A)" this.ID this.FromNode this.ToNode  

