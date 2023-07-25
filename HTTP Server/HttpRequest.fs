module HttpRequest

open System
open System.Collections.Generic

type HttpRequest(method: string, url: string, headers: Dictionary<string, string>, body: string) =
    member val Method = method with get, set
    member val URL = url with get, set
    member val Headers = headers with get, set
    member val Body = body with get, set
