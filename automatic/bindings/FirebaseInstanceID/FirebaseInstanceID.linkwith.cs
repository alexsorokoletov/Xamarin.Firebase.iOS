using ObjCRuntime;
[assembly: LinkWith ("FirebaseInstanceID.framework", 
Frameworks = "AddressBook",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
