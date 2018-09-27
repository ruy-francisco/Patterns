using Factory.src.contracts;

namespace Factory.src.classes
{
    public class France: ICountry
    {
        public void SayGoodMorning()
        {
            System.Console.WriteLine("Bonjour!");
        }
    }
}