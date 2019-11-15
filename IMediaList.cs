using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary
{
    interface IMediaList
    {
        int Count { get; }
        void AddToList();
        void DeleteFromList();
        void Sort();
        void Search(string name);
        MediaFiles.Interfaces.IMediaFile this[int index] { get; }
    }
}
