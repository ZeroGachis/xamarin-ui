import jetbrains.buildServer.configs.kotlin.v2019_2.*
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.MSBuildStep
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.msBuild
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.nuGetInstaller
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

    vcsRoot(Settings)

    buildType(Build)

    template(Template_1)
}

object Build : BuildType({
    name = "Build"

    params {
        param("system.JavaSdkDirectory", "%JavaSdkPath%")
        param("JavaSdkPath", """C:\Program Files\Android\jdk\microsoft_dist_openjdk_1.8.0.25""")
        select("system.Configuration", "Release", label = "Build Configuration",
                options = listOf("ReleaseDesktop", "DebugDesktop", "ReleaseWince", "DebugWince", "Release"))
        param("JarSignerPath", """%JavaSdkPath%\bin\jarsigner.exe""")
        param("ZipAlignPath", """C:\Program Files (x86)\Android\android-sdk\build-tools\28.0.3\zipalign.exe""")
    }

    vcs {
        root(DslContext.settingsRoot)
    }

    steps {
        nuGetInstaller {
            name = "Restore"
            toolPath = "%teamcity.tool.NuGet.CommandLine.DEFAULT%"
            projects = "Smartway.UiComponent.sln"
        }
        msBuild {
            name = "Build"
            path = "Smartway.UiComponent.sln"
            toolsVersion = MSBuildStep.MSBuildToolsVersion.V16_0
        }
        msBuild {
            name = "Build Apk"
            path = "Smartway.UiComponent.Sample.Android/Smartway.UiComponent.Sample.Android.csproj"
            toolsVersion = MSBuildStep.MSBuildToolsVersion.V16_0
            targets = "PackageForAndroid"
        }
        script {
            name = "Sign Apk"
            workingDir = "Smartway.UiComponent.Sample.Android"
            scriptContent = """"%JarSignerPath%" -verbose -sigalg md5withRSA -digestalg SHA1 -keystore C:\Users\dev\Documents\zg.keystore -storepass "wcx!;:v," -keypass "wcx!;:v," -signedjar bin\Release\com.companyname.Smartway.UiComponent.Sample-signed.apk bin\Release\com.companyname.Smartway.UiComponent.Sample.apk zg_key_store"""
        }
        script {
            name = "Optimize Apk"
            workingDir = "Smartway.UiComponent.Sample.Android"
            scriptContent = """"%ZipAlignPath%" -f -v 4 bin\Release\com.companyname.Smartway.UiComponent.Sample-signed.apk bin\Release\xamarin-ui-sample.apk"""
        }
    }

    triggers {
        vcs {
        }
    }

    requirements {
        exists("Xamarin")
    }
})

object Template_1 : Template({
    id("Template")
    name = "Template"
})

object Settings : GitVcsRoot({
    name = "Settings"
    url = "git@github.com:ZeroGachis/xamarin-ui-teamcity.git"
    branch = "master"
    authMethod = uploadedKey {
        userName = "git"
        uploadedKey = "zgBrocoli"
    }
})
