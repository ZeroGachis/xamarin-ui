import jetbrains.buildServer.configs.kotlin.v2019_2.*
import jetbrains.buildServer.configs.kotlin.v2019_2.buildFeatures.PullRequests
import jetbrains.buildServer.configs.kotlin.v2019_2.buildFeatures.commitStatusPublisher
import jetbrains.buildServer.configs.kotlin.v2019_2.buildFeatures.pullRequests
import jetbrains.buildServer.configs.kotlin.v2019_2.buildFeatures.replaceContent
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.MSBuildStep
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.msBuild
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.nuGetInstaller
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.nuGetPack
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.nuGetPublish
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.script
import jetbrains.buildServer.configs.kotlin.v2019_2.triggers.vcs
import jetbrains.buildServer.configs.kotlin.v2019_2.vcs.GitVcsRoot

/*
The settings script is an entry point for defining a TeamCity
project hierarchy. The script should contain a single call to the
project() function with a Project instance or an init function as
an argument.

VcsRoots, BuildTypes, Templates, and subprojects can be
registered inside the project using the vcsRoot(), buildType(),
template(), and subProject() methods respectively.

To debug settings scripts in command-line, run the

    mvnDebug org.jetbrains.teamcity:teamcity-configs-maven-plugin:generate

command and attach your debugger to the port 8000.

To debug in IntelliJ Idea, open the 'Maven Projects' tool window (View
-> Tool Windows -> Maven Projects), find the generate task node
(Plugins -> teamcity-configs -> teamcity-configs:generate), the
'Debug' option is available in the context menu for the task.
*/

version = "2020.2"

project {
    description = "Composant graphique xamarin"

    vcsRoot(PullRequest_1)
    vcsRoot(Integration_1)

    buildType(PullRequest)
    buildType(Release)
    buildType(Integration)

    template(Build)
}

object Integration : BuildType({
    templates(Build)
    name = "Integration"

    params {
        select("system.Configuration", "Release", label = "Build Configuration",
                options = listOf("ReleaseDesktop", "DebugDesktop", "ReleaseWince", "DebugWince", "Release"))
        param("env.Version", "%teamcity.build.branch%")
    }

    vcs {
        root(Integration_1)
    }

    triggers {
        vcs {
            id = "vcsTrigger"
            branchFilter = """
                +:*
                -:<default>
            """.trimIndent()
        }
    }
})

object PullRequest : BuildType({
    templates(Build)
    name = "Pull Request"

    params {
        select("system.Configuration", "Release", label = "Build Configuration",
                options = listOf("ReleaseDesktop", "DebugDesktop", "ReleaseWince", "DebugWince", "Release"))
        param("system.MsBuildExtensionPath", """C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild""")
        param("env.Version", "%teamcity.build.branch%.%build.counter%.0")
    }

    vcs {
        root(PullRequest_1)
    }

    triggers {
        vcs {
            id = "vcsTrigger"
            branchFilter = """
                +:*
                -:<default>
            """.trimIndent()
        }
    }

    features {
        pullRequests {
            id = "BUILD_EXT_2"
            provider = github {
                authType = token {
                    token = "credentialsJSON:d94bdab2-5863-455a-a0ac-0f455aa32ca9"
                }
                filterTargetBranch = """
                    -:<default>
                    +:refs/pull/*/merge
                """.trimIndent()
                filterAuthorRole = PullRequests.GitHubRoleFilter.MEMBER
            }
        }
        commitStatusPublisher {
            id = "BUILD_EXT_8"
            vcsRootExtId = "${PullRequest_1.id}"
            publisher = github {
                githubUrl = "https://api.github.com"
                authType = personalToken {
                    token = "credentialsJSON:d94bdab2-5863-455a-a0ac-0f455aa32ca9"
                }
            }
        }
    }
    
    disableSettings("RUNNER_18")
})

object Release : BuildType({
    templates(Build)
    name = "Release"

    params {
        select("system.Configuration", "Release", label = "Build Configuration",
                options = listOf("ReleaseDesktop", "DebugDesktop", "ReleaseWince", "DebugWince", "Release"))
        param("env.Version", "%teamcity.build.branch%")
    }

    vcs {
        root(DslContext.settingsRoot)
    }

    steps {
        nuGetPack {
            name = "Build nuget package"
            id = "RUNNER_35"
            toolPath = "%teamcity.tool.NuGet.CommandLine.DEFAULT%"
            paths = "Smartway.UiComponent.nuspec"
            version = "%env.Version%"
            outputDir = "Output"
            cleanOutputDir = false
            publishPackages = true
        }
        nuGetPublish {
            name = "Publish nuget package"
            id = "RUNNER_36"
            toolPath = "%teamcity.tool.NuGet.CommandLine.DEFAULT%"
            packages = "**/*.nupkg"
            serverUrl = "nuget.org"
            apiKey = "credentialsJSON:756ff5ef-6e71-45cf-9c03-0faa699f81cf"
        }
        stepsOrder = arrayListOf("RUNNER_33", "RUNNER_23", "RUNNER_26", "RUNNER_28", "RUNNER_29", "RUNNER_30", "RUNNER_35", "RUNNER_36")
    }

    triggers {
        vcs {
            id = "vcsTrigger"
            branchFilter = """
                +:*
                -:<default>
            """.trimIndent()
        }
    }

    features {
        replaceContent {
            id = "BUILD_EXT_3"
            fileRules = """
                **/*.csproj
                **/*.nuspec
            """.trimIndent()
            pattern = "<Version>.*</Version>"
            replacement = "<Version>%env.Version%</Version>"
        }
    }
})

