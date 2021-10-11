using System;
using System.Diagnostics;

namespace tc_4
{
    class Dealer
    {
        const int COMMAND_ASK_HIGH_LO = 1;
        const int COMMAND_KEEP_PLAYING = 2;

        // These variables only exist in this class
        static int _score = 300; // starting score
        static string _guess;
        static int _firstCard = 0;
        static int _secondCard = 0;
        static int _bet = 0;

        /// Pull a card between 1 and 13
        public void PullFirstCard()
        {
            Random randomCard = new Random();
            _firstCard = randomCard.Next(1, 14);
            Console.WriteLine($"The card is : {_firstCard}");
        }

        /// Ask the player if they guess the second card
        /// is either higher or lower than the first card
        public void AskHighLo()
        {
            Console.Write("Higher or lower? [h/l] ");
            _guess = Console.ReadLine().ToLower();  // in case they enter
                                                    // an uppercase
            if (!ValidateInput(COMMAND_ASK_HIGH_LO, _guess))
            {
                DisplayInvalidInputMessage(COMMAND_ASK_HIGH_LO);
                AskHighLo();
            }
        }

        /// Ask player how much they would like to bet and update member
        /// variable _bet.
        public void PlaceBet()
        {   
            Console.Write($"How much would you like to bet? (Current points: {_score}) ");
            string betString = Console.ReadLine();
            _bet = int.Parse(betString);
            while (_bet > _score)
            {
                Console.WriteLine($"The bet needs to be lower than {_score}.");
                Console.Write("How much would you like to bet? ");
                betString = Console.ReadLine();
                _bet = int.Parse(betString);
            }
            Console.WriteLine($"Your bet is: {_bet}");
        }

        /// Pull a second card bewtween 1 and 13
        public void PullSecondCard()
        {
            Random randomCard = new Random();
            _secondCard = randomCard.Next(1, 14);
            while (_secondCard == _firstCard)
            {
                _secondCard = randomCard.Next(1,14);
            }
            Console.WriteLine($"Next card was: {_secondCard}" );
        }

        /// Show the player's current score
        public void ShowScore()
        {
            int scoreChange = ScoreKeeper();

            Console.Write($"Your score is: {_score} ");
            if (scoreChange >= 0)
            {
                Console.WriteLine($"(+ {scoreChange} points)");
            }
            else
            {
                Console.WriteLine($"- {scoreChange} points)");
            }
        }

