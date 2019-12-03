namespace PresentationLayer.Configuration
{
    using System.Configuration;

    [ConfigurationCollection(typeof(FileElement))]
    public class FilesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileElement)(element)).FileType;
        }

        public FileElement this[int idx] => (FileElement)BaseGet(idx);
    }
}