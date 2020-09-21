using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzukaczCeny
{
    class Program
    {
        static int marza = 18;
        static void Main(string[] args)
        {
            int marza = 18;
            ConsoleKey Klawisz;
            do
            {
                SzukajCeny();
                Console.WriteLine("Naciśnij dowolny klawisz [Wyjście - Esc, Ustawienia - F1] : ");
                
                Klawisz = Console.ReadKey().Key;
                if (Klawisz == ConsoleKey.F1)
                {
                    UstawMarze();
                }

            } while (Klawisz != ConsoleKey.Escape);
        }

        private static void UstawMarze()
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"============ Ustawienia marży =============");
                Console.WriteLine($"Aktualna\t: {marza} %");
                Console.Write("Podaj nową\t: ");
                marza = int.Parse(Console.ReadLine());
            }
            catch { }
        }

        private static void SzukajCeny()
        {
            var Zakup = new Cena();
            var Sprzedaz = new Cena();
            var VAT = new Cena();
            var marza = new MarzaControler(18);
            
            int marzaR;
            bool CenaOK;
            
            Zakup.CenaNetto = WczytajCene();
            if (Zakup.CenaNetto <= 0) return;
            
            Sprzedaz.CenaNetto = Zakup.Netto() * (1 + (marza.Value / 100d));

            do
            {
                Sprzedaz.CenaNetto += 0.01d;                
                CenaOK = Sprzedaz.Brutto() == Math.Truncate(Sprzedaz.Brutto());

            } while (!CenaOK);

            marza.Calculate(Zakup, Sprzedaz);

            DisplayResult(marza,Sprzedaz,Zakup);
        }

        private static void DisplayResult(MarzaControler m, Cena S, Cena Z)
        {
            Console.Clear();
            Console.WriteLine($"Marża ustawiona : {m.Value} %");
            Console.WriteLine($"\trealna  : {m.RealValue} %");
            Console.WriteLine($"\t\t\t    netto     \t brutto");
            Console.WriteLine($"\t\t\t ==============================");
            Console.WriteLine($"\tCena zakupu :       {Z.CenaNetto.ToString("0.00")} \t {Z.Brutto().ToString("0.00")}");
            Console.WriteLine($"\tCena sprzedaży :    {S.CenaNetto.ToString("0.00")} \t {S.Brutto().ToString("0.00")}");
            Console.WriteLine($"\t\t\t ------------------------------");
            Console.WriteLine($"\tZysk :              {(S.CenaNetto - Z.CenaNetto).ToString("0.00")} \t {(S.Brutto() - Z.Brutto()).ToString("0.00")}\n\n");
        }

        private static double WczytajCene()
        {
            double Cena;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"============ Obliczanie dobrej ceny =====[ marża {marza} % ]=====\n");
                    Console.Write("\tPodaj cene zakupu netto : ");
                    var L = Console.ReadLine();
                    if (string.IsNullOrEmpty(L)) return 0;
                    Cena = int.Parse(L);
                }
                catch
                {
                    Cena = 0;
                }

            } while (Cena == 0);
            return Cena;
        }
    }
}