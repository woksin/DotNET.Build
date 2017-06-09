open System.IO

#load "SpawnProcess.fsx"

//*****************************************************************************
//* Restore Packages
//*****************************************************************************
Target "RestorePackages" (fun _ ->
    trace "**** Restoring packages ****"

    let currentDir = Directory.GetCurrentDirectory()

    for directory in projectsDirectories.Concat(specDirectories) do
        tracef "Restoring packages for %s" directory.FullName
        Directory.SetCurrentDirectory directory.FullName
        let allArgs = sprintf "restore"

        spawnProcess("dotnet", allArgs) |> ignore

    Directory.SetCurrentDirectory(currentDir)
    trace "**** Restoring packages DONE ****"
)