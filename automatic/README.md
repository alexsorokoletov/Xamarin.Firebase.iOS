## Automatic way of binding Firebase pods for Xamarin iOS
The tool provides "automatic" way to bind all the pods for Firebase iOS for Xamarin

### How to use
If on Mono, run `mozroots --import --sync` to import SSL root certificates.

Then run `sh bind.sh POD=FirebaseDatabase` or use other pod names (see here https://firebase.google.com/docs/ios/setup in _Available Pods_ section)