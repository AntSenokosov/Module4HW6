// See https://aka.ms/new-console-template for more information

using Module4HW6;

class Program
{
    public static async Task Main(string[] args)
    {
        var start = new Startup();
        await start.Run(args);
    }
}