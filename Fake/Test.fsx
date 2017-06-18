open Fake
open Fake.DotNetCli

Target "Test" (fun _ ->
    trace "**** Test ****"

    let projects = !! "./Specifications/*.csproj"

    let testProject project =
        DotNetCli.Test
            (fun p ->
                { p with
                    Project = project
                    Configuration = "Release" })

    projects |> Seq.iter (testProject)

    trace "**** Test DONE ****"
)