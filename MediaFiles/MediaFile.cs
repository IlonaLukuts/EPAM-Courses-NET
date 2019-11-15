using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.MediaFiles
{
    public abstract class MediaFile : Interfaces.IMediaFile
    {
        public string FileName { get; protected set; }
        public string FilePath { get; protected set; }
        public DateTime FileDateOfCreation { get; protected set; }
        public int Size { get; protected set; }


        protected MediaFile(string name, string path)
        { 
        }

        public virtual bool Open()
        {
            return true;
        }

        public virtual bool Close()
        {
            return true;
        }

        public static string DefineMediaFileType(string name, string path)
        {
            throw new NotImplementedException();
        }

        public virtual string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
