using Logger.Models.Contracts;
using System;
using System.IO;

namespace Logger.Models.Files
{
    public class LogFile : ILogFile
    {
        const string DefaultPath = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            InitializeFile();
            this.Size = 0;
        }

        public string Path { get; }

        public int Size { get; private set; }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }

        public void WriteToFile(string errorLog)
        {
            int addedSize = 0;

            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }

            this.Size += addedSize;
        }
    }
}
