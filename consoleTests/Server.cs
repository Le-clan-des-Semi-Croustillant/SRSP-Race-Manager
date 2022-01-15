using Race_Manager.Communication;

// See https://aka.ms/new-console-template for more information

class Server
{
    public static int Main(String[] args)
    {
        Console.WriteLine("Hello, World!");
        string[] str = new string[] { "a", "b" };

        AsyncServer.StartListening(65432);

        Console.WriteLine();
        return 0;
    }
}