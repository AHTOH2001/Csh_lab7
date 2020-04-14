using System;


namespace Cshlab7
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDecimal x = new MyDecimal(-21, 30);
            MyDecimal y = new MyDecimal(-5, 15);
            MyDecimal temp1 = x * y;    
            MyDecimal temp2 = x / y;    
            MyDecimal temp3 = x + y;    
            MyDecimal temp4 = x - y;    
            Console.WriteLine(temp1);   //  7/30
            Console.WriteLine(temp2);   //  21/10
            Console.WriteLine(temp3);   //  -31/30
            Console.WriteLine(temp4);   //  -11/30
            double p = 1 / 3.0;
            temp1 = (MyDecimal)p;
            Console.WriteLine(temp1);   //  3333333333333333/10000000000000000

            string s = "-78939427/437,98 3zj7.3j";
            temp1 = (MyDecimal)s;
            Console.WriteLine(temp1);   //-3432149/19

            s = "-7893427.435,98 3zj7.3j";
            temp1 = (MyDecimal)s;
            Console.WriteLine(temp1);   //  -1578685487/200

            s = "-7893427/0 ,98 3zj7.3j";
            temp1 = (MyDecimal)s;
            Console.WriteLine(temp1);   //  -7893427/1  cause reads only -7893427

            s = "-7893427:-123 ,98 3zj7.3j";
            temp1 = (MyDecimal)s;
            Console.WriteLine(temp1);   //  7893427/123

            s = (string)temp1;
            Console.WriteLine(s);       //  "64174,20325203252"

            temp1 = (MyDecimal)0.125;
            Console.WriteLine(temp1);   //  1/8

            temp2 = new MyDecimal(1, 8);                        

            if (temp1 <= temp2) Console.WriteLine($"{(double)temp1} <= {(double)temp2}"); 
            else Console.WriteLine($"{(double)temp1} > {(double)temp2}");
            if (temp1 == temp2) Console.WriteLine($"{(double)temp1} == {(double)temp2}");
            else Console.WriteLine($"{(double)temp1} != {(double)temp2}");
            if (temp1 < temp2) Console.WriteLine($"{(double)temp1} < {(double)temp2}");
            else Console.WriteLine($"{(double)temp1} >= {(double)temp2}");


        }
    }
}
