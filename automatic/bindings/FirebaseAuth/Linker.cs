using DreamTeam.Xamarin.FirebaseAnalytics;
using DreamTeam.Xamarin.GTMSessionFetcher.Core;
using DreamTeam.Xamarin.GoogleToolboxForMac.NSDictionary_URLArguments;


namespace DreamTeam.Xamarin.FirebaseAuth
{
    public static class ___DreamTeam_Xamarin_FirebaseAuth
    {
        static ___DreamTeam_Xamarin_FirebaseAuth()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_FirebaseAnalytics.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_GTMSessionFetcher_Core.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_GoogleToolboxForMac_NSDictionary_URLArguments.DontLooseMeDuringBuild();

        }
    }
}

namespace ApiDefinitions
{
	partial class Messaging
	{
		static Messaging()
		{
			DreamTeam.Xamarin.FirebaseAuth.___DreamTeam_Xamarin_FirebaseAuth.DontLooseMeDuringBuild();
		}
	}
}
