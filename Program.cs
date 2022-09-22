using System;

namespace renamemp4
{
    internal class Program
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static void Main(string[] args)
        {
            var allMp4S = Directory.GetFiles(Path.Combine(BaseDirectory), "*.mp4", SearchOption.AllDirectories);
            const string format = "unit-{0}-test-{1}-soru-{2}.mp4";
            foreach (var mp4 in allMp4S)
            {
                var folder = Path.GetFileName(Path.GetDirectoryName(mp4));

                if (string.IsNullOrEmpty(folder)) continue;
                var current = Path.GetFileName(mp4);
                var  unit = folder[..1];
                if (!int.TryParse(unit, out var unitInt)) continue;
                if (mp4.Contains("Quiz"))
                {
                    var qo = mp4[^6..].Replace(".mp4", "").Trim();
                    var newName = string.Format(format, unitInt, 2, qo);
                    var newAddr = mp4.Replace(current, newName);
                    File.Move(mp4, newAddr, true);
                    Console.WriteLine($"{mp4} - {newAddr} olarak değiştirildi.");
                }
                else
                {
                    var qo = mp4[^6..].Replace(".mp4","").Trim();
                    var newName = string.Format(format, unitInt, 1, qo);
                    var newAddr = mp4.Replace(current, newName);
                    File.Move(mp4, newAddr, true);
                    Console.WriteLine($"{mp4} - {newAddr} olarak değiştirildi.");
                }
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

