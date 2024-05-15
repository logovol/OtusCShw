using GuessNumber.Interfaces;

namespace GuessNumber.Logic
{
    public class RandomNumberGenerator : INumberGeneration
    {
        private readonly Random _rand = new Random();
        
        public int GenerateNumber(int min, int max)
        {
            return _rand.Next(min, max + 1);
        }
    }
}
