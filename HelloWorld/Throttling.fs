module Throttling

// Add this example to chapter 7 later. 
open System.Net
open Microsoft.FSharp.Control.WebExtensions

let urls =
    [
    "Packtpub - Quantitative Finance", "https://www.packtpub.com/big-data-and-business-intelligence/f-quantitative-finance"    
    "Functional Programming using F#", "http://www.cambridge.org/us/academic/subjects/computer-science/programming-languages-and-applied-logic/functional-programming-using-f"
    ]

let getAsync(name, url:string) =
    async { 
        try 
            let uri = new System.Uri(url)
            let wc = new WebClient()
            let! html = wc.AsyncDownloadString(uri)
            printfn "Reading %d characters for %s" html.Length name
        with
            | ex -> printfn "%s" (ex.Message);
    }

let runAll() =
    urls
    |> Seq.map getAsync
    |> Async.Parallel 
    |> Async.RunSynchronously
    |> ignore

runAll()

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



let urls2 =
    [
    "https://www.packtpub.com/big-data-and-business-intelligence/f-quantitative-finance"    
    "http://www.cambridge.org/us/academic/subjects/computer-science/programming-languages-and-applied-logic/functional-programming-using-f"
    ]

let bag = ConcurrentBag<string>()

let f =
    async {
        let longestTitle = bag |> Seq.maxBy (fun x -> x.Length)
        printfn "The longest title is: \"%s\"" longestTitle
        }
// Returns the title of a Web page.
let title url =
    async {
        try
            let pattern = "(?is)<title>(.*?)</title>"
            use client = new WebClient()
            client.Encoding <- Encoding.UTF8
            let! html = client.AsyncDownloadString url
            let title =
                Regex(pattern).Match(html)
                              .Groups
                              .[1]
                              .Value
                              .Trim()
                              |> WebUtility.HtmlDecode
            bag.Add title
        with
        | _ -> ()
        }
 
let asyncs =
    urls2
    |> List.map (fun x -> Uri x)
    |> List.map title
 
throttle asyncs 5 f