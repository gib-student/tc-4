using System;
using System.Diagnostics;

namespace tc_4
{
    class Dealer
    {
        const int COMMAND_ASK_HIGH_LO = 1;
        const int COMMAND_KEEP_PLAYING = 2;

        // The score variable only exists in this class
        static int score = 0;
        static string guess;

        public int _cardNumber = 0;

        /// Pull a card between 1 and 13
        public int PullFirstCard()
        {
            Random randomCard = new Random();
            _cardNumber = randomCard.Next(1, 14);
            Console.WriteLine($"The card is : {_cardNumber}");
            return _cardNumber;
        }

        /// Clear the previous guess then ask the player if they guess the card
        /// is either higher or lower than the first pull
        public string AskHighLo()
        {
            // guess.Remove(0);
            Console.Write("Higher or lower? [h/l] ");
            guess = Console.ReadLine().ToLower(); // in case they enter
                                                         // an uppercase
            if (!ValidateInput(COMMAND_ASK_HIGH_LO, guess))
            {
                DisplayInvalidInputMessage(COMMAND_ASK_HIGH_LO);
                AskHighLo();
            }
            return guess;
        }

        /// Pull a second card bewtween 1 and 13
        public int PullSecondCard()
        {
            Random randomCard = new Random();
            int nextCard = randomCard.Next(1, 14);
            while (nextCard == _cardNumber)
            {
                nextCard = randomCard.Next(1,14);
            }
            Console.WriteLine($"Next card was: {nextCard}");
            return nextCard;
        }

        /// Show the player's current score
        public int ShowScore()
        {
            int score = 300;
            if(AskHighLo() == "l" && PullSecondCard() > PullFirstCard())
            {
                score = score - 75;
            }
            else if(AskHighLo() == "h" && PullSecondCard() > PullFirstCard())
            {
                score = score + 100;
            }
            // not displaying the score, I dont know why...
            Console.WriteLine($"Your score is: {score}");
            // throw new NotImplementedException();
            return score;
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
            // throw new NotImplementedException();
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

            // throw new NotImplementedException();
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
