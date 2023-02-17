using System.Text;

internal class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        try
        {
            int port = 29070;
            EntryServer.Instance.Start(port);
        }
        catch (NotFiniteNumberException)
        {
            Console.WriteLine("Укажите порт!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Укажите порт!");
        }
    }
}