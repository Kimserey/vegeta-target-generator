open System.Reflection
open Types

[<EntryPoint>]
let main argv =
    let get name =
        let prop =
            Assembly.GetExecutingAssembly().GetTypes()
            |> Array.collect (fun t -> t.GetProperties(BindingFlags.Static ||| BindingFlags.Public))
            |> Array.map (fun p -> p, p.GetCustomAttributes(typeof<TargetAttribute>, true))
            |> Array.filter (fun (_, attrs) ->
                attrs.Length > 0
                && attrs |> Array.exists (fun a -> (a :?> TargetAttribute).name = name))
            |> Array.tryHead

        match prop with
        | Some (prop, _) -> prop.GetValue(null)
        | None -> failwith <| sprintf "Failed to find target named '%s'." name

    let targetGenerator =
        get "some-different-load-test"

    printfn "%A" targetGenerator

    0