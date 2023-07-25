module Program

open System
open HttpServer

let main argv =
    let server = new HttpServer(port = 8080)
    printfn "Server is running on port 8080"
    server.Start()
    0 // return an integer exit code
