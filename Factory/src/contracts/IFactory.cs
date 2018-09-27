using Factory.src.enumerators;

namespace Factory.src.contracts
{
    public abstract class IFactory
    {
        public abstract ICountry CreateObject(CountryEnum objectType);
    }
}