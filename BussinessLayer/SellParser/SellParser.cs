namespace BussinessLayer.SellParser
{
    using System;

    using System.Collections.Generic;

    using System.IO;

    using BussinessObjects;

    public class SellParser
    {
        private static char[] separators = new char[] { '_', '.' };

        public static ICollection<Selling> Parse(Stream stream)
        {
            ICollection<Selling> sellings = new List<Selling>();
            using (StreamReader streamReader = new StreamReader(stream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] split = line.Split(',');
                    DateTime dateTime;
                    decimal sum;
                    if (DateTime.TryParse(split[0], out dateTime) && decimal.TryParse(split[3], out sum))
                    {
                        var selling = new Selling()
                        {
                            DateTime = dateTime,
                            ClientSurname = split[1],
                            Product = split[2],
                            Sum = sum
                        };
                        sellings.Add(selling);
                    }
                }
            }
            return sellings;
        }

        public static FileWithSellings ParseFileName(string fileName)
        {
            var split = fileName.Split(separators);
            Manager manager = new Manager()
            {
                Surname = split[0]
            };
            string dayString = $"{split[1][0]}{split[1][1]}";
            string monthString = $"{split[1][2]}{split[1][3]}";
            string yearString = $"{split[1][4]}{split[1][5]}{split[1][6]}{split[1][7]}";
            int day, month, year;
            if (int.TryParse(dayString, out day) && int.TryParse(monthString, out month) && int.TryParse(yearString, out year)) {
                FileWithSellings file = new FileWithSellings()
                {
                    Manager = manager,
                    DateTime = new DateTime(year, month, day)
                };
                return file;
            }
            throw new ArgumentException("Wrong format of file name.");
        }
    }
}
