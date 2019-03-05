using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数");
            int x = int.Parse(Console.ReadLine());
            int flag = 0;
            Console.WriteLine("x的素数因子有：" );
            for (int i=2;i<=x;i++)
                if(x%i==0)
                {
                    while (x % i == 0)
                        x /= i;
                    Console.Write(i+" ");
                }
            Console.Write("\n");
        }
    }
}
