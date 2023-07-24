open PortScanner

[<EntryPoint>]
let main argv =
    scanPorts "localhost" 1 100
    0 // Return an integer exit code
