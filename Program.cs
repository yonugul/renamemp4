namespace renamemp4
{
    internal class Program
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static void Main(string[] args)
        {
            var allMp4s = Directory.GetFiles(Path.Combine(BaseDirectory), "*.mp4", SearchOption.AllDirectories);
            foreach (var mp4 in allMp4s)
            {
                if (!mp4.Contains("{") || !mp4.Contains("}")) continue;
                var current = Path.GetFileName(mp4);
                var newName = Between(mp4, "{", "}") + ".mp4";
                var newAddr = mp4.Replace(current, newName);
                File.Move(mp4, newAddr, true);
                Console.WriteLine($"{mp4} - {newAddr} olarak değiştirildi.");
            }

            Console.WriteLine("DONE!");

            Console.ReadLine();
        }
        public static string Between(string str, string firstString, string lastString)
        {
            var pos1 = str.IndexOf(firstString, StringComparison.Ordinal) + firstString.Length;
            var pos2 = str.IndexOf(lastString, StringComparison.Ordinal);
            var finalString = str.Substring(pos1, pos2 - pos1);
            return finalString;
        }
    }
}

