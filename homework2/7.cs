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
            Console.WriteLine("请输入数组元素个数n：");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("按行请输入数组的各个元素每行一个");
            for(int i=1;i<=n;i++)
                 a[i]= int.Parse(Console.ReadLine());
            int max1 = a[1], min1 = a[1];
            int sum = 0;
            double ave = 0;
            for(int i=1;i<=n;i++)
            {
                max1 = (a[i] > max1 ? max1 : a[i]);
                min1 = (a[i] < min1 ? a[i] : min1);
                sum += a[i];
            }
            ave = (double)sum * 1.000 /  n;
            Console.WriteLine("最大值是：" + max1);
            Console.WriteLine("最小值是：" + min1);
            Console.WriteLine("总和是：" + sum);
            Console.WriteLine("平均值是：" + ave);
        }
    }
}
