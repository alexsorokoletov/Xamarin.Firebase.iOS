using System;
using UIKit;
using Firebase.iOS;

namespace FirebaseTestApp
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            GIDSignIn.SharedInstance.UiDelegate = new LocalGIDSignInUIDelegate(this);
        }

        partial void OnGoogleSignInClick(Foundation.NSObject sender)
        {
            GIDSignIn.SharedInstance.SignIn();
        }

        public class LocalGIDSignInUIDelegate : GIDSignInUIDelegate
        {
            private UIViewController _root;

            public LocalGIDSignInUIDelegate(UIViewController root)
            {
                _root = root;
            }

            public override void SignInDismissViewController(GIDSignIn signIn, UIViewController viewController)
            {
                _root.DismissViewController(true, null);
            }

            public override void SignInPresentViewController(GIDSignIn signIn, UIViewController viewController)
            {
                _root.PresentViewController(viewController, true, null);
            }

            public override void SignInWillDispatch(GIDSignIn signIn, Foundation.NSError error)
            {
                //base.SignInWillDispatch(signIn, error);
            }
        }
    }
}

