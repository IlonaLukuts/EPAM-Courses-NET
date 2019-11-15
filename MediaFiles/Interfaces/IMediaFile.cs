using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.MediaFiles.Interfaces
{
    interface IMediaFile
    {
        bool Open();
        bool Close();
        string GetInfo();
    }
}
