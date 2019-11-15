using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.MediaFiles.Interfaces
{
    interface IVideoFile : IPictureFile, IAudioFile
    {
        bool OpenSubs(string filename, string path);
        bool TurnOnOffSubs();
    }
}
