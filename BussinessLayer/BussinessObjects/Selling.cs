namespace BussinessLayer.BussinessObjects
{
    using System;

    using System.Security.Cryptography;

    using System.Collections.Generic;

    using BussinessLayer.ByteArrayConverter;

    public class Selling
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string ClientSurname { get; set; }

        public string Product { get; set; }

        public decimal Sum { get; set; }

        public Manager Manager { get; set; }

        public override int GetHashCode()
        {
            int hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                List<byte> listOfBytes = new List<byte>();
                listOfBytes.AddRange(ByteArrayConverter.ToByteArray(DateTime.GetHashCode()));
                listOfBytes.AddRange(ByteArrayConverter.ToByteArray(ClientSurname));
                listOfBytes.AddRange(ByteArrayConverter.ToByteArray(Product));
                listOfBytes.AddRange(ByteArrayConverter.ToByteArray(Sum));
                listOfBytes.AddRange(ByteArrayConverter.ToByteArray(Manager.GetHashCode()));
                byte[] hashBytes = sha256.ComputeHash(listOfBytes.ToArray());
                hash = BitConverter.ToInt32(hashBytes, 0);

            }

            return hash;
        }
    }
}
