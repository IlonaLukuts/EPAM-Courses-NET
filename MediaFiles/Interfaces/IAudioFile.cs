using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.MediaFiles.Interfaces
{
    interface IAudioFile
    {
        DateTime Duration { get; }
        double Speed { get; }
        int KBPerSec { get; }

        void Play();
        void Stop();
        void Pause();
        void Rewind(bool IsForward);
        void SpeedChange(double coefficient);
    }
}
