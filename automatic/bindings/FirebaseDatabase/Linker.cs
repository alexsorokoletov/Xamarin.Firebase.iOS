using DreamTeam.Xamarin.FirebaseAnalytics;
using DreamTeam.Xamarin.FirebaseCore;

namespace DreamTeam.Xamarin.FirebaseDatabase
{
    public static class ___DreamTeam_Xamarin_FirebaseDatabase
    {
        static ___DreamTeam_Xamarin_FirebaseDatabase()
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
			DreamTeam.Xamarin.FirebaseDatabase.___DreamTeam_Xamarin_FirebaseDatabase.DontLooseMeDuringBuild();
		}
	}
}
