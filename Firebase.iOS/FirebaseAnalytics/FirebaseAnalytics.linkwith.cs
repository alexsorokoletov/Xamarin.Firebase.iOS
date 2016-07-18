// WARNING: This feature is deprecated. Use the "Native References" folder instead.
// Right-click on the "Native References" folder, select "Add Native Reference",
// and then select the static library or framework that you'd like to bind.
//
// Once you've added your static library or framework, right-click the library or
// framework and select "Properties" to change the LinkWith values.

/*
 -ObjC -l"c++" -l"sqlite3" -l"z" -framework "AdSupport" -framework "AddressBook" -framework "CoreGraphics" -framework "FirebaseAnalytics" -framework "FirebaseInstanceID" -framework "GoogleInterchangeUtilities" -framework "GoogleSymbolUtilities" -framework "GoogleUtilities" -framework "SafariServices" -framework "StoreKit" -framework "SystemConfiguration"
 */

//FirebaseAnalytics FirebaseInstanceID GoogleInterchangeUtilities GoogleSymbolUtilities GoogleUtilities
using ObjCRuntime;
[assembly: LinkWith ("FirebaseAnalytics.a",
                     Frameworks = "AddressBook AdSupport SafariServices StoreKit SystemConfiguration Foundation", LinkerFlags = "-lc++ -lsqlite3 -lz -ObjC", IsCxx = true, 
                     SmartLink = true, ForceLoad = true)]
