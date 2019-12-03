namespace PresentationLayer.Configuration
{
    using System.Configuration;

    public class FileElement : ConfigurationElement
    {
        [ConfigurationProperty("fileType", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string FileType
        {
            get => (string)base["fileType"];
            set => base["fileType"] = value;
        }

        [ConfigurationProperty("filePath", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string FilePath
        {
            get => (string)base["filePath"];
            set => base["filePath"] = value;
        }
    }
}
