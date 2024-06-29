namespace SkyrimBatApplication
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public static string PathGameDirectory = "";
        public static string PathModsDirectory = "";
        public static string PathProfileDirectory = "";
        public static string PathPluginsTxtFile = "";
        public static string ChoosenGame = "";
        public static string ModOrganizer = "";
        public static int GameFlagsByte;
        public static bool testMode = false;
        public static List<string> foldersToSkip = new List<string> { "backup" };
    }
}