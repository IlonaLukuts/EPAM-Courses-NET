using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary
{
    class Player : IPlayer
    {
        public IMediaList CurrentMediaList { get; private set; }
        public MediaFiles.Interfaces.IMediaFile CurrentMediaFile { get; private set; }
        private int currentIndex;

        private bool playRandomly;
        private bool repeatMediaListOrMediaFile;

        public Player(IMediaList mediaList) { }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public bool OpenSubs(string filename, string path)
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Previous()
        {
            throw new NotImplementedException();
        }

        public void Rewind(bool IsForward)
        {
            throw new NotImplementedException();
        }

        public void Rotate(double angleDegrees)
        {
            throw new NotImplementedException();
        }

        public bool SetRepeatListOrFile()
        {
            throw new NotImplementedException();
        }

        public void SpeedChange(double coefficient)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public bool TurnOnOffPlayRandomly()
        {
            throw new NotImplementedException();
        }

        public bool TurnOnOffSubs()
        {
            throw new NotImplementedException();
        }

        public void Zoom(double coefficient)
        {
            throw new NotImplementedException();
        }
    }
}
