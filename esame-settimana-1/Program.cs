using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace esame_settimana_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Contribuente.MenuIniziale();
        }
    }

   public class Contribuente
    {
        public static string Nome { get; set;}

        public static string Cognome { get; set;}
        public static string DataNascita { get; set; }

        public static string CodiceFiscale { get; set; }

        private static int  confronto;
        private static int confronto2;
        private static int confronto3;

        private static bool isnumber;
        private static bool isnumber2;
        private static bool isnumber3;






        public static string Sesso { get; set; }

        public static string ComuneResidenza { get; set; }

        public static double RedditoAnnuale { get; set; }

        public static double ImpostaDaPagare { get; set; }
        public static  List<string> listaCalcoli { get; set; } =new List<string>();

      

       


        public static void MenuIniziale()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==================================");
            Console.WriteLine("======AGENZIA DELLE ENTRATE=======");
            Console.WriteLine("==================================");
            Console.WriteLine("Scegli cosa vuoi fare");
            Console.WriteLine("1: Nuovo calcolo reditto");
            Console.WriteLine("2: Lista contribuenti");
            Console.WriteLine("3: Esci");
            Console.ForegroundColor = ConsoleColor.White;

            int scelta=int.Parse(Console.ReadLine());

            if (scelta == 1)
            {
                calcoloReddito();
                MenuIniziale();
            }
            else if (scelta == 2)
            {
                if(listaCalcoli.Count > 0) {
                    mostraElenco();
                    MenuIniziale();
                }
                else
                {
                    Console.WriteLine("Non sono presenti dichiarzioni");
                }
            }

            else if (scelta == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Opzione non disponibile tornerai al menu iniziale");
                MenuIniziale();
            }

        }


        public static void calcoloReddito()
        {
            Console.WriteLine("Inserisci Nome");
            Nome = Console.ReadLine();
            if (isnumber = int.TryParse(Nome, out confronto) == false)
            {
                Console.WriteLine("Inserisci Cognome");
                Cognome = Console.ReadLine();
                if (isnumber = int.TryParse(Cognome, out confronto) == false)
                {
                    Console.WriteLine("Inserisci data di nascita (gg-mm-aa)");
                    DataNascita = Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Valore non corretto, il dato insrito non è un nome valido");
                    Console.ForegroundColor = ConsoleColor.White;
                    MenuIniziale();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valore non corretto, il dato inserito non è un cognome valido ");
                Console.ForegroundColor = ConsoleColor.White;
                MenuIniziale();
            }


            Console.WriteLine("Inserisci Codice Fiscale");
            CodiceFiscale = Console.ReadLine();
            if (CodiceFiscale.Length == 16)
            {
                Console.WriteLine("Inserisci Sesso (M-F)");
                Sesso = Console.ReadLine();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valore non corretto riprova (il codice fiscale contiene 16 lettere-cifre)");
                Console.ForegroundColor = ConsoleColor.White;
                MenuIniziale();
            }

            Console.WriteLine("Inserisci Comune Residenza");
            ComuneResidenza = Console.ReadLine();
            Console.WriteLine("Inserisci Reddito Annuale");
            RedditoAnnuale = double.Parse(Console.ReadLine());
         

            




                if (RedditoAnnuale <= 15000)
                {
                    ImpostaDaPagare = RedditoAnnuale * 0.23;
                    AggiungiALista();
                    stampaCalcolo();
                    MenuIniziale();
                }

                else if (RedditoAnnuale >= 15001 & RedditoAnnuale <= 28000)
                {
                    ImpostaDaPagare = 3450 + ((RedditoAnnuale - 15000) * 0.27);
                    AggiungiALista();
                    stampaCalcolo();
                    MenuIniziale();
                }
                else if (RedditoAnnuale >= 28001 && RedditoAnnuale <= 55000)
                {
                    ImpostaDaPagare = 6960 + ((RedditoAnnuale - 28000) * 0.38);
                    AggiungiALista();
                    stampaCalcolo();
                    MenuIniziale();

                }
                else if (RedditoAnnuale >= 55001 && RedditoAnnuale <= 75000)
                {
                    ImpostaDaPagare = 17220 + ((RedditoAnnuale - 5500) * 0.41);
                    AggiungiALista();
                    stampaCalcolo();
                    MenuIniziale();
                }
                else if (RedditoAnnuale >= 75001)
                {
                    ImpostaDaPagare = 25420 + ((RedditoAnnuale - 75000) * 0.43);
                    AggiungiALista();
                    stampaCalcolo();
                    MenuIniziale();
                }
                else
                {
                    Console.WriteLine("Non hai inserito un numero valido");
                    MenuIniziale();
                }





            

        }


       


        public static void stampaCalcolo()
        {
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine($"Contribuente: {Nome} {Cognome}");
            Console.WriteLine($"Nato il : {DataNascita} {Sesso}");
            Console.WriteLine($"Residente in: {ComuneResidenza}");
            Console.WriteLine($"Codice Fiscale: {CodiceFiscale}");
            Console.WriteLine($"Reddito Dichiarato: {RedditoAnnuale} €");
            Console.WriteLine($"------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"IMPOSTA DA VERSARE: {ImpostaDaPagare} €");
            Console.ForegroundColor = ConsoleColor.White;

        }




        public static void mostraElenco()
        {
            Console.WriteLine("Lista DI TUTTI I CALCOLI");
            foreach (string elemento in listaCalcoli)
            {
                Console.WriteLine(elemento);
            }
        }
        public static void AggiungiALista()
        {
            Contribuente.listaCalcoli.Add($"NOME:  {Nome} COGNOME: {Cognome} NASCITA: {DataNascita} CODICE FISCALE: {CodiceFiscale} SESSO: {Sesso} COMUNE: {ComuneResidenza} REDDITO ANNUO: {RedditoAnnuale} IMPOSTA DA PAGARE: {ImpostaDaPagare} ");
        }


    }
}
