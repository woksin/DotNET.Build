#load "Globals.fsx"

open Fake
open Fake.DotNetCli
open Globals

Target "CreatePackages" (fun _ ->
    trace "**** Compiling ****"

    let projects = !! "./**/*.csproj"

    let buildProject project =
        DotNetCli.Pack
            (fun p ->
                { p with
                    Project = project
                    Configuration = "Release"
                    OutputPath = Globals.NuGetOutputPath })

    projects |> Seq.iter (buildProject)

    trace "**** Compiling DONE ****"
)