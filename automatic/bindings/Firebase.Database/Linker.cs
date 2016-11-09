using DreamTeam.Xamarin.Firebase.Core;
using DreamTeam.Xamarin.FirebaseDatabase;


namespace DreamTeam.Xamarin.Firebase.Database
{
    public static class ___DreamTeam_Xamarin_Firebase_Database
    {
        static ___DreamTeam_Xamarin_Firebase_Database()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_Firebase_Core.DontLooseMeDuringBuild();
            ___DreamTeam_Xamarin_FirebaseDatabase.DontLooseMeDuringBuild();

        }
    }
}

namespace ApiDefinitions
{
	partial class Messaging
	{
		static Messaging()
		{
			DreamTeam.Xamarin.Firebase.Database.___DreamTeam_Xamarin_Firebase_Database.DontLooseMeDuringBuild();
		}
	}
}
