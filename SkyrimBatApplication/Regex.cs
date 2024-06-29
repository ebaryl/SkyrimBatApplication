using SkyrimBatApplication;
using Bat_Manager;
using System;
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;

public class MyRegex()
{
    public static void RegexUpdateIndexes()
    {
        string currentDirectory = Path.Combine(Directory.GetCurrentDirectory().GetParentDirectory(1), "batchFiles");
        // TEST
        if (Program.testMode) {
            currentDirectory = currentDirectory.GetParentDirectory(4);
            currentDirectory = Path.Combine(currentDirectory, "batchFiles" ,"_batchfiles");
        }

        string[] txtFiles = Directory.GetFiles(currentDirectory, "*.txt", SearchOption.AllDirectories);

        Plugin searchedPlugin = new Plugin();
        Regex hexRegex = new Regex(@"^[0-9A-F]{8}$");

        foreach (string file in txtFiles)
        {
            string[] lines = File.ReadAllLines(file);
            List<string> modifiedLines = new List<string>();

            if (!lines[0].Contains("#Bat Manager", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(lines[0])) { continue; }

            foreach (string line in lines)
            {
                if (line.StartsWith(";"))
                {
                    modifiedLines.Add(line);

                    string pluginName = line.TrimStart(';').Trim();

                    if (pluginName.Contains("#"))
                    {
                        pluginName = pluginName.Split('#')[1];
                        //[..^4] no last 4 chars
                        searchedPlugin = Utility.plugins.FirstOrDefault(p => string.Equals(p.Name[..^4], pluginName, StringComparison.OrdinalIgnoreCase))!;
                        if (searchedPlugin != null)
                        {
                            continue;
                        }
                    }
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    modifiedLines.Add("");
                    continue;
                }
                else if (searchedPlugin != null)
                {
                    var words = line.Split(' ');
                    List<string> modifiedWords = new List<string>();
                    foreach (string word in words)
                    {
                        if (word.Length == 8 && hexRegex.IsMatch(word))
                        {
                            string fragment = word.Substring(0, searchedPlugin.IsLight ? 3 : 2);
                            modifiedWords.Add(word.Replace(fragment, searchedPlugin.Index));
                        }
                        else {
                            modifiedWords.Add(word);
                        }
                    }
                    modifiedLines.Add(string.Join(' ', modifiedWords));
                }
                else
                {
                    modifiedLines.Add(line);
                }
            }
            File.WriteAllLines(file, modifiedLines);
        }


        // Get all .txt files from the source directory
        // Copy each .txt file to the destination directory

        foreach (string file in txtFiles)
        {
            string fileName = Path.GetFileName(file);
            string destFilePath = Path.Combine(Program.PathGameDirectory, "data", fileName);
            File.Copy(file, destFilePath, true);
        }
        // checkbox     to check bats from mods



    }

}