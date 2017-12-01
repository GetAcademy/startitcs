using System;

namespace ShowPlaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var place = new Place("Stavern","Larvik","Vestfold");
            var place2 = new Place("Rjukan", "Tinn", "Telemark");

            place.ShowPlace();
            place2.ShowPlace();
        }
    }
}
