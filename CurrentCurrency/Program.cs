
namespace CurrentCurrency
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
 
                Console.WriteLine("Введите код валюты, для получения курса:");

                var charCode = Console.ReadLine().ToUpper();

                var currencyHandler = new CurrencyHandler(charCode);

                var valute = await currencyHandler.GetValuteAsync();

                Console.WriteLine($"Валюта: {valute.CharCode}\t Курс: {valute.VunitRate}");
            

        }
    }

}