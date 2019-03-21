using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //声明参数类型
    public class Alarmclock: EventArgs{
        public int h { get; set; }
        public int m { get; set; }
        public int s { get; set; }
        public int w { get; set; }
    }
    //声明委托类型
    public delegate void AlarmclockEventHandler(object sender, Alarmclock args);
    //定义事件
    public class Alarm
    {
        public event AlarmclockEventHandler alarm;
        public void get_time(int x, int y, int z)
        {
            Alarmclock nowtime = new Alarmclock()
            {
                h = x,
                m = y,
                s = z,
                w=x*60*60+y*60+z,
            };
            alarm(this, nowtime);
        }
    }
    public class Progarm
    {
        static void Main(string[] agrs)
        {
            //设置闹钟时间
            Alarm time = new Alarm();
            time.alarm += deal;
            /*int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());*/
            time.get_time(12, 0, 10);
        }
        static void deal(object sendeer, Alarmclock args)
        {
            //假定当前时间为12：00；
            int t = args.w-12 * 60 * 60;
            Console.WriteLine("Alarm clock will alarm in " + t + " s");
            System.Threading.Thread.Sleep(t*1000);
            Console.WriteLine("You need to get up");
        }
    }
}
