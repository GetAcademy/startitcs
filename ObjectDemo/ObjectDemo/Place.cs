using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDemo
{
    class Place
    {
        public string PlaceName { get;  set; }
        public string Municipality { get;  set; }
        public string Region { get;  set; }

        public Place(string placeName, string municipality, string region)
        {
            PlaceName = placeName;
            Municipality = municipality;
            Region = region;
        }


    }
}
