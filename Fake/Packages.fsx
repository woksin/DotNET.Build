open Fake
open System.IO

#load "ProcessHelpers.fsx"
open ProcessHelpers

//*****************************************************************************
//* Restore Packages
//*****************************************************************************
Target "RestorePackages" (fun _ ->
    trace "**** Restoring packages ****"

    ProcessHelpers.Spawn("dotnet", "restore") |> ignore
    
    // let currentDir = Directory.GetCurrentDirectory()

    // for directory in projectsDirectories.Concat(specDirectories) do
    //     tracef "Restoring packages for %s" directory.FullName
    //     Directory.SetCurrentDirectory directory.FullName
    //     let allArgs = sprintf "restore"

    //     spawnProcess("dotnet", allArgs) |> ignore

    //Directory.SetCurrentDirectory(currentDir)
    trace "**** Restoring packages DONE ****"
)