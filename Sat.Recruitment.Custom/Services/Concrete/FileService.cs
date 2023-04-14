using Sat.Recruitment.Custom.Services.Abstract;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Custom.Services.Concrete
{
    public class FileService : IFileService
    {        
        public FileService() { }
        public string GetFilePath(string folderName, string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), $"{folderName}/{fileName}");
        }
        public StreamReader ReadFile(string folderName, string fileName)
        {
            var path = GetFilePath(folderName, fileName);
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
        public async void AppendLines(IEnumerable<string> lines, string folderName, string fileName)
        {
            await File.AppendAllLinesAsync(GetFilePath(folderName, fileName), lines);
        }

    }
}
