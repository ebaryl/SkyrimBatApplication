using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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

                if (parentDirectory == null) { return; }

                profilesDirectory = Path.Combine(parentDirectory, "profiles");
                if (!Directory.Exists(profilesDirectory)) { return; }

                Program.PathProfileDirectory = profilesDirectory;
            }
            else if (Program.ModOrganizer == "Vortex")
            {
                string appDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                profilesDirectory = Path.Combine(appDataRoamingPath, "Roaming", Program.ChoosenGame, "profiles");

                if (!Path.Exists(profilesDirectory)) { return; }

                Program.PathProfileDirectory = profilesDirectory;
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
            }
        }

        public static bool FindModsDirectory()
        {
            if (Program.ModOrganizer == null) { return false; }
            else
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                if (CheckForPluginsInside(currentDirectory))
                {   Program.PathModsDirectory = currentDirectory;
                    return true;
                }
                else { return false; }
            }
        }

        public static bool CheckForPluginsInside(string startDirectory)
        {
            string currentDirectory = startDirectory;

            string[] files = Directory.GetFiles(currentDirectory, "*.es[pml]", SearchOption.TopDirectoryOnly);

            if (files.Length > 0)
            {
                return true;
            }
            else { return false; }
        }

        public static bool IdentifyGame()
        {
            if (File.Exists(Path.Combine(Program.PathGameDirectory, "TESV.exe")))
            {
                Program.ChoosenGame = "skyrim";
                Program.GameFlagsByte = 0x02;
                return true;
            }
            else if (File.Exists(Path.Combine(Program.PathGameDirectory, "SkyrimSE.exe")))
            {
                Program.ChoosenGame = "skyrimse";
                Program.GameFlagsByte = 0x02;
                return true;
            }
            else if (File.Exists(Path.Combine(Program.PathGameDirectory, "Fallout4.exe")))
            {
                Program.ChoosenGame = "fallout";
                Program.GameFlagsByte = 0x04;
                return true;
            }

            return false;
        }
        public static void IdentifyModOrganizerFromBrowser()
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
            //
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
                string? parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
                if (parentDirectory != null &&
                    Directory.Exists(Path.Combine(parentDirectory, "profiles")) &&
                    Directory.Exists(Path.Combine(parentDirectory, "overwrite")) &&
                    Directory.Exists(Path.Combine(parentDirectory, "mods")))
                {
                    Program.ModOrganizer = "Mod Organizer";
                    return true;
                }
                else { return false; }
            }
        }

        // NOT USED, GOAL WAS TO FIND BATS FROM MODS FOLDER
        public static void TxtMoveToDirectory(string directoryPath)
        {
            Regex hexRegex = new Regex(@"^[0-9A-F]{8}$");
            string[] files = Directory.GetFiles(directoryPath, "*.txt", SearchOption.TopDirectoryOnly);

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
            var allDirectories = Directory.GetDirectories(pluginsDirectory, "*", SearchOption.TopDirectoryOnly);

            foreach (var plugin in plugins)
            {
                foreach (var dir in allDirectories)
                {
                    string pluginPath = Path.Combine(dir, plugin.Name);
                    if (File.Exists(pluginPath))
                    {
                        plugin.IsLight = LightFlagCheck(pluginPath);
                        break;
                    }
                }
            }
        }
    }
}