using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.MediaFiles
{
    class VideoFile : MediaFile, Interfaces.IVideoFile
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public DateTime Duration { get; private set; }
        public double Speed { get; private set; }
        public int KBPerSec { get; private set; }
        public int FramesPerSec { get; private set; }
        public bool TurnOnSubs { get; private set; }

        public VideoFile(string name, string path) : base(name, path)
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

        public void Rotate(double angleDegrees)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Zoom(double coefficient)
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

        public bool OpenSubs(string filename, string path)
        {
            throw new NotImplementedException();
        }

        public bool TurnOnOffSubs()
        {
            throw new NotImplementedException();
        }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
