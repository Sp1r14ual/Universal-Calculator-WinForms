namespace Universal_Calculator_WinForms
{
    class TComplex : TANumber //класс комплексное число
    {
        private TPNumber Re;
        private TPNumber Im;

        public TComplex(double re, double im)
        {
            Re = new TPNumber(re, 10, 8);
            Im = new TPNumber(im, 10, 8);
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
            return new TComplex(Re.DecimalNumber + (n as TComplex).Re.DecimalNumber, Im.DecimalNumber + (n as TComplex).Im.DecimalNumber);
        }

        public override TANumber Mul(TANumber n)
        {
            return new TComplex(Re.DecimalNumber * (n as TComplex).Re.DecimalNumber - Im.DecimalNumber * (n as TComplex).Im.DecimalNumber,
                               Re.DecimalNumber * (n as TComplex).Im.DecimalNumber + Im.DecimalNumber * (n as TComplex).Re.DecimalNumber);
        }

        public override TANumber Sub(TANumber n)
        {
            return new TComplex(Re.DecimalNumber - (n as TComplex).Re.DecimalNumber, Im.DecimalNumber - (n as TComplex).Im.DecimalNumber);
        }

        public override TANumber Div(TANumber n)
        {
            return new TComplex((Re.DecimalNumber * (n as TComplex).Re.DecimalNumber + Im.DecimalNumber * (n as TComplex).Im.DecimalNumber) /
                               (Math.Pow((n as TComplex).Im.DecimalNumber, 2) + Math.Pow((n as TComplex).Re.DecimalNumber, 2)),
                               (Im.DecimalNumber * (n as TComplex).Re.DecimalNumber - Re.DecimalNumber * (n as TComplex).Im.DecimalNumber) /
                               (Math.Pow((n as TComplex).Im.DecimalNumber, 2) + Math.Pow((n as TComplex).Re.DecimalNumber, 2)));
        }

        public override bool Equals(TANumber n)
        {
            if (Re.Equals((n as TComplex).Re) && Im.Equals((n as TComplex).Im))
            {
                return true;
            }
            return false;
        }

        public override TANumber Sqr()
        {
            return new TComplex(Re.DecimalNumber * Re.DecimalNumber - Im.DecimalNumber * Im.DecimalNumber, Re.DecimalNumber * Im.DecimalNumber + Re.DecimalNumber * Im.DecimalNumber);
        }

        public override TANumber Rev()
        {
            return new TComplex(Re.DecimalNumber / (Math.Pow(Re.DecimalNumber, 2) + Math.Pow(Im.DecimalNumber, 2)), -Im.DecimalNumber / (Math.Pow(Re.DecimalNumber, 2) + Math.Pow(Im.DecimalNumber, 2)));
        }

        public override string ToString()
        {
            return Re + "i" + Im;
        }

        public override TANumber Copy()
        {
            return new TComplex(Re.DecimalNumber, Im.DecimalNumber);
        }

        public override bool isZero()
        {
            return Re.DecimalNumber == 0 && Im.DecimalNumber == 0;
        }

        private void FromString(string s)
        {
            if (s.IndexOf("i") != -1 && s.IndexOf("i") < s.Length - 1)
            {
                Re.StrNumber = s.Substring(0, s.IndexOf("i"));
                Im.StrNumber = s.Substring(s.IndexOf("i") + 1);
            }
            else if (s.IndexOf("i") == s.Length - 1)
            {
                Re.StrNumber = s.Substring(0, s.IndexOf("i"));
                Im.StrNumber = "0";
            }
            else
            {
                Re.StrNumber = s;
                Im.StrNumber = "0";
            }
        }
    }
}
