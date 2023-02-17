namespace Server
{
    internal class Settings
    {
        public static bool AuthorisationRequired;
        public static string? Password;
        public static bool WhiteList;
        public static List<string> WhiteListUsers = new();

        public static void LoadSettings()
        {

        }
    }
}
