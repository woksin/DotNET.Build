#load "BuildVersion.fsx"
#load "Versioning.fsx"

open System
open BuildVersion
open Versioning

type Globals() =
    static let gitVersion = Versioning.GetVersionFromGit()
    static let buildNumber = Versioning.GetBuildNumber()
    static let buildVersion = new BuildVersion(gitVersion.Major, gitVersion.Minor, gitVersion.Patch, buildNumber, gitVersion.PreReleaseString, false)
    static let isWindows = Environment.OSVersion.Platform = PlatformID.Win32NT
    static let isAppVeyor = if String.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("APPVEYOR")) then false else true
    static let appVeyorJobId = Environment.GetEnvironmentVariable("APPVEYOR_JOB_ID")

    static member GitVersion with get() = gitVersion
    static member BuildNumber with get() = buildNumber
    static member BuildVersion with get() = buildVersion
    static member IsWindows with get() = isWindows
    static member IsAppVeyor with get() = isAppVeyor
    static member AppVeyorJobId with get() = appVeyorJobId
    static member NuGetOutputPath with get() = "artifacts/nuget/"
