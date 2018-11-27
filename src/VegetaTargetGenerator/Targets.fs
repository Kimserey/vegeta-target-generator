module Targets

open Types
open FsCheck

[<Target("person")>]
let personTarget: Target =
    {
        url = "http://172.22.88.177:5000/Persons"
        method = "POST"
        makeBody = fun () ->
            Arb.generate<Person>
            |> Gen.sample 100 1
            |> List.head
            |> box
        header = Map.ofList [( "Content-Type", [ "application/json" ] )]
    }

[<Target("blog")>]
let blogTarget: Target =
    {
        url = "http://172.22.88.177:5000/api/blogs"
        method = "GET"
        makeBody = fun () -> null
        header = Map.empty
    }