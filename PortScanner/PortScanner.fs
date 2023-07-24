module PortScanner

open System
open System.Net
open System.Net.Sockets

let scanPort (host:string) (port:int) =
    use client = new TcpClient()
    try
        client.ConnectAsync(host, port) |> Async.AwaitTask |> Async.RunSynchronously
        if client.Connected then
            printfn "Port %d is open" port
    with
    | _ -> printfn "Port %d is closed" port

let scanPorts host startPort endPort =
    for port in [startPort..endPort] do
        scanPort host port
