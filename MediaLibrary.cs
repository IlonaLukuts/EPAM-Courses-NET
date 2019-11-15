using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLibrary.MediaFiles;
using MediaLibrary.MediaFiles.Interfaces;

namespace MediaLibrary
{
    class MediaLibrary : IMediaLibrary
    {
        private IMediaList audioFiles;
        private IMediaList videoFiles;
        private IMediaList pictureFiles;
        private IList<IMediaList> mediaLists;

        public MediaLibrary() { }

        public bool AddFile(string name, string path)
        {
            throw new NotImplementedException();
        }

        public bool CreateMediaList(string mediaListName)
        {
            throw new NotImplementedException();
        }

        public bool CreateMediaList(string mediaListName, IList<IMediaFile> mediaFiles)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(string name, string path)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMediaList(string mediaListName)
        {
            throw new NotImplementedException();
        }

        public void PlayMediaFiles(bool playAllAudios, bool playAllPictures, bool playAllVideos, bool playRandomly)
        {
            throw new NotImplementedException();
        }

        public void PlayMediaList(string mediaListName, bool playRandomly)
        {
            throw new NotImplementedException();
        }

        public bool Refresh()
        {
            throw new NotImplementedException();
        }

        public void Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }
        
    }
}
