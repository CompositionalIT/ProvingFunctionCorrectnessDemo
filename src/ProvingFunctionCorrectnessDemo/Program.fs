// For more information see https://aka.ms/fsharp-console-apps
open Expecto

let setUnionTests =
    testList "Set.union tests" [
        FsCheck.Property(
            "All elements in first set are in union",
            (fun (a: Set<int>) (b: Set<int>) ->
                let aUnionB = Set.union a b
                a |> Set.forall (fun x -> aUnionB |> Set.contains x))
        )

        FsCheck.Property(
            "All elements in second set are in union",
            (fun (a: Set<int>) (b: Set<int>) ->
                let aUnionB = Set.union a b
                b |> Set.forall (fun x -> aUnionB |> Set.contains x))
        )

        FsCheck.Property(
            "All elements in union are in first or second set",
            (fun (a: Set<int>) (b: Set<int>) ->
                Set.union a b
                |> Set.forall (fun x -> a |> Set.contains x || b |> Set.contains x))
        )
    ]

[<EntryPoint>]
let main _ =
    runTestsWithCLIArgs [] [||] setUnionTests
