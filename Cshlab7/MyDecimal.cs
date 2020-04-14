using System;
using System.Text.RegularExpressions;

namespace Cshlab7
{
    class MyDecimal : IComparable<MyDecimal>
    {
        private long _n, _m;
        public MyDecimal(long n, long m)
        {
            _n = n;
            _m = m;
            Reduction();
        }        
        public static long Gcd(long x, long y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (x != 0 && y != 0)
                if (x > y) x %= y;
                else y %= x;
            return x + y;
        }
        public static long Lcm(long x, long y)
        {
            long temp = Gcd(x, y);
            return x / temp * y;
        }

        public int CompareTo(MyDecimal other)
        {
            double temp = this - other;
            if (temp > 0) return 1;
            else
            if (temp < 0) return -1;
            else
                return 0;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                MyDecimal other = (MyDecimal)obj;
                return CompareTo(other) == 0;
            }
        }

        public override int GetHashCode()
        {
            return (int)((_n << 2) ^ _m);
        }


        public static explicit operator long(MyDecimal value) => value._n / value._m;

        public static explicit operator int(MyDecimal value) => (int)(value._n / value._m);

        public static implicit operator double(MyDecimal value) => (double)value._n / (double)value._m;

        public static explicit operator bool(MyDecimal value) => value != 0;

        public static explicit operator string(MyDecimal value) => Convert.ToString((double)value);

        public static explicit operator MyDecimal(double value)
        {
            string s = value.ToString();
            int i = s.Length - 1;
            long d = 1;
            while (s[i] != ',')
            {
                if (i == 0)
                {
                    d = 1;
                    break;
                }
                i--;
                d *= 10;
            }
            MyDecimal temp = new MyDecimal((long)(value * d), d);            
            return temp;
        }
        public static implicit operator MyDecimal(int value) => new MyDecimal(value, 1);
        public static explicit operator MyDecimal(string value)
        {
            value = Regex.Replace(value, "[.]", ",");
            Regex regex = new Regex(@"^-?\d{1,8},\d{1,8}");
            Match match = regex.Match(value);
            if (match.Success)
                return (MyDecimal)Convert.ToDouble(match.Groups[0].Value);

            regex = new Regex(@"^(-?\d{1,17})[:/](-?[1-9]\d{0,16})");
            match = regex.Match(value);
            if (match.Success)
                return new MyDecimal(Convert.ToInt32(match.Groups[1].Value),Convert.ToInt32(match.Groups[2].Value));
            regex = new Regex(@"^-?\d{1,17}");
            match = regex.Match(value);
            if (match.Success)
                return Convert.ToInt32(match.Groups[0].Value);

            throw new System.FormatException("value is not a number in a valid format.");        
        }

        public void Reduction()
        {
            long temp = Gcd(_n, _m);
            _n /= temp;
            _m /= temp;
            if (_m < 0)
            {
                _n *= -1;
                _m *= -1;
            }
        }

        public static MyDecimal operator +(MyDecimal x, MyDecimal y)
        {
            long lcm = Lcm(x._m, y._m);
            MyDecimal temp = new MyDecimal(x._n * (lcm / x._m) + y._n * (lcm / y._m), lcm);            
            return temp;
        }
        public static MyDecimal operator -(MyDecimal x, MyDecimal y)
        {
            long lcm = Lcm(x._m, y._m);
            MyDecimal temp = new MyDecimal(x._n * (lcm / x._m) - y._n * (lcm / y._m), lcm);            
            return temp;
        }
        public static MyDecimal operator *(MyDecimal x, MyDecimal y)
        {
            MyDecimal temp = new MyDecimal(x._n * y._n, x._m * y._m);            
            return temp;
        }
        public static MyDecimal operator /(MyDecimal x, MyDecimal y)
        {
            MyDecimal temp = new MyDecimal(x._n * y._m, x._m * y._n);            
            return temp;
        }

        public static bool operator <(MyDecimal x, MyDecimal y) => x.CompareTo(y) < 0;
        public static bool operator >(MyDecimal x, MyDecimal y) => x.CompareTo(y) > 0;
        public static bool operator ==(MyDecimal x, MyDecimal y) => x.CompareTo(y) == 0;
        public static bool operator !=(MyDecimal x, MyDecimal y) => x.CompareTo(y) != 0;
        public static bool operator <=(MyDecimal x, MyDecimal y) => x.CompareTo(y) <= 0;
        public static bool operator >=(MyDecimal x, MyDecimal y) => x.CompareTo(y) >= 0;
    }
}
