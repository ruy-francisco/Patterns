using System;
using Factory.src.contracts;
using Factory.src.enumerators;

namespace Factory.src.classes
{
    public class MyFactory : IFactory
    {
        public override ICountry CreateObject(CountryEnum objectType)
        {
            switch (objectType)
            {
                case CountryEnum.BR:
                    return new Brazil();
                case CountryEnum.USA:
                    return new UnitedStatesOfAmerica();
                case CountryEnum.FR:
                    return new France();
                default:
                    throw new Exception("Type not found!");
            }
        }
    }
}