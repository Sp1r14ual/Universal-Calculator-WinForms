namespace Universal_Calculator_WinForms
{
    class TFrac : TANumber //класс дробь
    {
        private TPNumber num;
        private TPNumber dnom;

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private KeyValuePair<int, int> unify_fraction(int a, int b)
        {
            int num = a;
            int den = b;
            int gcd = GCD(Math.Abs(a), Math.Abs(b));

            if (gcd > 1)
            {
                if ((a < 0 && b < 0) || (a > 0 && b > 0))
                {
                    num = Math.Abs(a) / gcd;
                    den = Math.Abs(b) / gcd;
                }
                else
                {
                    //a = a > 0 ? a / gcd : -(Math.Abs(a) / gcd);
                    //b = b > 0 ? b / gcd : -(Math.Abs(b) / gcd);

                    num = a < 0 ? a / gcd : -a / gcd;
                    den = Math.Abs(b) / gcd;
                }
            }

            return new KeyValuePair<int, int>(num, den);
        }
        public TFrac()
        {
            num = new TPNumber(0, 10, 8);
            dnom = new TPNumber(1, 10, 8);
        }

        public TFrac(int n)
        {
            num = new TPNumber(n, 10, 8);
            dnom = new TPNumber(1, 10, 8);
        }

        public TFrac(double n, double dn)
        {
            KeyValuePair<int, int> fraction = unify_fraction(Convert.ToInt32(n), Convert.ToInt32(dn));

            num = new TPNumber(fraction.Key, 10, 8);
            dnom = new TPNumber(fraction.Value, 10, 8);
        }

        public override string StrNumber
        {
            get { return ToString(); }
            set { FromString(value); }
        }

        public override int IntP
        {
            get { return 10; }
            set { }
        }

        public override TANumber Add(TANumber n)
        {
            return new TFrac(num.DecimalNumber * (n as TFrac).dnom.DecimalNumber + dnom.DecimalNumber * (n as TFrac).num.DecimalNumber, dnom.DecimalNumber * (n as TFrac).dnom.DecimalNumber);
        }

        public override TANumber Mul(TANumber n)
        {
            return new TFrac(num.DecimalNumber * (n as TFrac).num.DecimalNumber, dnom.DecimalNumber * (n as TFrac).dnom.DecimalNumber);
        }

        public override TANumber Sub(TANumber n)
        {
            return new TFrac(num.DecimalNumber * (n as TFrac).dnom.DecimalNumber - dnom.DecimalNumber * (n as TFrac).num.DecimalNumber, dnom.DecimalNumber * (n as TFrac).dnom.DecimalNumber);
        }

        public override TANumber Div(TANumber n)
        {
            return new TFrac(num.DecimalNumber * (n as TFrac).dnom.DecimalNumber, dnom.DecimalNumber * (n as TFrac).num.DecimalNumber);
        }

        public override bool Equals(TANumber n)
        {
            if (num.Equals((n as TFrac).num))
            {
                return true;
            }
            return false;
        }

        public override TANumber Sqr()
        {
            return new TFrac(num.DecimalNumber * num.DecimalNumber, dnom.DecimalNumber * dnom.DecimalNumber);
        }

        public override TANumber Rev()
        {
            return new TFrac(dnom.DecimalNumber, num.DecimalNumber);
        }

        public override string ToString()
        {
            return num + "/" + dnom;
        }

        public override TANumber Copy()
        {
            return new TFrac(num.DecimalNumber, dnom.DecimalNumber);
        }

        private void FromString(string s)
        {
            if (s.IndexOf("/") != -1 && s.IndexOf("/") < s.Length - 1)
            {
                num.StrNumber = s.Substring(0, s.IndexOf("/"));
                dnom.StrNumber = s.Substring(s.IndexOf("/") + 1);
            }
            else if (s.IndexOf("/") == s.Length - 1)
            {
                num.StrNumber = s.Substring(0, s.IndexOf("/"));
                dnom.StrNumber = "0";
            }
            else
            {
                num.StrNumber = s;
                dnom.StrNumber = "0";
            }
        }

        public override bool isZero()
        {
            return num.DecimalNumber == 0 && dnom.DecimalNumber == 0;
        }
    }
}
