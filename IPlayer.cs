using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary
{
    interface IPlayer
    {
        IMediaList CurrentMediaList { get; }
        MediaFiles.Interfaces.IMediaFile CurrentMediaFile { get; }

        void Play();
        void Stop();
        void Pause();
        void Previous();
        void Next();
        bool TurnOnOffPlayRandomly();
        bool SetRepeatListOrFile();

        void Rewind(bool IsForward);
        void SpeedChange(double coefficient);

        void Zoom(double coefficient);
        void Rotate(double angleDegrees);

        bool OpenSubs(string filename, string path);
        bool TurnOnOffSubs();
    }
}
