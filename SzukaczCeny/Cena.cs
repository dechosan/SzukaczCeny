using System;

namespace SzukaczCeny
{
    public class Cena : ICena
    {   public double CenaNetto { get; set; }

        public double Brutto()
        {
            return Math.Round(CenaNetto * 1.23, 2, MidpointRounding.AwayFromZero); ;
        }

        public double Netto()
        {
            return CenaNetto;
        }

        public double VAT()
        {
            return Brutto() - CenaNetto;
        }
    }
}
