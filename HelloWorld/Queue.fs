module Queue

let q = System.Collections.Generic.Queue<string>();;

q.Enqueue("1st element");; 
q.Enqueue("2nd element");;
q.Enqueue("3rd element");;

q.Dequeue();; 
q.Dequeue();;
q.Dequeue();;


type 'a stack =
    | EmptyStack
    | StackNode of 'a * 'a stack
 
module Stack =        
    let hd = function
        | EmptyStack -> failwith "Empty stack"
        | StackNode(hd, tl) -> hd
 
    let tl = function
        | EmptyStack -> failwith "Emtpy stack"
        | StackNode(hd, tl) -> tl
 
    let cons hd tl = StackNode(hd, tl)
 
    let empty = EmptyStack
 
    let rec rev s =
        let rec loop acc = function
            | EmptyStack -> acc
            | StackNode(hd, tl) -> loop (StackNode(hd, acc)) tl
        loop EmptyStack s
 

 type Queue<'t>(front : stack<'t>, rear : stack<'t>) =
    let chk = function
        | EmptyStack, rear -> Queue(Stack.rev rear, EmptyStack)
        | front, rear -> Queue(front, rear)
 
    member this.hd =
        match front with
        | EmptyStack -> failwith "Empty Stack"
        | Node(hd, tl) -> hd
 
    member this.tl =
        match front, rear with
        | EmptyStack, _ -> failwith "Empty Stack"
        | Node(x, f), r -> chk(front, rear)
 
    member this.enqueue(x) = chk(front, StackNode(x, rear))
 
    static member empty = Queue<'a>(Stack.empty, Stack.empty)

//
//
open System
open Microsoft.FSharp.Control
//
type Msg(msgIdentifier, msgContents) =
     static let mutable cnt = 0
     member this.ID = msgIdentifier
     member this.Contents = msgContents
     static member CreateMsg(contents) =
        cnt <- cnt + 1
        Msg(cnt, contents)

let mailbox = new MailboxProcessor<Msg>(fun inbox ->
    let rec loop cnt =
        async { printfn "Msg cnt = %d. Awaiting next Msg." cnt
                let! msg = inbox.Receive()
                printfn "Msg received. ID: %d Contents: %s" msg.ID msg.Contents
                return! loop( cnt + 1) }
    loop 0)

mailbox.Start()
mailbox.Post(Msg.CreateMsg("Knock Knock."))
mailbox.Post(Msg.CreateMsg("who's there?"))
mailbox.Post(Msg.CreateMsg("Doctor"))
mailbox.Post(Msg.CreateMsg("Doctor Who?"))
mailbox.Post(Msg.CreateMsg("Exactly"))

Console.WriteLine("Processor Started...")
Console.ReadLine() |> ignore

//
////
//
open System
open System.Collections.Generic
open System.Collections.Concurrent
open System.Net
open System.Text
open System.Text.RegularExpressions
type Message =
    | Work
    | Quit

let throttle asyncs limit f = 
    let q = Queue()
    let dequeue() = try q.Dequeue() |> Some with _ -> None
    asyncs |> Seq.iter (fun x -> q.Enqueue x)
    
    let agent =
        MailboxProcessor.Start(fun x ->
            let rec loop count =
                async {
                    let! msg = x.Receive()
                    match msg with
                    | Work ->
                        let work = dequeue()
                        match work with
                        | Some work' ->
                            async {
                                try
                                    do! work'
                                finally
                                    x.Post Work
                                } |> Async.Start
                            return! loop count
                        | None ->
                            x.Post Quit
                            return! loop (count + 1)
                    | Quit ->
                        match count with
                        | y when y = limit ->
                            f |> Async.Start
                            (x:> IDisposable).Dispose()
                        | _ -> return! loop count
                }
            loop 0
        )
    [1 .. limit] |> List.iter (fun x -> agent.Post Work)