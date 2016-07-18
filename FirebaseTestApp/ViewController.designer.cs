// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FirebaseTestApp
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.NSLayoutConstraint SignWithGoogleButton { get; set; }

		[Action ("OnGoogleSignInClick:")]
		partial void OnGoogleSignInClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (SignWithGoogleButton != null) {
				SignWithGoogleButton.Dispose ();
				SignWithGoogleButton = null;
			}
		}
	}
}
