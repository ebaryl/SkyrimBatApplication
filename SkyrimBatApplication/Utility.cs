using System;
using System.Collections.Generic;
using System.IO;

namespace SkyrimBatApplication
{
    public class Utility
    {
        public static List<Plugin> plugins = new List<Plugin>();

        public static void ReadFromPlugin()
        {
            var lines = File.ReadAllLines(Program.PathPluginsTxtFile);
            int order = 0;

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    string pluginName = line.Trim().TrimStart('*');
                    plugins.Add(new Plugin
                    {
                        Name = pluginName,
                        LoadOrder = order++,
                        //IsLight = false // czy powinno byc jakies default value?? najlpeije null zeby bylo wiadomo jesli cos sie nie dodalo
                    });
                }
            }
        }

        public static void SortPluginsAfterClassification(List<Plugin> plugins)
        {
            int heavyOrder = 15;
            int lightOrder = 64;

            foreach (var plugin in plugins)
            {
                if (plugin.IsLight)
                {
                    plugin.Index = lightOrder.ToString("X3");
                    lightOrder++;
                }
                else
                {
                    plugin.Index = heavyOrder.ToString("X2");
                    heavyOrder++;
                }
            }
        }

        public static void FindProfileDirectory()
        {
            string profilesDirectory = "";
            if (Program.ModOrganizer == "Mod Organizer")
            {
                string? parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;

                string testDirectory = "C:\\Users\\Bartosz\\VSProjects\\repos\\SkyrimBatApplication\\SkyrimBatApplication\\";
                parentDirectory = Directory.GetParent(testDirectory).FullName;

                if (parentDirectory == null)
                {
                    //LOG
                    return;
                }
                profilesDirectory = Path.Combine(parentDirectory, "profiles");
                if (!Directory.Exists(profilesDirectory))
                {
                    //LOG
                    return;
                }
            }
            else if (Program.ModOrganizer == "Vortex")
            {
                // NIE WIEM JAK ZNALEZC FOLDER
                string appDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                profilesDirectory = Path.Combine(appDataRoamingPath, "Roaming", Program.ChoosenGame, "profiles");

                if (!Path.Exists(profilesDirectory)) { return; }


            }
            var directories = Directory.GetDirectories(profilesDirectory);

            var latestModifiedDirectory = directories
                .Select(d => new DirectoryInfo(d))
                .OrderByDescending(d => d.LastWriteTime)
                .FirstOrDefault();

            if (latestModifiedDirectory != null)
            {
                Program.PathPluginsTxtFile = Path.Combine(latestModifiedDirectory.FullName, "plugins.txt");
            }
            else
            {
                return;
                //Console.WriteLine("No profiles found.");
            }
        }
        public static bool IdentifyGame()
        {
            if (File.Exists(Path.Combine(Program.PathGameDirectory, "TESV.exe")))
            {
                Program.ChoosenGame = "skyrim";
                return true;
            }
            else if (File.Exists(Path.Combine(Program.PathGameDirectory, "SkyrimSE.exe")))
            {
                Program.ChoosenGame = "skyrimse";
                return true;
            }
            else if (File.Exists(Path.Combine(Program.PathGameDirectory, "Fallout4.exe")))
            {
                Program.ChoosenGame = "fallout";
                return true;
            }

            return false;
            /*
            if (!Directory.Exists(Program.PathGameDirectory))
            {
                throw new DirectoryNotFoundException("The specified folder does not exist.");
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "TESV.exe", "Skyrim"},
                { "SkyrimSE.exe", "Skyrim SE"},
                { "Fallout4.exe",  "Fallout 4"}
            };

            string[] executableNames = { "TESV.exe", "SkyrimSE.exe", "Fallout4.exe" };
            string[] gameNames = { "Skyrim", "Skyrim SE", "Fallout 4" };

            for (int i = 0; i < executableNames.Length; i++)
            {
                if (File.Exists(Path.Combine(Program.PathGameDirectory, executableNames[i])))
                {
                    //return gameNames[i];
                    Program.ChoosenGame = gameNames[i];
                }
            }
            */

            //throw new FileNotFoundException("No recognized game executable found in the specified folder.");
        }
        public static void RecognizeModOrganizer()
        {
            var lines = File.ReadAllLines(Program.PathPluginsTxtFile);
            var firstLine = lines[0];
            if (firstLine.Contains("Mod Organizer", StringComparison.OrdinalIgnoreCase))
            {
                Program.ModOrganizer = "Mod Organizer";
            }
            else if (firstLine.Contains("Vortex", StringComparison.OrdinalIgnoreCase))
            {
                Program.ModOrganizer = "Vortex";
            }
        }

        public static void FindLatestModifiedProfileDirectory()
        {
            //string? parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            string? parentDirectory = Directory.GetParent(Program.PathProfileDirectory)?.FullName;
            if (parentDirectory == null) { return; }

            var directories = Directory.GetDirectories(parentDirectory);

            var latestModifiedDirectory = directories
                .Select(d => new DirectoryInfo(d))
                .OrderByDescending(d => d.LastWriteTime)
                .FirstOrDefault();

            if (latestModifiedDirectory != null)
            {
                Program.PathPluginsTxtFile = Path.Combine(latestModifiedDirectory.FullName, "plugins.txt");
            }
            else
            {
                return;
                //Console.WriteLine("No profiles found.");
            }

        }

        public static bool LightFlagCheck(string filepath)
        {
            using (var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                byte[] header = new byte[10];

                if (fileStream.Read(header, 0, header.Length) < header.Length)
                {
                    throw new InvalidDataException("File is too small to contain a valid header.");
                }

                byte flagsByte = header[9];
                bool isLight = (flagsByte & Program.GameFlagsByte) != 0;
                //Console.WriteLine("             FLAGBYTE:" + flagsByte);
                //Console.WriteLine("LIGHT" + isLight);
                return isLight;
            }
        }

        public static void ClassifyPlugins(List<Plugin> plugins, string pluginsDirectory)
        {
            var allDirectories = Directory.GetDirectories(pluginsDirectory, "*", SearchOption.TopDirectoryOnly);

            foreach (var plugin in plugins)
            {
                foreach (var dir in allDirectories)
                {
                    string pluginPath = Path.Combine(dir, plugin.Name);
                    if (File.Exists(pluginPath))
                    {
                        //znajdz ten plugin z obiektow klasy
                        //var searchedPlugin = Utility.plugins.FirstOrDefault(p => p.Name == plugin.Name);
                        //searchedPlugin.IsLight = LightFlagCheck(pluginPath);
                        plugin.IsLight = LightFlagCheck(pluginPath);
                        break; // Exit the loop once the plugin is found
                    }
                }
            }
        }
    }
}