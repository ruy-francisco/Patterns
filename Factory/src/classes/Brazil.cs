using Factory.src.contracts;

namespace Factory.src.classes
{
    public class Brazil : ICountry
    {
        public void SayGoodMorning()
        {
            System.Console.WriteLine("Bom dia!");
        }
    }
}