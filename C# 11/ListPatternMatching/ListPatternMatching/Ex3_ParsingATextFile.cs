namespace ListPatternMatching
{
    public class TextFileParser
    {
        public static void ExtractFileHeaders()
        {
            foreach (var filePath in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextFiles"), "*.txt"))
            {
                var file = File.ReadAllLines(filePath);
                if (file is [var author, var title, var publishDate, _, .. var speech])
                {
                    author = author.Remove(0, 8);
                    title = title.Remove(0, 7);
                    publishDate = DateOnly.Parse(publishDate.Remove(0, 6)).ToShortDateString();

                    Console.WriteLine($"""On {publishDate}, {author} gave the "{title}". ({speech.Length} lines)""");
                }
            }
        }
    }
}
