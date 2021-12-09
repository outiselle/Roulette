using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            Console.WriteLine("ROULETTE EUROPEA");
            Console.WriteLine("per giocare alla roulette crea il tuo profilo");
            Console.WriteLine("Inserisci il tuo nome:");
            string name = Console.ReadLine();
            Console.WriteLine("Inserisci il credito iniziale");
            int credit = Int16.Parse(Console.ReadLine());
            PlayerProfile newPlayer = new PlayerProfile(name, credit);

            do
            {

                Utility.Proceed();

                Console.WriteLine("Come vuoi procedere?");
                Console.WriteLine("[a] fai una scommessa");
                Console.WriteLine("[b] visualizza il tuo profilo");
                Console.WriteLine("[c] esci");
                string x = Console.ReadLine();

                switch (x)
                {
                    case "a":
                        Console.WriteLine(" Quanto vuoi scommettere?");
                        int betValue = Int16.Parse(Console.ReadLine());
                        Bet newBet = new Bet(betValue);
                        Console.WriteLine("Su cosa vuoi scommettere?");
                        Console.WriteLine("[a] Un numero tra 0 - 36");
                        Console.WriteLine("[b] Rosso(pari)");
                        Console.WriteLine("[c] Nero(dispari)");
                        Console.WriteLine("[d] Dozzina 1 - 12");
                        Console.WriteLine("[e] Dozzina 12 - 24");
                        Console.WriteLine("[f] Dozzina 25 - 36");
                        string y = Console.ReadLine();
                        switch (y)
                        {
                            case "a":
                                Console.WriteLine("Inserisci un numero tra 0 e 36");
                                string num = Console.ReadLine();
                                newBet.Game(num);
                                break;
                            case "b":
                                newBet.Game("rosso");
                                y = "rosso";
                                break;
                            case "c":
                                newBet.Game("nero");
                                y = "nero";
                                break;
                            case "d":
                                newBet.Game("dozA");
                                y = "dozzina 1 - 12";
                                break;
                            case "e":
                                newBet.Game("dozB");
                                y = "dozzina 13 - 24";
                                break;
                            case "f":
                                newBet.Game("dozB");
                                y = "dozzina 25 - 36";
                                break;
                        }
                        newPlayer.AggiungiGiocata(newBet);
                        Console.WriteLine($"hai puntato {betValue} su {y}. Il risultato della roulette è: {newBet.RouletteNumber()}");
                        Console.WriteLine($"Hai vinto {newBet.BetWin()}");
                        break;
                    case "b":
                        newPlayer.PrintInfo();
                        break;
                    case "c":
                        Console.WriteLine($"HAI VINTO {newPlayer.Credit()}");
                        Console.WriteLine($"Grazie per aver giocato e ringrazia l'astrofilo curioso se funziona.");
                        Utility.Proceed();
                        exit = true;
                        break;
                }
            } while (!exit);   
        }


    }
}
