using System.Text;
using File = TagLib.File;

void ReadTags(DirectoryInfo musicDirectory, string outputPath)
{
    using var fs = new FileStream(outputPath, FileMode.Create);
    using var sw = new StreamWriter(fs, Encoding.UTF8);
    try
    {
        musicDirectory
            .GetFiles("*.mp3")
            .Select(x => File.Create(x.FullName))
            .ToList()
            .ForEach(x => sw.WriteLine($"{string.Join(',', x.Tag.Performers)} - {x.Tag.Title}"));
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }

    Console.WriteLine("Finita");
}

ReadTags(new DirectoryInfo(@"E:\Music"), @"E:\output.txt");