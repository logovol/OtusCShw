using GuessNumber.Interfaces;

namespace GuessNumber.Logic
{
    /// <summary>
    /// Класс игры "Угадай число"
    /// </summary>
    public class Game
    {
        private readonly INumberGeneration _numberGenerator;
        private readonly INotification _userNotificator;
        private readonly IUserInputData _userInputReader;
        private readonly int _minNumber;
        private readonly int _maxNumber;
        private readonly int _maxAttempts;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberGenerator">генерация псведослучайного числа</param>
        /// <param name="userNotificator">оповещение пользователя</param>
        /// <param name="userInputReader">чтение введенных данных пользователем</param>
        /// <param name="minNumber">минимальное число</param>
        /// <param name="maxNumber">максимальное число</param>
        /// <param name="maxAttempts">число попыток</param>
        public Game(INumberGeneration numberGenerator, INotification userNotificator,
            IUserInputData userInputReader, int minNumber, int maxNumber, int maxAttempts)
        {
            _numberGenerator  = numberGenerator;
            _userNotificator  = userNotificator;
            _userInputReader  = userInputReader;
            _minNumber        = minNumber;
            _maxNumber        = maxNumber;
            _maxAttempts      = maxAttempts;
        }
        
        /// <summary>
        /// Метод запускает игру
        /// </summary>
        public void Start()
        {
            var numberToGuess = _numberGenerator.GenerateNumber(_minNumber, _maxNumber);
            _userNotificator.ShowMessage($"Угадайте число между {_minNumber} и {_maxNumber} за {_maxAttempts} попыток");


            for (int attempt = 1; attempt <= _maxAttempts; attempt++)
            {
                _userNotificator.ShowMessage($"Попытка {attempt}");
                int userNumber = _userInputReader.InputUserData();

                if (userNumber > numberToGuess)
                {
                    _userNotificator.ShowMessage($"Загаданное число меньше!");
                    continue;
                }
                else if (userNumber < numberToGuess)
                {
                    _userNotificator.ShowMessage($"Загаданное число больше!");
                    continue;
                }
                else
                {
                    _userNotificator.ShowMessage($"Число отгадано за {attempt} попыток!");
                    return;
                }

            }
            _userNotificator.ShowMessage($"Вы проиграли. Было загадно число {numberToGuess}");
        }
    }
}
