namespace PresentationLayer.Configuration
{
    using System.Configuration;
    using System.IO;

    using NLog;

    public class Section : ConfigurationSection
    {
        [ConfigurationProperty("Files")]
        public FilesCollection FileItems => (FilesCollection)base["Files"];

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public (string concordanceFile, string textFile) Configure()
        {
            var concordanceFilePath = string.Empty;
            var textFilePath = string.Empty;

            var section = (Section)ConfigurationManager.GetSection("StartupFiles");
            if (section != null)
            {
                if (section.FileItems[0].FileType == "ConcordanceFile")
                {
                    concordanceFilePath = section.FileItems[0].FilePath;
                }

                if (section.FileItems[1].FileType == "InitialTextFile")
                {
                    textFilePath = section.FileItems[1].FilePath;
                }
            }

            if (!File.Exists(concordanceFilePath))
            {
                File.Create(concordanceFilePath);
            }

            if (!File.Exists(textFilePath))
            {
                this.logger.Warn("File to read is not found.");
            }

            return (concordanceFilePath, textFilePath);
        }
    }
}