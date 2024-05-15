using GuessNumber.Interfaces;
using GuessNumber.Logic;


INumberGeneration numberGenerator = new RandomNumberGenerator();
INotification notificator = new Notificator();
IUserInputData inputReader = new InputReader();

#region settings
int minNumber = 1;
int maxNumber = 100;
int maxAttempts = 10;
#endregion

Game game = new Game(numberGenerator, notificator, inputReader, minNumber, maxNumber, maxAttempts);

game.Start();