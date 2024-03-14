using System;
class Program
{
    static void Main(string[] args)
    {
        ICommandBasket[] commandBaskets = new ICommandBasket[]
{
        new AddProduct(),
        new RemoveProduct(),
        new Printinfo(),
        new PrintinfoCategoryProduct(),
};

        while (true)
        {
            for (int i = 0; i < commandBaskets.Length; i++)
            {
                ICommandBasket item = commandBaskets[i];
                Console.WriteLine($"{i + 1}--{item}");
            }
            if (InputHelper.Input("выберите что вы будете делать: ", 1, commandBaskets.Length, out int inputvalue))
            {
                commandBaskets[inputvalue - 1].Run();
            }
        }
    }
    public static void CommandBasket(ICommandBasket[] commandBaskets)
    {
        for (int i = 0; i < commandBaskets.Length; i++)
        {
            Console.WriteLine($"{i + 1}--{commandBaskets[i]}");
        }
        Console.WriteLine('\n');
        int.TryParse(Console.ReadLine(), out int intvalue);
        commandBaskets[intvalue - 1].Run();
        Console.WriteLine('\n');
    }
}