﻿#if UNITY_IPHONE || UNITY_STANDALONE_OSX
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;


public class BL_BuildPostProcess
{

    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget == BuildTarget.iOS)
        {
#if UNITY_IPHONE
            LinkLibraries(path);
            UpdatePermission(path + "/Info.plist");
#endif
        }
        else if (buildTarget == BuildTarget.StandaloneOSX)
        {
            string plistPath = path + "/Contents/Info.plist"; // straight to a binary
            if (path.EndsWith(".xcodeproj"))
            {
                // This must be a build that exports Xcode
                string dir = Path.GetDirectoryName(path);
                plistPath = dir + "/" + PlayerSettings.productName + "/Info.plist";
            }
            UpdatePermission(plistPath);
        }
    }
#if UNITY_IPHONE
    static string GetTargetGuid(PBXProject proj)
    {
#if UNITY_2019_3_OR_NEWER
        return proj.GetUnityFrameworkTargetGuid();
#else
	    return proj.TargetGuidByName("Unity-iPhone");
#endif
    }
    // The followings are the addtional frameworks to add to the project
    static string[] ProjectFrameworks = new string[] {
        "Accelerate.framework",
        "CoreTelephony.framework",
        "CoreText.framework",
        "CoreML.framework",
        "Metal.framework",
        "VideoToolbox.framework",
        "libiPhone-lib.a",
        "libresolv.tbd",
    };

    public static void LinkLibraries(string path)
    {
        string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(projPath);
        string target = GetTargetGuid(proj);


        // embedded frameworks
#if UNITY_2019_1_OR_NEWER
        target = proj.GetUnityMainTargetGuid();
#endif
        const string defaultLocationInProj = "ChatSDK/Plugins/iOS";

        const string HypheanteChatFrameworkName = "HyphenateChat.framework";

        string HypheanteChatFrameworkPath = Path.Combine(defaultLocationInProj, HypheanteChatFrameworkName);

        string fileGuid = proj.AddFile(HypheanteChatFrameworkPath, "Frameworks/" + HypheanteChatFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        proj.SetBuildProperty(target, "LD_RUNPATH_SEARCH_PATHS", "$(inherited) @executable_path/Frameworks");

        // done, write to the project file
        File.WriteAllText(projPath, proj.WriteToString());
    }
#endif

    /// <summary>
    ///   Update the permission 
    /// </summary>
    /// <param name="pListPath">path to the Info.plist file</param>
    static void UpdatePermission(string pListPath)
    {
        //PlistDocument plist = new PlistDocument();
        //plist.ReadFromString(File.ReadAllText(pListPath));
        //PlistElementDict rootDic = plist.root;
        //var micPermission = "NSMicrophoneUsageDescription";
        //rootDic.SetString(micPermission, "need to user mic");
        //File.WriteAllText(pListPath, plist.WriteToString());
    }
}
#endif
