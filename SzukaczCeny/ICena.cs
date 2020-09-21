using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzukaczCeny
{
    public interface ICena 
    {
        double Netto();
        double Brutto();
        double VAT();
    }
}
