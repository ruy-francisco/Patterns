using Factory.src.contracts;

namespace Factory.src.classes
{
    public class UnitedStatesOfAmerica : ICountry
    {
        public void SayGoodMorning()
        {
            System.Console.WriteLine("Good morning!");
        }
    }
}