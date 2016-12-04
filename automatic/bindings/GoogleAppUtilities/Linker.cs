using DreamTeam.Xamarin.GoogleSymbolUtilities;


namespace DreamTeam.Xamarin.GoogleAppUtilities
{
    public static class ___DreamTeam_Xamarin_GoogleAppUtilities
    {
        static ___DreamTeam_Xamarin_GoogleAppUtilities()
        {
            DontLooseMeDuringBuild();
        }

        public static void DontLooseMeDuringBuild()
        {
            ___DreamTeam_Xamarin_GoogleSymbolUtilities.DontLooseMeDuringBuild();

        }
    }
}

namespace ApiDefinitions
{
	partial class Messaging
	{
		static Messaging()
		{
			DreamTeam.Xamarin.GoogleAppUtilities.___DreamTeam_Xamarin_GoogleAppUtilities.DontLooseMeDuringBuild();
		}
	}
}
