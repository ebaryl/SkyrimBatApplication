using Bat_Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
            //D:\Games\Steam\steamapps\common\Skyrim Special Edition\(((data)))\BatManager
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
                // MO2\Skyrim Special Edition\mods\BatManager\BatManager\bin
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
                // MO2\Skyrim Special Edition\mods\BatManager\BatManager\bin
                //Games\Steam\steamapps\((((mods))))\Skyrim Special Edition\mods
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
            //string? parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            string? parentDirectory = Program.PathProfileDirectory.GetParentDirectory(depth);
            if (parentDirectory == null) { return; }

            var directories = Directory.GetDirectories(parentDirectory);

            var latestModifiedDirectory = directories
                .Select(d => new DirectoryInfo(d))
                .OrderByDescending(d => d.LastWriteTime)
                .FirstOrDefault();

            if (latestModifiedDirectory != null && File.Exists(Path.Combine(latestModifiedDirectory.FullName, "plugins.txt")))
            {
                Program.PathProfileDirectory = latestModifiedDirectory.FullName;
                Program.PathPluginsTxtFile = Path.Combine(latestModifiedDirectory.FullName, "plugins.txt");
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
            /*
            string installationDirectory = Directory.GetCurrentDirectory();
            if (installationDirectory.Contains(Program.PathGameDirectory)) { return true; }
            return false;
            */

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

        public static void ReadLoadOrderFromPlugin()
        {
            var lines = File.ReadAllLines(Program.PathPluginsTxtFile);
            int order = 0;

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#") && line.StartsWith('*'))
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

        public static void ClassifyPlugins(List<Plugin> plugins, string pluginsDirectory)
        {
            var allDirectories = Directory.GetDirectories(pluginsDirectory, "*");

            int howMuchPlugins = 0;

            foreach (var plugin in plugins)
            {
                foreach (var dir in allDirectories)
                {
                    string pluginPath = Path.Combine(dir, plugin.Name);
                    //string pluginPath = Path.Combine(pluginsDirectory, plugin.Name);
                    if (File.Exists(pluginPath))
                    {
                        howMuchPlugins++;
                        plugin.IsLight = LightFlagCheck(pluginPath);
                        break;
                    }
                }
            }

            //D:\Games\Steam\steamapps\common\Skyrim Special Edition\data\BatManager\batchFiles\testFileToFind.txt found
            //D:\Games\Steam\steamapps\common\Skyrim Special Edition\data\BatManager current
            //string? filePath = Directory.GetFiles(pluginsDirectory, "testFileToFind.txt", SearchOption.AllDirectories).FirstOrDefault();

            // Program.ModOrganizer = filePath;
            //Program.ModOrganizer = Directory.GetCurrentDirectory();
        }

        public static void SortPluginsAfterClassification(List<Plugin> plugins)
        {
            //int heavyOrder = 15;
            //int lightOrder = 64;
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

        
    }
}