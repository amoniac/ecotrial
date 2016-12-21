using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class Rate
    {
        private double r;
        private double delta;

        public Rate(double r)
        {
            this.r = r;
            delta = Math.Log(1 + r);
        }

        /// <summary>
        /// V = (1 + r * n) * v0
        /// 
        /// Värdet växer linjärt i tiden
        /// 
        /// </summary>
        /// <param name="v0">Kapital vid t=0</param>
        /// <param name="t"></param>
        /// <returns></returns>
        public double Linear(double v0, double t)
        {
            return (1 + r*t)*v0;
        }

        /// <summary>
        /// V = V0(1 + r)^t
        /// 
        /// År 1 K(1+r)
        /// År 2 K(1+r)(1+r)=K(1+r)^2
        /// ..
        ///
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public double Compound(double v0, double t)
        {
            return v0*Math.Pow(1 + r, t);
        }

        /// <summary>
        /// Kontinuerlig förräntning
        /// 
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public double CompoundExp(double v0, double t)
        {
            return v0*Math.Exp(delta*t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public double PresentValueExp(double v0, double t)
        {
            return v0*Math.Exp(-delta*t);
        }

        public double PresentValue(double v0, double t)
        {
            return v0* Math.Pow(1/(1 + r),t);
        }

        /// <summary>
        /// (1+r)^n-1 = $1 from year 1
        /// (1+r)^n-1 = $1 from year 2
        /// (1+r)^n-1 = $1 from year 3
        /// ...
        /// = (1+r)^n-1 / r
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="t"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public double Annuity(double v0, double t, double p)
        {
            return v0 * (Math.Pow(1 + r, t) - 1)/r;
        }

        /// <summary>
        /// Nuvärdet av annuiteten
        /// Sn * (1+r)^-n
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="t"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public double AnnuityPresentValue(double v0, double t, double p)
        {
            return v0*Math.Pow(1 + r, -t);
        }

        public double AnnuityExp(double v0, double t, double step)
        {
            var s=0d;
            for (double n = 0; n < t; n+=step)
            {
                s+=Math.Exp(delta*(t-n));
            }
            return s*v0;
        }

        public double AnnuityPresentValueExp(double v0, double t)
        {
            var method1 = (1 - Math.Exp(-delta*t))/delta;   //?
            var method2 = v0 * Math.Exp(-delta * t);

            return method2;
        }



    }
}
