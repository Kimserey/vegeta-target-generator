module TargetPerson

open Types

    type Person =
        {
            name: string
        }

    [<Target(name = "person-load-test")>]
    let target: Target<Person> =
        {
            url = "http://172.22.88.177:5000/Persons";
            method = "POST";
            body = PickFrom [{ name = "Kim" }; { name = "Sam" }; { name = "Tom" }]
            header = Map.ofList [( "Content-Type", [ "application/json" ] )]
        }
