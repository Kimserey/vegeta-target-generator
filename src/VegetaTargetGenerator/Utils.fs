module Utils

open Newtonsoft.Json
open System.Text
open Newtonsoft.Json.Serialization
open System

let serialize data =
    JsonConvert.SerializeObject(data,
        JsonSerializerSettings(
            ContractResolver = CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore))

let base64 (data: string) =
    Encoding.ASCII.GetBytes data |> Convert.ToBase64String
