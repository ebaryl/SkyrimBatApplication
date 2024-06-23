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
            var lines = File.ReadAllLines(Program.PathPluginsTxtDirectory);
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
                Program.PathPluginsTxtDirectory = Path.Combine(latestModifiedDirectory.FullName, "plugins.txt");
            }
            else
            {
                return;
                //Console.WriteLine("No profiles found.");
            }
        }
        public static void FindLatestModifiedProfileDirectory()
        {
            string? parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            if (parentDirectory == null) { return; }

            var directories = Directory.GetDirectories(parentDirectory);

            var latestModifiedDirectory = directories
                .Select(d => new DirectoryInfo(d))
                .OrderByDescending(d => d.LastWriteTime)
                .FirstOrDefault();

            if (latestModifiedDirectory != null)
            {
                Program.PathPluginsTxtDirectory = Path.Combine(latestModifiedDirectory.FullName, "plugins.txt");
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