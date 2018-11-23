module Target_Person2

open Types

    type Person2 =
        {
            name: string
        }

    [<Target(name = "some-different-load-test")>]
    let target: Target<Person2> =
        {
            url = "http://172.22.88.177:5000/Persons2";
            method = "POST";
            body = PickFrom [{ name = "Kim" }; { name = "Sam" }; { name = "Tom" }]
            header = Map.ofList [( "Content-Type", [ "application/json" ] )]
        }
