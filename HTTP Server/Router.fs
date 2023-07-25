module Router

open System
open System.Collections.Generic
open HttpRequest
open Handlers

type Router() =

    // Dictionary to store our handlers
    let routes = Dictionary<string, Func<HttpRequest, HttpResponse>>()

    member this.Register(method: string, path: string, handler: Func<HttpRequest, HttpResponse>) =
        routes.Add(method + path, handler)

    member this.Dispatch(request: HttpRequest) =
        if routes.ContainsKey(request.Method + request.URL) then
            routes.[request.Method + request.URL].Invoke(request)
        else
            Handlers.NotFoundHandler(request)