        /// Compute whether the player guessed correctly or not and
        /// return true/false: true for yes, false for no.
        /// Returns a bool
        public bool PlayerIsCorrect()
        {
            if (_guess == "l" && _firstCard <= _secondCard)
            {
                return true;
            }
            else if (_guess == "h" && _firstCard >= _secondCard)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// Decide if the user should keep playing or not.
        /// End conditions: their score reaches 0, or they say "stop".
        /// Continue conditions: score is > 0, and they say "continue".
        /// Returns a bool.
        public bool KeepPlaying()
        {
            if (_score > 0)
            {
                Console.Write("Continue playing? [y/n] ");
                string keepGame = Console.ReadLine().ToLower();
                while (!ValidateInput(COMMAND_KEEP_PLAYING, keepGame))
                {
                    DisplayInvalidInputMessage(COMMAND_KEEP_PLAYING);
                    keepGame = Console.ReadLine().ToLower();
                }
                if (keepGame == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// Display a message to the player depending on the conditions of
        /// how the game ended. Ex. they ended with a positive score, they
        /// ended with a score of 0
        public void DisplayGameEndMessage()
        {
            if (_score > 0)
            {                                                                           
                Console.WriteLine("\t\t\t\t\t▀███▀   ▀██▀                                                            ██ ");
                Console.WriteLine("\t\t\t\t\t  ███   ▄█                                                              ██ ");
                Console.WriteLine("\t\t\t\t\t   ███ ▄█    ▄██▀██▄▀███  ▀███     ▀██▀    ▄█    ▀██▀ ▄██▀██▄▀████████▄ ██ ");
                Console.WriteLine("\t\t\t\t\t    ████    ██▀   ▀██ ██    ██       ██   ▄███   ▄█  ██▀   ▀██ ██    ██ ██ ");
                Console.WriteLine("\t\t\t\t\t     ██     ██     ██ ██    ██        ██ ▄█  ██ ▄█   ██     ██ ██    ██ ▀▀ ");
                Console.WriteLine("\t\t\t\t\t     ██     ██▄   ▄██ ██    ██         ███    ███    ██▄   ▄██ ██    ██ ▄▄ ");
                Console.WriteLine("\t\t\t\t\t   ▄████▄    ▀█████▀  ▀████▀███▄        █      █      ▀█████▀▄████  ████▄█ ");
                Console.WriteLine("\n\n\n");
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t▓██   ██▓ ▒█████   █    ██       ██▓    ▒█████    ██████ ▄▄▄█████▓");
                Console.WriteLine("\t\t\t\t\t ▒██  ██▒▒██▒  ██▒ ██  ▓██▒     ▓██▒   ▒██▒  ██▒▒██    ▒ ▓  ██▒ ▓▒");
                Console.WriteLine("\t\t\t\t\t  ▒██ ██░▒██░  ██▒▓██  ▒██░     ▒██░   ▒██░  ██▒░ ▓██▄   ▒ ▓██░ ▒░");
                Console.WriteLine("\t\t\t\t\t  ░ ▐██▓░▒██   ██░▓▓█  ░██░     ▒██░   ▒██   ██░  ▒   ██▒░ ▓██▓ ░ ");
                Console.WriteLine("\t\t\t\t\t  ░ ██▒▓░░ ████▓▒░▒▒█████▓     ▒░██████░ ████▓▒░▒██████▒▒  ▒██▒ ░ ");
                Console.WriteLine("\t\t\t\t\t   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ░░ ▒░▓  ░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░  ▒ ░░   ");
                Console.WriteLine("\t\t\t\t\t ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░░ ░ ▒    ░ ▒ ▒░ ░ ░▒  ░ ░    ░    ");
                Console.WriteLine("\t\t\t\t\t ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░        ░ ░  ░ ░ ░ ▒  ░  ░  ░    ░      ");
                Console.WriteLine("\t\t\t\t\t ░ ░         ░ ░     ░         ░    ░      ░ ░        ░           ");
                Console.WriteLine("\n\n\n");

            }
            Console.WriteLine("\t\t ▄▄▄▄▄▄▄ ▄▄   ▄▄ ▄▄▄▄▄▄ ▄▄    ▄ ▄▄▄   ▄ ▄▄▄▄▄▄▄    ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄▄▄▄▄      ▄▄▄▄▄▄▄ ▄▄▄     ▄▄▄▄▄▄ ▄▄   ▄▄ ▄▄▄ ▄▄    ▄ ▄▄▄▄▄▄▄ ");
            Console.WriteLine("\t\t█       █  █ █  █      █  █  █ █   █ █ █       █  █       █       █   ▄  █    █       █   █   █      █  █ █  █   █  █  █ █       █");
            Console.WriteLine("\t\t█▄     ▄█  █▄█  █  ▄   █   █▄█ █   █▄█ █  ▄▄▄▄▄█  █    ▄▄▄█   ▄   █  █ █ █    █    ▄  █   █   █  ▄   █  █▄█  █   █   █▄█ █   ▄▄▄▄█");
            Console.WriteLine("\t\t  █   █ █       █ █▄█  █       █      ▄█ █▄▄▄▄▄   █   █▄▄▄█  █ █  █   █▄▄█▄   █   █▄█ █   █   █ █▄█  █       █   █       █  █  ▄▄ ");
            Console.WriteLine("\t\t  █   █ █   ▄   █      █  ▄    █     █▄█▄▄▄▄▄  █  █    ▄▄▄█  █▄█  █    ▄▄  █  █    ▄▄▄█   █▄▄▄█      █▄     ▄█   █  ▄    █  █ █  █");
            Console.WriteLine("\t\t  █   █ █  █ █  █  ▄   █ █ █   █    ▄  █▄▄▄▄▄█ █  █   █   █       █   █  █ █  █   █   █       █  ▄   █ █   █ █   █ █ █   █  █▄▄█ █");
            Console.WriteLine("\t\t  █▄▄▄█ █▄▄█ █▄▄█▄█ █▄▄█▄█  █▄▄█▄▄▄█ █▄█▄▄▄▄▄▄▄█  █▄▄▄█   █▄▄▄▄▄▄▄█▄▄▄█  █▄█  █▄▄▄█   █▄▄▄▄▄▄▄█▄█ █▄▄█ █▄▄▄█ █▄▄▄█▄█  █▄▄█▄▄▄▄▄▄▄█");

        }

        /// Ensure input from the player is valid and usable.
        /// Instances of input: When the player gives a guess, and when they
        /// answer whether they want to keep playing.
        static bool ValidateInput(int command, string input)
        {
            Debug.Assert(command == COMMAND_ASK_HIGH_LO ||
                command == COMMAND_KEEP_PLAYING);

            switch (command)
            {
                case COMMAND_ASK_HIGH_LO:
                    return (input == "h" || input == "l");
                case COMMAND_KEEP_PLAYING:
                    return (input == "y" || input == "n");
            }
            // Just in case
            return false;
        }

        /// Tell player the input they gave is invalid
        static void DisplayInvalidInputMessage(int command)
        {
            Debug.Assert(command == COMMAND_ASK_HIGH_LO ||
                command == COMMAND_KEEP_PLAYING);

            switch (command)
            {
                case COMMAND_ASK_HIGH_LO:
                    Console.WriteLine("Please enter \"h\" or \"l\".");
                    break;
                case COMMAND_KEEP_PLAYING:
                    Console.WriteLine("Please enter \"y\" or \"n\".");
                    break;
            }
        }

        /// Change the score according to the player's input and according to
        /// the rules.
        static int ScoreKeeper()
        {
            // Correct conditions
            if ((_guess == "h" && _firstCard <= _secondCard) ||
                (_guess == "l" && _firstCard >= _secondCard))
            {
                _score += 100;
                _score += _bet;
                
                return 100 + _bet;
            }
            // Incorrect Conditions
            else if ((_guess == "h" && _firstCard >= _secondCard) ||
                      (_guess == "l" && _firstCard <= _secondCard))
            {
                _score -= 75;
                _score -= _bet;
                
                return 75 + _bet;
            }
            else
            {
                Console.WriteLine("\t\tScoreKeeper() error");
                return 0;
            }
        }

        /// I'm not sure what this code is for. There are no instances
        /// of these methods except for what is right here.
        // public override bool Equals(object obj)
        // {
        //     return base.Equals(obj);
        // }

        // public override int GetHashCode()
        // {
        //     return base.GetHashCode();
        // }

        // public override string ToString()
        // {
        //     return base.ToString();
        // }
    }
}
