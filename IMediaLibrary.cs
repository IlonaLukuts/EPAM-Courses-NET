using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary
{
    interface IMediaLibrary
    {
        void PlayMediaFiles(bool playAllAudios, bool playAllPictures, bool playAllVideos, bool playRandomly);
        void PlayMediaList(string mediaListName, bool playRandomly);
        bool AddFile(string name, string path);
        void DeleteFile(string name, string path);
        bool Refresh();
        bool CreateMediaList(string mediaListName);
        bool CreateMediaList(string mediaListName, IList<MediaFiles.Interfaces.IMediaFile> mediaFiles);
        bool DeleteMediaList(string mediaListName);
        void Search(string name);
        void Sort();
    }
}
