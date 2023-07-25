module Handlers

open System
open System.Collections.Generic
open HttpRequest
open HttpResponse

let NotFoundHandler (request: HttpRequest) =
    let headers = Dictionary<string, string>()
    headers.Add("Content-Type", "text/plain")
    let body = "404 Not Found"
    new HttpResponse(404, "Not Found", headers, body)

let RootHandler (request: HttpRequest) =
    let headers = Dictionary<string, string>()
    headers.Add("Content-Type", "text/plain")
    let body = "Welcome to our F# HTTP server!"
    new HttpResponse(200, "OK", headers, body)
