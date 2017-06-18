#I "../packages/FAKE/tools/"
#I "../packages/FAKE/FSharp.Data/lib/net40"
#r "FakeLib.dll"
#r "FSharp.Data.dll" 

open Fake

///////////////////////////////////////////////////////////////////////////////
// Helpers
///////////////////////////////////////////////////////////////////////////////
#load "BuildVersion.fsx"

///////////////////////////////////////////////////////////////////////////////
// Imported Targets
///////////////////////////////////////////////////////////////////////////////
#load "Packages.fsx"
#load "Compile.fsx"
#load "Test.fsx"

///////////////////////////////////////////////////////////////////////////////
// Targets
///////////////////////////////////////////////////////////////////////////////
Target "RestoreCompileTest" DoNothing
"RestorePackages" ==> "RestoreCompileTest"
"Compile" ==> "RestoreCompileTest"
"Test" ==> "RestoreCompileTest"

Target "All" DoNothing
"RestoreCompileTest" ==> "All"

Target "Travis" DoNothing
"RestoreCompileTest" ==> "All"

RunTargetOrDefault "All"