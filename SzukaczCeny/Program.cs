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
                    UstawMarze(out marza);
                }

            } while (Klawisz != ConsoleKey.Escape);
        }

        private static void UstawMarze(out int marza)
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
            int marzaR;
            bool CenaOK;
            double CenaSB;
            double CenaZN = WczytajCene();
            if (CenaZN <= 0) return;

            double CenaZB = Math.Round(CenaZN * 1.23, 2, MidpointRounding.AwayFromZero);
            double CenaSN = CenaZN * (1 + (marza / 100d));

            do
            {
                //CenaSN += 1d;
                //CenaSN += 0.1d;
                CenaSN += 0.01d;
                CenaSB = Math.Round(CenaSN * 1.23, 2, MidpointRounding.AwayFromZero);
                CenaOK = CenaSB == Math.Truncate(CenaSB);

            } while (!CenaOK);

            marzaR = (int)Math.Round((100 * CenaSB / CenaZB) - 100, 0);

            DisplayResult(marza, marzaR, CenaSB, CenaZN, CenaZB, CenaSN);
        }

        private static void DisplayResult(int marza, int marzaR, double CenaSB, double CenaZN, double CenaZB, double CenaSN)
        {
            Console.Clear();
            Console.WriteLine($"Marża ustawiona : {marza} %");
            Console.WriteLine($"\trealna  : {marzaR} %");
            Console.WriteLine($"\t\t\t    netto     \t brutto");
            Console.WriteLine($"\t\t\t ==============================");
            Console.WriteLine($"\tCena zakupu :       {CenaZN.ToString("0.00")} \t {CenaZB.ToString("0.00")}");
            Console.WriteLine($"\tCena sprzedaży :    {CenaSN.ToString("0.00")} \t {CenaSB.ToString("0.00")}");
            Console.WriteLine($"\t\t\t ------------------------------");
            Console.WriteLine($"\tZysk :              {(CenaSN - CenaZN).ToString("0.00")} \t {(CenaSB - CenaZB).ToString("0.00")}\n\n");
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