namespace TheGame.BoardPieces.Quests
{
    using BoardInterfaces;
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utils;

    public class Hangman : AbstractQuest, IGame, IInteractable
    {
        private Position position;
        private int health;
        private string progress;
        
        public Hangman(Position position)
            : base(position)
        {
            this.position = position;
            this.health = 7;
            this.progress = string.Empty;
        }

        public override double StartGame()
        {
            this.ClearConsole();

            var secretWords = this.GetSecretWords();
            var wordIndex = Generator.GetRandomNumber(1, secretWords.Count);

            var selectedSecretWord = secretWords[wordIndex].Key;

            this.progress += selectedSecretWord[0];
            this.progress += (new string('*', selectedSecretWord.Length - 1));

            this.PrintInitialMessages();

            bool isGuessed = false;
            bool isRunning = true;
            while (isRunning && !isGuessed)
            {
                string guess = Console.ReadLine();
                this.ProcessGuess(secretWords, wordIndex, selectedSecretWord, ref isGuessed, ref isRunning, guess);
            }

            return this.AssignPoints(selectedSecretWord, isGuessed);
        }

        #region Private Methods

        private List<KeyValuePair<string, string>> GetSecretWords()
        {
            var words = new List<KeyValuePair<string, string>>();
            words.Add(new KeyValuePair<string, string>("hedgehoge", "Animal with torns."));
            words.Add(new KeyValuePair<string, string>("bypass", "Avoid something unpleasant or laborious."));
            words.Add(new KeyValuePair<string, string>("jejune", "Lacking interest or significance or impact."));
            words.Add(new KeyValuePair<string, string>("lucid", "Transparently clear; easily understandable."));
            words.Add(new KeyValuePair<string, string>("oxymoron", "Conjoining contradictory terms."));
            words.Add(new KeyValuePair<string, string>("saquinavir", "A weak protease inhibitor used in treating HIV."));
            words.Add(new KeyValuePair<string, string>("wanton", "Lewd or lascivious woman."));
            words.Add(new KeyValuePair<string, string>("wonky", "Turned or twisted toward one side."));
            words.Add(new KeyValuePair<string, string>("zenith", "The point above the observer directly opposite the nadir."));
            words.Add(new KeyValuePair<string, string>("alliteration", "Use of the same consonant at the beginning of each word."));

            return words;
        }

        private void ClearConsole()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        private double AssignPoints(string selectedSecretWord, bool isGuessed)
        {
            var result = 10d;
            if (isGuessed)
                Console.WriteLine("WELL DONE! You have guessed it correctly");

            if (!isGuessed)
            {
                Console.WriteLine("You failed!The word was: " + selectedSecretWord);
                result = 0d;
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            return result;
        }

        private void ProcessGuess(List<KeyValuePair<string, string>> secretWords, int wordIndex, string selectedSecretWord, ref bool isGuessed, ref bool isRunning, string guess)
        {
            if (guess.Length > 1)
            {
                this.ProcessWholeWordEntered(selectedSecretWord, ref isGuessed, ref isRunning, guess);
            }
            else
            {
                if (guess.StartsWith("0"))
                    isRunning = false;

                if (guess.StartsWith("1"))
                    Console.WriteLine("Hint: {0} \nIf you are lazy to count the word has {1} letters\n",
                        secretWords[wordIndex].Value,
                        secretWords[wordIndex].Key.Length);

                this.CheckIfLetterIsCorrect(selectedSecretWord, ref isGuessed, ref isRunning, guess);
            }
        }

        private void ProcessWholeWordEntered(string selectedSecretWord, ref bool isGuessed, ref bool isRunning, string guess)
        {
            if (guess.CompareTo(selectedSecretWord) == 0)
            {
                isGuessed = true;
            }
            else
            {
                Console.WriteLine("You have tried guessing the whole word, but did not secceeded. You were beheaded.");
                isRunning = false;
            }
        }

        private void CheckIfLetterIsCorrect(string selectedSecretWord, ref bool isGuessed, ref bool isRunning, string guess)
        {
            bool isCorrectChar = false;
            for (int i = 0; i < selectedSecretWord.Length; i++)
            {
                if (guess == selectedSecretWord[i].ToString())
                {
                    StringBuilder word = new StringBuilder(progress);
                    word[i] = guess[0];
                    progress = word.ToString();
                    isCorrectChar = true;
                }

                if (progress.CompareTo(selectedSecretWord) == 0)
                    isGuessed = true;

            }

            Console.WriteLine(progress);
            if (!isCorrectChar)
            {
                this.health--;
                if (this.health == 0)
                {
                    isRunning = false;
                    Console.WriteLine("No more health;");
                }
                else
                    Console.WriteLine("Lives left - {0}", this.health);
            }

            Console.WriteLine();
        }

        private void PrintInitialMessages()
        {
            Console.WriteLine("The word you must guess is: {0}", this.progress);
            Console.WriteLine("Start guessing: ");
            Console.WriteLine("If you want to give up enter: 0 (!You lose points.)");
            Console.WriteLine("Enter : 1 for a hint (It will cost 1 health however.)");
            Console.WriteLine("Your current healt before beheading: {0}", this.health);
            Console.WriteLine(new string('=', 30));
        }

        #endregion
    }
}
