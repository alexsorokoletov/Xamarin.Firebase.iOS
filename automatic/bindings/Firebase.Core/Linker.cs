using DreamTeam.Xamarin.FirebaseAnalytics;
using DreamTeam.Xamarin.FirebaseCore;


namespace DreamTeam.Xamarin.Firebase.Core
{
    public static class ___DreamTeam_Xamarin_Firebase_Core
    {
        static ___DreamTeam_Xamarin_Firebase_Core()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_FirebaseAnalytics.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_FirebaseCore.DontLooseMeDuringBuild();

        }
    }
}

namespace ApiDefinitions
{
	partial class Messaging
	{
		static Messaging()
		{
			DreamTeam.Xamarin.Firebase.Core.___DreamTeam_Xamarin_Firebase_Core.DontLooseMeDuringBuild();
		}
	}
}
