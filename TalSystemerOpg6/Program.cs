using Binary;
using System;

namespace TalSystemerOpg6 {

    public class Program {

        public static void Main() {
            BinaryNumber b1 = new BinaryNumber("1101");
            Console.WriteLine(b1);
            Console.WriteLine(b1.ToStr());
            Console.WriteLine(b1.ToInt());
            BinaryNumber b2 = new BinaryNumber(19);
            Console.WriteLine(b2);
            BinaryNumber b3 = b1 + b2;
            Console.WriteLine(b3);
        }
    }
}