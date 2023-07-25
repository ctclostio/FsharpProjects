module HttpResponse

open System
open System.Collections.Generic

type HttpResponse(statusCode: int, reasonPhrase: string, headers: Dictionary<string, string>, body: string) =
    member val StatusCode = statusCode with get, set
    member val ReasonPhrase = reasonPhrase with get, set
    member val Headers = headers with get, set
    member val Body = body with get, set
