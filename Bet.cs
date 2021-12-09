using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Bet
    {
        private int betCredit;
        private int betWin;
        private bool played;
        private string betCase;
        private int rouletteNumber;

        public Bet(int value)
        {
            betCredit = value;
            betWin = 0;
            played = false;
        }

        public void Game(string yourBet)
        {
            /*
             * 0 - 36
             * rosso - nero (pari - dispari)
             * dozzina (1-12)
             * dozzina (13-24)
             * dozzina (25-36)
             */

            if (played) return;

            yourBet = yourBet.ToLower();

            rouletteNumber = new Random().Next(0, 36);

            short result;
            if (Int16.TryParse(yourBet, out result))
            {
                if (result >= 0 && result < 37)
                {
                    played = true;
                    betCase = yourBet;

                    if (result == rouletteNumber)
                    {
                        betWin = betCredit * 36;
                    }
                }
            }
            else
            {
                switch (yourBet)
                {
                    case "rosso":
                        played = true;
                        betCase = yourBet;
                        if ((rouletteNumber % 2) == 0) betWin = betCredit * 2;
                        break;
                    case "nero":
                        played = true;
                        betCase = yourBet;
                        if ((rouletteNumber % 2) != 0) betWin = betCredit * 2;
                        break;
                    case "dozA":
                        played = true;
                        betCase = yourBet;
                        if (Enumerable.Range(1, 12).Contains(rouletteNumber)) betWin = betCredit * 3;
                        break;
                    case "dozB":
                        played = true;
                        betCase = yourBet;
                        if (Enumerable.Range(13, 24).Contains(rouletteNumber)) betWin = betCredit * 3;
                        break;
                    case "dozC":
                        played = true;
                        betCase = yourBet;
                        if (Enumerable.Range(25, 36).Contains(rouletteNumber)) betWin = betCredit * 3;
                        break;
                }
            }
        }

        /*
         * quanto hai scommesso
         * quanto hai vinto
         * totale credito
         * tipo scommessa
         */

        public int BetCredit()
        {
            return betCredit;
        }

        public int BetWin()
        {
            return betWin;
        }

        public int QuantoHaiVinto()
        {
            return betWin;
        }

        public string BetCase()
        {
            return betCase;
        }

        public int RouletteNumber()
        {
            return rouletteNumber;
        }





    }
}
