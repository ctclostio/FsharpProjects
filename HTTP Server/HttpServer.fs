module HttpServer

open System
open System.Net
open System.Net.Sockets
open System.Text
open System.IO
open HttpRequest
open HttpResponse
open Router

type HttpServer(port : int) =

    let router = new Router()

    // Initialize the router with some routes
    do router.Register("GET", "/", Handlers.RootHandler)

    member this.Start() =
        let listener = new TcpListener(IPAddress.Any, port)
        listener.Start()
        printfn "Listening on port %d" port

        while true do
            let client = listener.AcceptTcpClient()
            printfn "Accepted connection"
            let stream = client.GetStream()
            let reader = new StreamReader(stream)
            let writer = new StreamWriter(stream)

            // Read the request
            let requestLine = reader.ReadLine()
            let parts = requestLine.Split(' ')
            let method = parts.[0]
            let url = parts.[1]

            // TODO: Read headers and body

            let request = new HttpRequest(method, url, new System.Collections.Generic.Dictionary<string, string>(), "")

            // Dispatch the request
            let response = router.Dispatch(request)

            // Write the response
            writer.WriteLine($"HTTP/1.1 {response.StatusCode} {response.ReasonPhrase}")
            // TODO: Write headers
            writer.WriteLine()
            writer.WriteLine(response.Body)

            writer.Flush()

            ()
