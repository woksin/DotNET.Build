#I "packages/FAKE/tools/"

#load "BuildVersion.fsx"
#load "SpawnProcess.fsx"
#load "Packages.fsx"

Target "All" DoNothing
"RestorePackages" ==> "All"

RunTargetOrDefault "All"
