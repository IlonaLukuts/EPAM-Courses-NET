using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLibrary.MediaFiles.Interfaces;

namespace MediaLibrary.MediaFiles
{
    class AudioFile : MediaFile, Interfaces.IAudioFile
    {
        public DateTime Duration { get; private set; }
        public double Speed { get; private set; }
        public int KBPerSec { get; private set; }
        public string NameOfSong { get; private set; }
        public string Artist { get; private set; }
        public string Album { get; private set; }
        public string Genre { get; private set; }

        public AudioFile(string name, string path): base(name, path)
        {

        }
        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Rewind(bool IsForward)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public override bool Open()
        {
            throw new NotImplementedException();
        }

        public override bool Close()
        {
            throw new NotImplementedException();
        }

        public void SpeedChange(double coefficient)
        {
            throw new NotImplementedException();
        }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
