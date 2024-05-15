using GuessNumber.Interfaces;

namespace GuessNumber.Logic
{
    public class Notificator : INotification
    {        
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
