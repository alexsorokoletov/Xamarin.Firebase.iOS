using System;
using DreamTeam.Xamarin.FirebaseDatabase;
using UIKit;

namespace FirebaseTestApp
{
    public partial class ViewController : UIViewController
    {
        private FIRDatabaseReference _dbReference;

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //GIDSignIn.SharedInstance.UiDelegate = new LocalGIDSignInUIDelegate(this);
            TestFirebaseDb();
        }

        private void TestFirebaseDb()
        {
            _dbReference = FIRDatabase.Database.Reference;
            _dbReference.ChildByAppendingPath("node1").ObserveEventType(FIRDataEventType.Value, (FIRDataSnapshot snapshot, Foundation.NSString someString) =>
            {
                //this will trigger on any change related to the "node1" and it's children.
                //https://firebase.google.com/docs/database/ios/read-and-write
                var data = snapshot;
                Console.WriteLine("Data changes received from Firebase");

            }, (Foundation.NSError error) =>
            {
                //if you hit this point make sure you read this https://firebase.google.com/docs/database/security/quickstart
                Console.WriteLine("Error observing Database: {0}", error);
            });
        }

        partial void OnGoogleSignInClick(Foundation.NSObject sender)
        {
            //GIDSignIn.SharedInstance.SignIn();
        }

        //public class LocalGIDSignInUIDelegate : GIDSignInUIDelegate
        //{
        //    private UIViewController _root;

        //    public LocalGIDSignInUIDelegate(UIViewController root)
        //    {
        //        _root = root;
        //    }

        //    public override void SignInDismissViewController(GIDSignIn signIn, UIViewController viewController)
        //    {
        //        _root.DismissViewController(true, null);
        //    }

        //    public override void SignInPresentViewController(GIDSignIn signIn, UIViewController viewController)
        //    {
        //        _root.PresentViewController(viewController, true, null);
        //    }

        //    public override void SignInWillDispatch(GIDSignIn signIn, Foundation.NSError error)
        //    {
        //        //base.SignInWillDispatch(signIn, error);
        //    }
        //}
    }
}

