using DreamTeam.Xamarin.FirebaseAnalytics;


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
