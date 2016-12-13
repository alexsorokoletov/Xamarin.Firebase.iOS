using DreamTeam.Xamarin.FirebaseCore;
using DreamTeam.Xamarin.FirebaseInstanceID;
using DreamTeam.Xamarin.GoogleInterchangeUtilities;
using DreamTeam.Xamarin.GoogleSymbolUtilities;
using DreamTeam.Xamarin.GoogleToolboxForMac.NSData_zlib;


namespace DreamTeam.Xamarin.FirebaseAnalytics
{
    public static class ___DreamTeam_Xamarin_FirebaseAnalytics
    {
        static ___DreamTeam_Xamarin_FirebaseAnalytics()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_FirebaseCore.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_FirebaseInstanceID.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_GoogleInterchangeUtilities.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_GoogleSymbolUtilities.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_GoogleToolboxForMac_NSData_zlib.DontLooseMeDuringBuild();

        }
    }
}

namespace ApiDefinitions
{
	partial class Messaging
	{
		static Messaging()
		{
			DreamTeam.Xamarin.FirebaseAnalytics.___DreamTeam_Xamarin_FirebaseAnalytics.DontLooseMeDuringBuild();
		}
	}
}
