namespace Universal_Calculator_WinForms
{
    class TPNumber : TANumber//класс p-ичное число
    {
        private double number;//поле число
        private int p;//основание сс
        private int accuracy;//точность задания числа

        //конструктор для числа в десятичной сс
        public TPNumber(double n, int p, int accuracy)
        {
            number = n;
            this.p = p;
            this.accuracy = accuracy;
        }

        //конструктор для числа заданного в виде строки
        public TPNumber(string value, int p, int accuracy)
        {
            number = Convert_p_10.Do(value, p);
            this.p = p;
            this.accuracy = accuracy;
        }

        //св-во для получения числа в строковом виде
        public override string StrNumber
        {
            get { return Convert_10_p.Do(number, p, accuracy); }
            set { number = Convert_p_10.Do(value, p); }
        }

        //св-во для получения числа в десятичном виде
        public double DecimalNumber
        {
            get { return number; }
            set { number = value; }
        }

        //св-во для получения/задания основания в строковом виде
        public string StrP
        {
            get { return p.ToString(); }
            set { p = Convert.ToInt32(value); }
        }

        //св-во для получения/задания основания в числовом виде
        public override int IntP
        {
            get { return p; }
            set { p = value; }
        }

        //св-во для получения/задания точности в числовом виде
        public int IntAcc
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        //св-во для получения/задания точности в строковом виде
        public string StrAcc
        {
            get { return accuracy.ToString(); }
            set { accuracy = Convert.ToInt32(value); }
        }

        //операция сложения
        public override TANumber Add(TANumber n)
        {
            return new TPNumber(number + (n as TPNumber).DecimalNumber, p, Math.Max(accuracy, (n as TPNumber).IntAcc));
        }

        //операция произведения
        public override TANumber Mul(TANumber n)
        {
            return new TPNumber(number * (n as TPNumber).DecimalNumber, p, Math.Max(accuracy, (n as TPNumber).IntAcc));
        }

        //операция вычитания
        public override TANumber Sub(TANumber n)
        {
            return new TPNumber(number - (n as TPNumber).DecimalNumber, p, Math.Max(accuracy, (n as TPNumber).IntAcc));
        }

        //операция деления
        public override TANumber Div(TANumber n)
        {
            return new TPNumber(number / (n as TPNumber).DecimalNumber, p, Math.Max(accuracy, (n as TPNumber).IntAcc));
        }

        //операция сравнения
        public override bool Equals(TANumber n)
        {
            if (number == (n as TPNumber).DecimalNumber && accuracy == (n as TPNumber).IntAcc)
            {
                return true;
            }
            return false;
        }

        //возведение в квадрат
        public override TANumber Sqr()
        {
            return new TPNumber(number * number, p, accuracy);
        }

        //обращение числа
        public override TANumber Rev()
        {
            return new TPNumber(1 / number, p, accuracy);
        }

        //перобразование числа в строку
        public override string ToString()
        {
            return Convert_10_p.Do(number, p, accuracy);
        }

        //создание копии
        public override TANumber Copy()
        {
            return new TPNumber(number, p, accuracy);
        }

        public override bool isZero()
        {
            return number == 0;
        }
    }
}
