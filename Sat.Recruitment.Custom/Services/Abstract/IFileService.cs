using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Custom.Services.Abstract
{
    public interface IFileService
    {
        string GetFilePath(string folderName, string fileName);
        StreamReader ReadFile(string folderName, string fileName);
        void AppendLines(IEnumerable<string> lines, string folderName, string fileName);
    }
}
