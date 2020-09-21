using System;
using System.Runtime.Remoting.Messaging;

namespace SzukaczCeny
{
    public class ZaoManager
    {
        public double Calculate(double value)
        {
            return Math.Round(value,2,MidpointRounding.AwayFromZero);
        }
    }
}