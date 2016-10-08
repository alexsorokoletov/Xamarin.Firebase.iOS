# Xamarin.Firebase.iOS
[Google Firebase](https://firebase.google.com/docs) bindings for Xamarin.iOS. This code is provided as is.

In order to use the new Firebase from Google we have to get some bindings for Xamarin apps, right?

We know Xamarin is working on them (see [here](http://stackoverflow.com/questions/37420600/can-should-i-use-firebase-with-ionic-2-or-xamarin), [here](https://forums.xamarin.com/discussion/67822/support-for-google-firebase) and [here](https://github.com/SotoiGhost/GoogleApisForiOSComponents/tree/firebase)) but it's taking longer than it should.

So here is a repo everyone can collaborate and grow the Firebase for Xamarin.iOS apps.

Firebase for Xamarin.Android is already available in Nuget. Read more [here](https://www.nuget.org/packages?q=Xamarin.Firebase).


## Contributing
I appreciate any feedback on the bindings and how to make them better. Open an issue or submit a pull request. 


## What's in there
1. [Firebase Analytics](https://firebase.google.com/docs/analytics/)
2. [Firebase Auth](https://firebase.google.com/docs/auth) (Google Sign In for now only)
3. [Firebase Realtime Database](https://firebase.google.com/docs/database/)
and a sample app.

## Running the sample.
Please create an app in the Firebase console, download `GoogleService-Info.plist` and put it in the project. 

Firebase Auth demo requires enabled Google Sign In

Firebase Database demo requires a "node1" child node in the database.


### Roadmap
1. Add as many Firebase features as possible
2. Provide this binding as a Nuget
3. Enable versioning and clearly declare which version of Firebase is used in each build
4. Configure automatic CI