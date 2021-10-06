using System;

namespace tc_4
{
    class Director
    {
        Dealer dealer = new Dealer();

        /// Play the game
        public void StartGame()
        {
            bool done = false;

            // Main game loop. Play until the user says "stop"
            while (!done)
            {
                // This is the general process of the game
                dealer.PullFirstCard();
                dealer.AskHighLo();
                dealer.PullSecondCard();
                dealer.ShowScore();
                if (dealer.PlayerIsCorrect())
                {
                    if(!dealer.AskKeepPlaying())
                    {
                        done = true;
                    }
                }
                else
                {
                    done = true;
                }
            }

        }
    }
}
