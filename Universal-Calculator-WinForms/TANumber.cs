namespace Universal_Calculator_WinForms
{
    abstract class TANumber //абстрактный класс число
    {
        public abstract TANumber Add(TANumber n);
        public abstract TANumber Mul(TANumber n);
        public abstract TANumber Sub(TANumber n);
        public abstract TANumber Div(TANumber n);
        public abstract TANumber Sqr();
        public abstract TANumber Rev();
        public abstract TANumber Copy();
        public abstract bool Equals(TANumber n);
        public abstract override string ToString();
        public abstract string StrNumber { get; set; }
        public abstract int IntP { get; set; }
        public abstract bool isZero();
    }
}
