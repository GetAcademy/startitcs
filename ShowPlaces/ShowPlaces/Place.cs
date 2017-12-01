using System;

namespace ShowPlaces
{
    class Place
    {
        public string PlaceName { get; private set; }
        public string Municipality { get; private set; }
        public string Region { get; private set; }


        public Place(string placeName, string municipality, string region)
        {
            PlaceName = placeName;
            Municipality = municipality;
            Region = region;
        }

        public void ShowPlace()
        {
            var labelWidth = 8;
            ShowSeparatorRow(8);
            ShowFieldNameAndValue("Navn", labelWidth, PlaceName);
            ShowFieldNameAndValue("Kommune", labelWidth, Municipality);
            ShowFieldNameAndValue("Fylke", labelWidth, Region);
            ShowSeparatorRow(labelWidth);
        }

        private void ShowFieldNameAndValue(string label, int labelWidth, string fieldValue)
        {
            labelWidth -= label.Length;
            Console.WriteLine("  " + label + ":" + string.Empty.PadLeft(labelWidth, ' ') + fieldValue);
        }

        private void ShowSeparatorRow(int labelWidth)
        {
            labelWidth += 14;
            Console.WriteLine(string.Empty.PadLeft(labelWidth, '*'));
        }

    }
}
