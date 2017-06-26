#load "BuildVersion.fsx"
#load "ProcessHelpers.fsx"

open System
open BuildVersion
open ProcessHelpers

module Versioning =
    let GetVersionFromGit() = 
        let result = ProcessHelpers.Spawn("git","tag --sort=-version:refname")
        let version = result.Split('\n') |> Seq.filter (fun x -> x.Length > 0) |> Seq.head
        let buildVersion = new BuildVersion(version)
        buildVersion

    let GetBuildNumber() =
        let envBuildNumber = Environment.GetEnvironmentVariable("APPVEYOR_BUILD_NUMBER")
        let buildNumber = if String.IsNullOrWhiteSpace(envBuildNumber) then 0 else envBuildNumber |> int
        buildNumber