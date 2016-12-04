using DreamTeam.Xamarin.GoogleAppUtilities;
using DreamTeam.Xamarin.GTMOAuth2;
using DreamTeam.Xamarin.GTMSessionFetcher.Core;
using DreamTeam.Xamarin.GoogleToolboxForMac.NSDictionary_URLArguments;


namespace DreamTeam.Xamarin.GoogleSignIn
{
    public static class ___DreamTeam_Xamarin_GoogleSignIn
    {
        static ___DreamTeam_Xamarin_GoogleSignIn()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_GoogleAppUtilities.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_GTMOAuth2.DontLooseMeDuringBuild();
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
			DreamTeam.Xamarin.GoogleSignIn.___DreamTeam_Xamarin_GoogleSignIn.DontLooseMeDuringBuild();
		}
	}
}
