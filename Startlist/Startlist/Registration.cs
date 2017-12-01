using System;

namespace Startlist
{
    class Registration
    {
        public int StartNumber { get; private set; }
        public string Name { get; private set; }
        public string Club { get; private set; }
        public string Nationality { get; private set; }
        public string Group { get; private set; }
        public string Class { get; private set; }

        public Registration(string csvLine)
        {
            /* "Start number","Name","Club","Nationality","Group","Class"
             * "30066","Audun Levin","","NOR","25 km / Pulje 5 (seeding)","M35-39"
             */
            var lineParts = csvLine.Split(',');
            StartNumber = Convert.ToInt32("0" + lineParts[0].Trim('"'));
            Name = lineParts[1].Trim('"');
            Club = lineParts[2].Trim('"');
            Nationality = lineParts[3].Trim('"');
            Group = lineParts[4].Trim('"');
            Class = lineParts[5].Trim('"');
        }

        public Registration(int startNumber, string name, string club, string nationality, string aGroup, string aClass)
        {
            StartNumber = startNumber;
            Name = name;
            Club = club;
            Nationality = nationality;
            Group = aGroup;
            Class = aClass;
        }

        public string ToNiceString()
        {
            return StartNumber + " " + Name + " " + Nationality + " " + Group + " " + Class;
        }
    }
}
