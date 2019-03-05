using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10000];
            for (int i = 1; i <= 100; i++)
                a[i] = 0;
            Console.Write("100以内的素数有：\n");
            for (int i=2;i<=100;i++)
                if(a[i]==0)
                {
                    Console.Write(i + " ");
                    for (int j = i + i; j <= 100; j += i)
                        a[j] = 1;
                }
        }
    }
}
