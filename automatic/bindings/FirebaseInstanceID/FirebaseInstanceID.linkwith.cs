using ObjCRuntime;
[assembly: LinkWith ("FirebaseInstanceID.a", 
Frameworks = "AddressBook",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
