using ObjCRuntime;
[assembly: LinkWith ("FirebaseDynamicLinks.a", 
Frameworks = "AssetsLibrary CoreMotion MessageUI QuartzCore",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
