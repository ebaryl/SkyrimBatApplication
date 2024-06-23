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
        public static string PathModsDirectory = "D:\\Games\\Mods\\MO2\\Skyrim Special Edition\\Mods\\";
        public static string PathProfileDirectory = "";
        public static string PathPluginsTxtFile = "";
        //string? parentDirectory = Directory.GetParent(Program.PathProfileDirectory)?.FullName;
        public static string ChoosenGame = "";
        public static string ModOrganizer = "";
        public static int GameFlagsByte;

        private static void ExecuteOrderCheck()
        {
            Utility.ReadFromPlugin();
        }
        private static void ExecuteClassification()
        {
            Utility.ClassifyPlugins(Utility.plugins, PathModsDirectory);
        }
    }
}