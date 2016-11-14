using DreamTeam.Xamarin.Firebase.Core;
using DreamTeam.Xamarin.FirebaseAuth;


namespace DreamTeam.Xamarin.Firebase.Auth
{
    public static class ___DreamTeam_Xamarin_Firebase_Auth
    {
        static ___DreamTeam_Xamarin_Firebase_Auth()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_Firebase_Core.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_FirebaseAuth.DontLooseMeDuringBuild();

        }
    }
}

namespace ApiDefinitions
{
	partial class Messaging
	{
		static Messaging()
		{
			DreamTeam.Xamarin.Firebase.Auth.___DreamTeam_Xamarin_Firebase_Auth.DontLooseMeDuringBuild();
		}
	}
}
