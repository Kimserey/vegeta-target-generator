open FsCheck
open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open System
open System.Text

type Target =
    {
        url: string
        method: string
        body: string
        header: Map<string, string list>
    }

type Person =
    {
        name: string
    }

open System.Collections.Concurrent

[<EntryPoint>]
let main argv =
    let (rate, duration) =
        match argv with
        | [|r; d|] -> (int32 r, int32 d)
        | _ -> failwith "Rate and duration (in seconds) must be specified."

    let serialize data =
        JsonConvert.SerializeObject(data, JsonSerializerSettings(ContractResolver = CamelCasePropertyNamesContractResolver()))

    let base64 (data: string) =
        Encoding.ASCII.GetBytes data |> Convert.ToBase64String

    Arb.generate<Person>
    |> Gen.sample 1000 (rate * duration)
    |> List.map serialize
    |> List.map (fun b ->
        {
            url = "http://172.22.88.177:5000/Persons";
            method = "POST";
            body = base64 b;
            header = Map.ofList [( "Content-Type", [ "application/json" ] )]
        })
    |> List.map serialize
    |> List.iter (printfn "%s")

    0
