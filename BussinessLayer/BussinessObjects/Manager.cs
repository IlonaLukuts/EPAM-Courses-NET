namespace BussinessLayer.BussinessObjects
{
    using System;

    using System.Collections.Generic;

    using System.Security.Cryptography;

    using BussinessLayer.ByteArrayConverter;

    public class Manager
    {
        public Manager()
        {
            this.Files = new List<FileWithSellings>();
        }

        public int Id { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<FileWithSellings> Files { get; set; }

        public override int GetHashCode()
        {
            int hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(ByteArrayConverter.ToByteArray(Surname));
                hash = BitConverter.ToInt32(hashBytes, 0);
            }

            return hash;
        }
    }
}
