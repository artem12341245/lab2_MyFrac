using System;

namespace lab2_MyFrac
{
    public class MyFrac
    {
        private long nom;
        private long denom;

        public long Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
            }
        }

        public long Denom
        {
            get
            {
                return denom;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменник не може бути нулем.", nameof(value));
                }
                denom = value;
            }
        }

        public MyFrac(long nom, long denom)
        {
            if (denom == 0)
            {
                throw new ArgumentException("Знаменник не може бути нулем.", nameof(denom));
            }

            this.nom = nom;
            this.denom = denom;
        }

        public MyFrac()
        {
            nom = 1;
            denom = 1;
        }

        public MyFrac(MyFrac other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            nom = other.nom;
            denom = other.denom;
        }

        public override string ToString()
        {
            return nom + " / " + denom;
        }

        public MyFrac Normalize()
        {
            if (nom == 0)
            {
                return new MyFrac(0, 1);
            }

            long a = Math.Abs(nom);
            long b = Math.Abs(denom);

            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }

            long sign = (nom < 0) ^ (denom < 0) ? -1L : 1L;
            long normNom = sign * (Math.Abs(nom) / a);
            long normDenom = Math.Abs(denom) / a;

            return new MyFrac(normNom, normDenom);
        }

        public string ToStringWithIntPart()
        {
            MyFrac norm = Normalize();
            long absNom = Math.Abs(norm.nom);
            long absDenom = Math.Abs(norm.denom);
            long intPart = absNom / absDenom;
            long remNom = absNom % absDenom;

            string sign = norm.nom < 0 ? "-" : "";

            if (remNom == 0)
            {
                return sign + intPart;
            }

            return sign + "(" + intPart + " + " + remNom + "/" + absDenom + ")";
        }

        public double DoubleValue()
        {
            return (double)nom / (double)denom;
        }

        public static MyFrac operator +(MyFrac f1, MyFrac f2)
        {
            if (f1 == null || f2 == null)
            {
                throw new ArgumentNullException("Дріб не може бути null.");
            }

            long resNom = f1.nom * f2.denom + f2.nom * f1.denom;
            long resDenom = f1.denom * f2.denom;
            return new MyFrac(resNom, resDenom).Normalize();
        }

        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            if (f1 == null || f2 == null)
            {
                throw new ArgumentNullException("Дріб не може бути null.");
            }

            long resNom = f1.nom * f2.denom - f2.nom * f1.denom;
            long resDenom = f1.denom * f2.denom;
            return new MyFrac(resNom, resDenom).Normalize();
        }

        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            if (f1 == null || f2 == null)
            {
                throw new ArgumentNullException("Дріб не може бути null.");
            }

            long resNom = f1.nom * f2.nom;
            long resDenom = f1.denom * f2.denom;
            return new MyFrac(resNom, resDenom).Normalize();
        }

        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            if (f1 == null || f2 == null)
            {
                throw new ArgumentNullException("Дріб не може бути null.");
            }

            if (f2.nom == 0)
            {
                throw new DivideByZeroException("Ділення на нульовий дріб неможливе.");
            }

            long resNom = f1.nom * f2.denom;
            long resDenom = f1.denom * f2.nom;
            return new MyFrac(resNom, resDenom).Normalize();
        }
    }
}