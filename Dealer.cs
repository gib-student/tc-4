using System;

namespace tc_4
{
    class Dealer
    {   
        // The score variable only exists in this class
        static int score = 0;

        /// Pull a card between 1 and 13
        public void PullFirstCard()
        {
            throw new NotImplementedException();
        }

        /// Ask the player if they guess the card is either higher or lower
        public void AskHighLo()
        {
            throw new NotImplementedException();
        }
        
        /// Pull a second card bewtween 1 and 13
        public void PullSecondCard()
        {
            throw new NotImplementedException();
        }
        
        /// Show the player's current score
        public void ShowScore()
        {
            throw new NotImplementedException();
        }

        /// Compute whether the player guessed correctly or not and 
        /// return true/false: true for yes, false for no
        public bool PlayerIsCorrect()
        {
            throw new NotImplementedException();
        }

        /// Decide if the user should keep playing or not.
        /// End conditions: their score reaches 0, or they say "stop"
        /// Continue conditions: score is > 0, and they say "continue"
        public bool KeepPlaying()
        {
            throw new NotImplementedException();
        }

        /// Display a message to the player depending on the conditions of 
        /// how the game ended. Ex. they ended with a positive score, they
        /// ended with a score of 0
        public void DisplayGameEndMessage()
        {
            throw new NotImplementedException();
        }
    }
}
