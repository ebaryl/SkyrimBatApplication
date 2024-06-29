namespace Bat_Manager
{
    internal static class Extensions
    {
        public static string GetParentDirectory(this string path, int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                path = Directory.GetParent(path)?.FullName ?? "";//throw new Exception("Invalid path");
            }
            return path;
        }
    }
}
