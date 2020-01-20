namespace BussinessLayer.BussinessObjects
{
    using System;

    using System.Security.Cryptography;

    using System.Collections.Generic;

    using ByteArrayConverter;

    public class FileWithSellings
    {
        public int Id { get; set; }

        public Manager Manager { get; set; }

        public DateTime DateTime { get; set; }

        public override int GetHashCode()
        {
            int hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                List<byte> listOfBytes = new List<byte>();
                listOfBytes.AddRange(ByteArrayConverter.ToByteArray(Manager.GetHashCode()));
                listOfBytes.AddRange(ByteArrayConverter.ToByteArray(DateTime.GetHashCode()));
                byte[] hashBytes = sha256.ComputeHash(listOfBytes.ToArray());
                hash = BitConverter.ToInt32(hashBytes, 0);
            }

            return hash;
        }
    }
}
