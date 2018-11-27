module Types

open System
open Utils

type TargetAttribute(name: string) =
    inherit Attribute()
    member val name = name with get, set

type Target =
    {
        url: string
        method: string
        makeBody: unit -> obj
        header: Map<string, string list>
    }

type VegetaTarget =
    {
        url: string
        method: string
        body: string
        header: Map<string, string list>
    }
    static member From (target: Target) =
        {
            url = target.url
            method = target.method
            body =
                if target.method = "POST" then
                    target.makeBody() |> serialize |> base64
                else
                    null
            header = target.header
        }

type Person =
    {
        name: string
    }
