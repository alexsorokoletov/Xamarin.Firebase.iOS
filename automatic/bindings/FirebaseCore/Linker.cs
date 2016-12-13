using DreamTeam.Xamarin.GoogleInterchangeUtilities;
using DreamTeam.Xamarin.GoogleToolboxForMac.NSData_zlib;


namespace DreamTeam.Xamarin.FirebaseCore
{
    public static class ___DreamTeam_Xamarin_FirebaseCore
    {
        static ___DreamTeam_Xamarin_FirebaseCore()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_GoogleInterchangeUtilities.DontLooseMeDuringBuild();
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
			DreamTeam.Xamarin.FirebaseCore.___DreamTeam_Xamarin_FirebaseCore.DontLooseMeDuringBuild();
		}
	}
}
