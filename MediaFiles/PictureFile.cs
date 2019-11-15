using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.MediaFiles
{
    class PictureFile : MediaFile, Interfaces.IPictureFile
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Camera { get; private set; }

        public PictureFile(string name, string path) : base(name, path)
        {

        }

        public void Rotate(double angleDegrees)
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

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
