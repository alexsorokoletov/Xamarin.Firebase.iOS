// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FirebaseTestApp
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.NSLayoutConstraint SignWithGoogleButton { get; set; }


        [Action ("OnGoogleSignInClick:")]
        partial void OnGoogleSignInClick (Foundation.NSObject sender);

        [Action ("UIButton3_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton3_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (SignWithGoogleButton != null) {
                SignWithGoogleButton.Dispose ();
                SignWithGoogleButton = null;
            }
        }
    }
}