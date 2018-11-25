open System.Reflection
open Utils
open Types

[<EntryPoint>]
let main argv =
    let (rate, duration) =
        match argv with
        | [|r; d|] -> (int32 r, int32 d)
        | _ -> failwith "Rate and duration (in seconds) must be specified."

    let find name =
        let prop =
            Assembly.GetExecutingAssembly().GetTypes()
            |> Array.collect (fun t -> t.GetProperties(BindingFlags.Static ||| BindingFlags.Public))
            |> Array.map (fun p -> p, p.GetCustomAttributes(typeof<TargetAttribute>, true))
            |> Array.filter (fun (_, attrs) ->
                attrs.Length > 0
                && attrs |> Array.exists (fun a -> (a :?> TargetAttribute).name = name))
            |> Array.tryHead

        match prop with
        | Some (prop, _) -> prop.GetValue(null) :?> Target
        | None -> failwith <| sprintf "Failed to find target named '%s'." name

    let target =
        find "person"

    for  _ in 0.. rate* duration do
        VegetaTarget.From target
        |> serialize
        |> printfn "%s"

    0
