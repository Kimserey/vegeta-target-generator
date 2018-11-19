namespace TestWebServer

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Mvc

type Person =
    {
        name: string;
    }

[<ApiController>]
[<Route("Persons")>]
type PersonsController() =
    inherit ControllerBase()

    member __.Post(person: Person): ActionResult<string> =
        printfn "%s" person.name
        ActionResult.op_Implicit person.name

type Startup() =

    member this.ConfigureServices(services: IServiceCollection) =
        services.AddMvc() |> ignore
        ()

    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseMvc() |> ignore