using GuessNumber.Interfaces;

public class InputReader : IUserInputData
{
    public int InputUserData()
    {
        int inputNumber;
        if (!Int32.TryParse(Console.ReadLine(), out inputNumber))
        {
            Console.WriteLine("Вы ввели некорректное число");
        }
        return inputNumber;
    }
}