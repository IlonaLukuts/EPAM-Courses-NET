namespace BussinessLayer.ByteArrayConverter
{
    using System;

    using System.Collections.Generic;

    static class ByteArrayConverter
    {
        public static byte[] ToByteArray(string value)
        {
            char[] chars = value.ToCharArray();
            List<byte> listOfBytes = new List<byte>();
            foreach (char c in chars)
            {
                byte[] charBytes = BitConverter.GetBytes(c);
                CheckEndian(charBytes);
                listOfBytes.AddRange(charBytes);
            }
            
            return listOfBytes.ToArray();
        }

        public static byte[] ToByteArray(int value)
        {
            var byteArray = BitConverter.GetBytes(value);
            CheckEndian(byteArray);
            return byteArray;
        }

        public static byte[] ToByteArray(decimal value)
        {
            var bites = decimal.GetBits(value);
            List<byte> listOfBytes = new List<byte>();
            foreach (var i in bites)
            {
                byte[] intBytes = BitConverter.GetBytes(i);
                CheckEndian(intBytes);
                listOfBytes.AddRange(intBytes);
            }

            return listOfBytes.ToArray();
        }

        private static void CheckEndian(byte[] byteArray)
        {
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(byteArray);
            }
        }
    }
}
