module Types

open System

type TargetAttribute() =
    inherit Attribute()
    member val name: string = "" with get, set

type Body<'a> =
    | Single of 'a
    | PickFrom of 'a list

type Target<'a> =
    {
        url: string
        method: string
        body: Body<'a>
        header: Map<string, string list>
    }