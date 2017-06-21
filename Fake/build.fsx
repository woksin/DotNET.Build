#I "../packages/FAKE/tools/"
#I "../packages/FAKE/FSharp.Data/lib/net40"
#r "FakeLib.dll"
#r "FSharp.Data.dll" 
#load "Globals.fsx"

open Fake
open Globals

///////////////////////////////////////////////////////////////////////////////
// Imported Targets
///////////////////////////////////////////////////////////////////////////////
#load "Packages.fsx"
#load "Compile.fsx"
#load "Test.fsx"
#load "AppVeyor.fsx"

///////////////////////////////////////////////////////////////////////////////
// Targets
///////////////////////////////////////////////////////////////////////////////
Target "RestoreCompileTest" DoNothing
"RestorePackages" ==> "RestoreCompileTest"
"Compile" ==> "RestoreCompileTest"
"Test" ==> "RestoreCompileTest"

Target "All" DoNothing
"RestoreCompileTest" ==> "All"

Target "AppVeyor" DoNothing
"UpdateVersionOnBuildServer" ==> "RestoreCompileTest"
"RestoreCompileTest" ==> "All"

Target "Travis" DoNothing
"RestoreCompileTest" ==> "All"

RunTargetOrDefault "All"