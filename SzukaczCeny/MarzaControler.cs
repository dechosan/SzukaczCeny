using System;
using System.Runtime.CompilerServices;

namespace SzukaczCeny
{
    public class MarzaControler
    {
        public MarzaControler(int init)
        {
            Value = init;
        }

        public int Value { get; set; }
        public int RealValue { get; private set; }

        public void Calculate(Cena Zakup,Cena Sprzedaz) 
        {
            RealValue = (int)Math.Round((100 * Sprzedaz.Brutto() / Zakup.Brutto()) - 100, 0);
        }
    }
}
