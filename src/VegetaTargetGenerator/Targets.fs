module Targets

open Types
open FsCheck

[<Target("person")>
let personTarget: Target =
    {
        url = "http://localhost:5000/Persons"
        method = "POST"
        makeBody = fun () ->
            Arb.generate<Person>
            |> Gen.sample 100 1
            |> List.head
            |> box
        header = Map.ofList [( "Content-Type", [ "application/json" ] )]
    }