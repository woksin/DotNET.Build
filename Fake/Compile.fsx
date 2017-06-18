open Fake
open Fake.DotNetCli

Target "Compile" (fun _ ->
    trace "**** Compiling ****"

    let projects = !! "./**/*.csproj"

    let buildProject project =
        DotNetCli.Build
            (fun p ->
                { p with
                    Project = project
                    Configuration = "Release" })

    projects |> Seq.iter (buildProject)

    trace "**** Compiling DONE ****"
)