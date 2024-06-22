using SkyrimBatApplication;
using System;
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;

public class MyRegex()
{
    public static void ReadAllTxtFiles()
    {
        // Pobierz bieżący folder
        // string currentDirectory = Directory.GetCurrentDirectory();
        string currentDirectory = "C:\\Users\\Bartosz\\VSProjects\\repos\\ConsoleApp1\\ConsoleApp1\\batchFiles";
        string[] txtFiles = Directory.GetFiles(currentDirectory, "*.txt");
        Plugin searchedPlugin = null;
        Regex hexRegex = new Regex(@"^[0-9A-F]{8}$");

        foreach (string file in txtFiles)
        {
            string[] lines = File.ReadAllLines(file);
            List<string> modifiedLines = new List<string>();
            

            foreach (string line in lines)
            {

                if (line.StartsWith(";"))
                {
                    modifiedLines.Add(line);
                    ////////////// MOZE SIE DA BEZ TRIMU
                    string pluginName = line.TrimStart(';').Trim();

                    if (pluginName.Contains("#"))
                    {
                        pluginName = pluginName.Split('#')[1];
                        //[..^4] oznacza bez koncowych czterench znakow czyli .esp
                        searchedPlugin = Utility.plugins.FirstOrDefault(p => string.Equals(p.Name[..^4], pluginName, StringComparison.OrdinalIgnoreCase));
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
                    modifiedLines.Add(string.Join(' ', modifiedWords)); // Dodaj zmodyfikowaną linię do listy zmodyfikowanych linii
                }
                else
                {
                    Console.WriteLine($"Nie znaleziono pluginu");
                    modifiedLines.Add(line);
                }
            }
            File.WriteAllLines(file, modifiedLines);

        }

    }

}