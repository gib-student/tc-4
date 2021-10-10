using System;
using System.Diagnostics;

namespace tc_4
{
    class Dealer
    {
        const int COMMAND_ASK_HIGH_LO = 1;
        const int COMMAND_KEEP_PLAYING = 2;

        // These variables only exist in this class
        static int _score = 300;
        static string _guess;
        static int _firstCard = 0;
        static int secondCard = 0;

        public int _bet = 0;


        // Ask the user how much points he would like to bet
        public void PlaceBet()
        {   
            Console.WriteLine("How much would you like to bet?");
            string bet = Console.ReadLine();
            _bet = int.Parse(bet);
            while (_bet > _score)
            {
                Console.WriteLine($"Sorry {_bet} is not a valid bet. {_bet} needs to be lower than {_score}. Please try again");
                Console.WriteLine("How much would you like to bet?");
                bet = Console.ReadLine();
                _bet = int.Parse(bet);
            }
            Console.WriteLine($"Your bet is: {_bet}");
        }
        /// Pull a card between 1 and 13
        public void PullFirstCard()
        {
            Random randomCard = new Random();
            _firstCard = randomCard.Next(1, 14);
            Console.WriteLine($"The card is : {_firstCard}");
        }

        /// Clear the previous guess then ask the player if they guess the card
        /// is either higher or lower than the first pull
        public void AskHighLo()
        {
            Console.Write("Higher or lower? [h/l] ");
            _guess = Console.ReadLine().ToLower();   // in case they enter
                                                    // an uppercase
            if (!ValidateInput(COMMAND_ASK_HIGH_LO, _guess))
            {
                DisplayInvalidInputMessage(COMMAND_ASK_HIGH_LO);
                AskHighLo();
            }
        }

        /// Pull a second card bewtween 1 and 13
        public void PullSecondCard()
        {
            Random randomCard = new Random();
            secondCard = randomCard.Next(1, 14);
            while (secondCard == _firstCard)
            {
                secondCard = randomCard.Next(1,14);
            }
            Console.WriteLine($"Next card was: {secondCard}");
        }

        /// Show the player's current score
        public void ShowScore()
        {
            if (_guess == "l" && secondCard > _firstCard)
            {
                _score =  _score - _bet;
                //_score -= 75;
            }
            else if (_guess == "h" && secondCard > _firstCard)
            {
                _score = _bet +_score;
                //_score += 100;
            }
            // not displaying the score, I dont know why...
            Console.WriteLine($"Your score is: {_score}");
        }

        /// Compute whether the player guessed correctly or not and
        /// return true/false: true for yes, false for no
        public bool PlayerIsCorrect()
        {

            // ---- I am confused with this function so I just code what i undesrtood thou :(---
            if(AskHighLo() == "l" && PullSecondCard() <= PullFirstCard())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// Decide if the user should keep playing or not.
        /// End conditions: their score reaches 0, or they say "stop"
        /// Continue conditions: score is > 0, and they say "continue"
        public bool KeepPlaying()
        {

            if ( ShowScore() <=0 )
            {
                Console.Write("cointinue playing? y/n ");
                string keepGame = Console.ReadLine().ToLower();
                if (keepGame == "y")
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// Display a message to the player depending on the conditions of
        /// how the game ended. Ex. they ended with a positive score, they
        /// ended with a score of 0
        public void DisplayGameEndMessage()
        {
            throw new NotImplementedException();
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
