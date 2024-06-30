using Bat_Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkyrimBatApplication
{
    public class Utility
    {
        public static List<Plugin> plugins = new List<Plugin>();

        public static bool IdentifyGame(string path)
        {
            if (File.Exists(Path.Combine(path, "TESV.exe")))
            {
                Program.ChoosenGame = "skyrim";
                Program.GameFlagsByte = 0x02;
                return true;
            }
            else if (File.Exists(Path.Combine(path, "SkyrimSE.exe")))
            {
                Program.ChoosenGame = "skyrimse";
                Program.GameFlagsByte = 0x02;
                return true;
            }
            else if (File.Exists(Path.Combine(path, "Fallout4.exe")))
            {
                Program.ChoosenGame = "fallout";
                Program.GameFlagsByte = 0x04;
                return true;
            }

            return false;
        }

        public static bool IdentifyGameInstalledFromModOrganizer()
        {
            string currentPath = Directory.GetCurrentDirectory().GetParentDirectory(1);
            DirectoryInfo currentDir = new DirectoryInfo(currentPath);

            bool skyrimFound = currentDir.Parent?.Name.Equals("Skyrim", StringComparison.OrdinalIgnoreCase) == true;
            bool skyrimseFound = currentDir.Parent?.Name.Equals("Skyrim Special Edition", StringComparison.OrdinalIgnoreCase) == true;
            bool fallout4Found = currentDir.Parent?.Name.Equals("Fallout 4", StringComparison.OrdinalIgnoreCase) == true;
            bool fallout3Found = currentDir.Parent?.Name.Equals("Fallout 3", StringComparison.OrdinalIgnoreCase) == true;
            bool isCorrectStructure = currentDir.Name.Equals("data", StringComparison.OrdinalIgnoreCase) == true;

            if (skyrimFound || skyrimseFound)
            {
                Program.ChoosenGame = skyrimFound ? "skyrim" : "skyrimse";
                Program.GameFlagsByte = 0x02;
            }
            else if (fallout3Found || fallout4Found)
            {
                Program.ChoosenGame = "fallout";
                Program.GameFlagsByte = 0x04;
            }
            else
            {
                Program.ChoosenGame = "game not found";
            }

            if (isCorrectStructure && (skyrimFound || skyrimseFound || fallout3Found || fallout4Found))
            {
                Program.PathGameDirectory = currentPath.GetParentDirectory(1);
                Program.PathModsDirectory = currentPath;
            }
            if (Program.ChoosenGame != "") { return true; }
            return false;
            
        }

        public static void IdentifyModOrganizerFromBrowser()
        {
            var lines = File.ReadAllLines(Program.PathPluginsTxtFile);
            var firstLine = lines[0];
            if (firstLine.Contains("Mod Organizer", StringComparison.OrdinalIgnoreCase)) {
                Program.ModOrganizer = "Mod Organizer";
            }
            else if (firstLine.Contains("Vortex", StringComparison.OrdinalIgnoreCase)) {
                Program.ModOrganizer = "Vortex";
            }
            else {
                Program.ModOrganizer = "Other";
            }
        }

        public static bool IdentifyModOrganizerFromModsStagingFolder()
        {
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "__vortex_staging_folder")))
            {
                Program.ModOrganizer = "Vortex";
                return true;
            }
            else
            {
                string grandParentDirectory = Directory.GetCurrentDirectory().GetParentDirectory(4); //
                if (grandParentDirectory != null &&
                    Directory.Exists(Path.Combine(grandParentDirectory, "profiles")) &&
                    Directory.Exists(Path.Combine(grandParentDirectory, "overwrite")) &&
                    Directory.Exists(Path.Combine(grandParentDirectory, "mods")))
                {
                    Program.ModOrganizer = "Mod Organizer";
                    return true;
                }
                else { return false; }
            }
        }

        public static bool FindModsDirectory()
        {
            if (Program.ModOrganizer == null) { return false; }
            else
            {
                string grandParentDirectory = Path.Combine(Directory.GetCurrentDirectory().GetParentDirectory(4), "mods"); //
                if (Directory.Exists(grandParentDirectory) && CheckForPluginsInside(grandParentDirectory))
                {
                    Program.PathModsDirectory = grandParentDirectory;
                    return true;
                }
                else { return false; }
            }
        }

        public static bool CheckForPluginsInside(string startDirectory)
        {
            string[] extensions = { "*.esp", "*.esm", "*.esl" };

            foreach (string extension in extensions)
            {
                string[] files = Directory.GetFiles(startDirectory, extension);
                if (files.Length > 0)
                {
                    return true;
                }
            }

            string[] subDirectories = Directory.GetDirectories(startDirectory);
            foreach (string subDir in subDirectories)
            {
                foreach (string extension in extensions)
                {
                    string[] files = Directory.GetFiles(subDir, extension);
                    if (files.Length > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void FindProfileDirectory()
        {
            string profilesDirectory = "";
            if (Program.ModOrganizer == "Mod Organizer")
            {
                string directory = Directory.GetCurrentDirectory().GetParentDirectory(4); //
                profilesDirectory = Path.Combine(directory, "profiles");
                if (!Directory.Exists(profilesDirectory)) { return; }

                Program.PathProfileDirectory = profilesDirectory;
                FindLatestModifiedProfileDirectory(0);
            }
            else if (Program.ModOrganizer == "Vortex")
            {
                string appDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                profilesDirectory = Path.Combine(appDataRoamingPath, "Roaming", Program.ChoosenGame, "profiles");

                if (!Path.Exists(profilesDirectory)) { return; }

                FindLatestModifiedProfileDirectory(0);
            }
        }

        public static void FindLatestModifiedProfileDirectory(int depth)
        {
            string? parentDirectory = Program.PathProfileDirectory.GetParentDirectory(depth);
            if (parentDirectory == null) { return; }

            var directories = Directory.GetDirectories(parentDirectory);

            var latestModifiedDirectory = directories
                .Select(d => new DirectoryInfo(d))
                .OrderByDescending(d => d.LastWriteTime)
                .FirstOrDefault();

            string pluginsPath = Path.Combine(latestModifiedDirectory.FullName, "plugins.txt");
            string loadorderPath = Path.Combine(latestModifiedDirectory.FullName, "loadorder.txt");

            if (latestModifiedDirectory != null && File.Exists(pluginsPath) && File.Exists(loadorderPath))
            {
                Program.PathProfileDirectory = latestModifiedDirectory.FullName;
                Program.PathPluginsTxtFile = pluginsPath;
                Program.PathLoadOrderTxtFile = loadorderPath;
            }
            else { return; }
        }

        public static void RemoveOldBats(string path)
        {
            string[] bats = Directory.GetFiles(path, ".txt");
            {
                foreach (string bat in bats)
                {
                    string[] lines = File.ReadAllLines(bat);
                    if (lines[0].Contains("#Bat Manager"))
                    {
                        File.Delete(Path.Combine(path, bat));
                    }
                }
            }
        }

        public static bool InstalledByModOrganizer()
        {
            string installationDirectory = Path.GetFullPath(Directory.GetCurrentDirectory());
            string gamePath = Path.GetFullPath(Program.PathGameDirectory);
            return installationDirectory.StartsWith(gamePath, StringComparison.OrdinalIgnoreCase);
        }

        // NOT USED, GOAL WAS TO FIND BATS FROM MODS FOLDER
        public static void TxtMoveToDirectory(string directoryPath)
        {
            Regex hexRegex = new Regex(@"^[0-9A-F]{8}$");
            string[] subDirectories = Directory.GetDirectories(directoryPath);
            string[] files = Directory.GetFiles(directoryPath, "*.txt");


            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    var words = line.Split(' ');
                    foreach (string word in words)
                    {
                        if (word.Length == 8 && hexRegex.IsMatch(word))
                        {
                            string fileName = Path.GetFileName(file);
                            string directoryForBatsFromMods = Path.Combine(Directory.GetCurrentDirectory(), "mods");
                            string destFilePath = Path.Combine(directoryForBatsFromMods, fileName);
                            // Copy the file
                            File.Copy(file, destFilePath, true);
                        }
                    }
                }
            }
        }

        public static void ReadLoadOrderFromFiles()
        {
            var loadOrderLines = File.ReadAllLines(Program.PathLoadOrderTxtFile);
            var pluginsLines = File.ReadAllLines(Program.PathPluginsTxtFile);
            int linesDifference = loadOrderLines.Length - pluginsLines.Length + 1;
            int order = 0;

            for (int i = 1; i < linesDifference; i++)
            {
                if (!string.IsNullOrWhiteSpace(loadOrderLines[i]) && !loadOrderLines[i].StartsWith("#"))
                {
                    string pluginName = loadOrderLines[i].Trim().TrimStart('*');
                    plugins.Add(new Plugin
                    {
                        Name = pluginName,
                        LoadOrder = order++,
                    });
                }
            }

            foreach (var line in pluginsLines)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#") && line.StartsWith("*"))
                {
                    string pluginName = line.Trim().TrimStart('*');
                    plugins.Add(new Plugin
                    {
                        Name = pluginName,
                        LoadOrder = order++,
                    });
                }
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
                return isLight;
            }
        }

        public static void ClassifyPlugins(List<Plugin> plugins)
        {
            Parallel.ForEach(plugins, new ParallelOptions() { MaxDegreeOfParallelism = 8 }, (plugin) =>
            {
                string dataPath = Path.Combine(Program.PathGameDirectory, "data", plugin.Name);
                if (File.Exists(dataPath))
                {
                    plugin.IsLight = LightFlagCheck(dataPath);
                    return;
                }

                var allDirectories = Directory.GetDirectories(Program.PathModsDirectory, "*");

                foreach (var dir in allDirectories)
                {
                    string pluginPath = Path.Combine(dir, plugin.Name);
                    if (File.Exists(pluginPath))
                    {
                        plugin.IsLight = LightFlagCheck(pluginPath);
                        break;
                    }
                }
            });
        }

        public static void SortPluginsAfterClassification(List<Plugin> plugins)
        {
            //int heavyOrder = 15;
            //int lightOrder = 64;
            int heavyOrder = 0;
            int lightOrder = 0;

            foreach (var plugin in plugins)
            {
                string name = plugin.Name;
                if (plugin.IsLight)
                {
                    plugin.Index = lightOrder.ToString("X3");
                    lightOrder++;
                }
                else if (!plugin.IsLight)
                {
                    plugin.Index = heavyOrder.ToString("X2");
                    heavyOrder++;
                }
            }
        }

        
    }
}