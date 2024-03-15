using System; 
using System.Text;
public static class InputHelper
{ s
    public static bool Input(string _text, int _min, int _max, out int inputValue)
    {
        bool result = false;
        Console.WriteLine(_text);

        int.TryParse(Console.ReadLine(), out inputValue);

        if (inputValue >= _min || inputValue <= _max)
        {
            result = true;
        }
        else
        {
            Console.WriteLine("Ошибка");
        }
        return result;
    }
} 