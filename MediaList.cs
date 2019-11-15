using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLibrary.MediaFiles;
using MediaLibrary.MediaFiles.Interfaces;

namespace MediaLibrary
{
    class MediaList : IMediaList
    {
        private IList<IMediaFile> mediaFiles;
        public int Count { get; private set; }

        public IMediaFile this[int index] => throw new NotImplementedException();

        public MediaList()
        {
            this.mediaFiles = new List<IMediaFile>();
        }

        public MediaList(IList<IMediaFile> files)
        {

        }

        public void AddToList()
        {
            throw new NotImplementedException();
        }

        public void DeleteFromList()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public void Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
