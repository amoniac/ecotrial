using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misc;

namespace Exec
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Rate(0.1);

            var capital = 100.0d;
            var t = 5d;

            Console.WriteLine($"${capital} in {t} years = {r.Linear(capital, t)}");
            Console.WriteLine($"${capital} in {t} years = {r.Compound(capital, t)}");
            Console.WriteLine($"${capital} in {t} years = {r.CompoundExp(capital, t)}");

            Console.WriteLine($"${capital} pv for {t} years = {r.PresentValue(capital, t)}");
            Console.WriteLine($"${capital} pv for {t} years = {r.PresentValueExp(capital, t)}");

            double An = r.Annuity(capital, t, 1);
            Console.WriteLine($"${capital} annuity for {t} years = {r.Annuity(capital, t, 1)}");
            Console.WriteLine($"Present value for annuity {An} is {r.AnnuityPresentValue(An, t,0)}");

            double AeN = r.AnnuityExp(1, t, 1/12d);
            Console.WriteLine($"$1 annuity/month for {t} years = {r.AnnuityExp(1, t, 1/12d)}");
            Console.WriteLine($"Present value for annuity {AeN} is {r.AnnuityPresentValueExp(AeN, 1)}");



            Console.ReadKey();


        }
    }
}
