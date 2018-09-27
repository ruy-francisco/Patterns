using System;
using Factory.src.classes;
using Factory.src.enumerators;
using Factory.src.contracts;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            ICountry brazil = new MyFactory().CreateObject(CountryEnum.BR);
            brazil.SayGoodMorning();

            ICountry france = new MyFactory().CreateObject(CountryEnum.FR);
            france.SayGoodMorning();

            ICountry usa = new MyFactory().CreateObject(CountryEnum.USA);
            usa.SayGoodMorning();
        }
    }
}