object Build : Template({
    name = "Build"

    artifactRules = "Smartway.UiComponent.Sample.Android/bin/Release/xamarin-ui-sample.apk => Apk/%env.Version%"

    params {
        param("system.JavaSdkDirectory", "%JavaSdkPath%")
        param("env.MSBuildExtensionsPath", "tata")
        param("MSBuildExtensionsPath", "prout")
        param("JavaSdkPath", """C:\Program Files\Android\jdk\microsoft_dist_openjdk_1.8.0.25""")
        param("JarSignerPath", """%JavaSdkPath%\bin\jarsigner.exe""")
        param("ZipAlignPath", """C:\Program Files (x86)\Android\android-sdk\build-tools\28.0.3\zipalign.exe""")
    }

    vcs {
        checkoutMode = CheckoutMode.ON_AGENT
    }

    steps {
        script {
            name = "Restore package"
            id = "RUNNER_33"
            scriptContent = """"C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" Smartway.UiComponent.sln /t:restore"""
        }
        nuGetInstaller {
            name = "Restore package (1)"
            id = "RUNNER_23"
            toolPath = "%teamcity.tool.NuGet.CommandLine.DEFAULT%"
            projects = "Smartway.UiComponent.sln"
        }
        msBuild {
            name = "Compile"
            id = "RUNNER_26"
            path = "Smartway.UiComponent.sln"
            toolsVersion = MSBuildStep.MSBuildToolsVersion.V16_0
        }
        script {
            name = "Build Apk"
            id = "RUNNER_28"
            scriptContent = """"C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" Smartway.UiComponent.Sample.Android\Smartway.UiComponent.Sample.Android.csproj /p:Configuration=Release /t:PackageForAndroid"""
        }
        script {
            name = "Sign Apk"
            id = "RUNNER_29"
            workingDir = "Smartway.UiComponent.Sample.Android"
            scriptContent = """"%JarSignerPath%" -verbose -sigalg md5withRSA -digestalg SHA1 -keystore C:\Users\dev\Documents\zg.keystore -storepass "wcx!;:v," -keypass "wcx!;:v," -signedjar bin\Release\com.companyname.Smartway.UiComponent.Sample-signed.apk bin\Release\com.companyname.Smartway.UiComponent.Sample.apk zg_key_store"""
        }
        script {
            name = "Optimize Apk"
            id = "RUNNER_30"
            workingDir = "Smartway.UiComponent.Sample.Android"
            scriptContent = """"%ZipAlignPath%" -f -v 4 bin\Release\com.companyname.Smartway.UiComponent.Sample-signed.apk bin\Release\xamarin-ui-sample.apk"""
        }
    }

    features {
        feature {
            id = "JetBrains.AssemblyInfo"
            type = "JetBrains.AssemblyInfo"
            param("assembly-format", "%env.Version%")
        }
    }

    requirements {
        exists("Xamarin", "RQ_1")
    }
})

object Integration_1 : GitVcsRoot({
    id("Integration")
    name = "Integration"
    url = "git@github.com:ZeroGachis/xamarin-ui.git"
    branch = "refs/heads/master"
    branchSpec = """
        -:<default>
        +:refs/heads/release/*
        +:refs/heads/hotfix/*
    """.trimIndent()
    agentCleanPolicy = GitVcsRoot.AgentCleanPolicy.ALWAYS
    authMethod = uploadedKey {
        uploadedKey = "zgBrocoli"
    }
})

object PullRequest_1 : GitVcsRoot({
    id("PullRequest")
    name = "Pull Request"
    url = "git@github.com:ZeroGachis/xamarin-ui.git"
    branch = "refs/heads/master"
    branchSpec = """
        -:<default>
        +:refs/pull/*/merge
    """.trimIndent()
    agentCleanPolicy = GitVcsRoot.AgentCleanPolicy.ALWAYS
    authMethod = uploadedKey {
        uploadedKey = "zgBrocoli"
    }
})
