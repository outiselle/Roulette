using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class PlayerProfile
    {
        private int credit;
        private string name;
        private List<Bet> betHistory = new List<Bet>();
        
        // costruttore
        public PlayerProfile(string newName, int creditoIniziale)
        {
            if (creditoIniziale < 0) throw new Exception("Il credito non può essere negativo");
            credit = creditoIniziale;
            name = newName;
        }

        //metodi
        public void AggiungiGiocata(Bet newBet)
        {
            betHistory.Add(newBet);
        }

        public int Credit()
        {
            int tot = credit;
            foreach (Bet newbet in betHistory)
            {
                tot += (newbet.QuantoHaiVinto() - newbet.BetCredit());
            }
            return tot;
        }

        public string Name()
        {
            return name;
        }

        public void PrintInfo()
        {
            string scommessa;
            int puntata;
            int vincita;
            int numRoulette;
            
            Console.WriteLine($"Nome: {Name()} - Crediti: {Credit()}");
            Console.WriteLine("Storico delle scommesse");

            foreach (Bet newbet in betHistory)
            {
                scommessa = newbet.BetCase();
                puntata = newbet.BetCredit();
                vincita = newbet.BetWin();
                numRoulette = newbet.RouletteNumber();
                Console.WriteLine($"hai puntato {puntata} crediti su {scommessa}. Sulla roulette è uscito il numero {numRoulette}. Hai vinto {vincita}");
            }
        }
    }
}
