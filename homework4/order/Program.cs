using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public int id;
        public string name;
        public string customer;
        public Order(int id,string name,string customer)
        {
            this.id = id;
            this.name = name;
            this.customer = customer;
        } 
        public bool checkid(int id)
        {
            return this.id == id;
        }
        public bool checkname(string name)
        {
            return this.name == name;
        }
        public bool checkcustomer(string customer)
        {
            return this.customer == customer;
        }
        public void print()
        {
            Console.WriteLine(this.id);
            Console.WriteLine(this.name);
            Console.WriteLine(this.customer);
        }
    }
    public class Find_abnormal : Exception
    {
        public string a;
        public Find_abnormal(string a) : base(a)
        {
            this.a = a;
        }
    }
    public class OrderService
    {
        public List<Order> orders = new List<Order>();
        public int num = 0;
        public void Add(string name,string customer)
        {
            orders.Add(new Order(++num, name, customer));
        }
        public void Delbyid(int id)
        {
            bool flag = false;
            for(int i=0;i<orders.Count;i++)
                if(orders[i].checkid(id))
                {
                    flag = true;
                    break;
                }
            if(flag==false)
            {
                string a = "Can not find the order";
                var h =new Find_abnormal(a);
                throw h;
            }
        }
        public void changebyid(int id,string customer)
        {
            bool flag = false;
            for (int i = 0; i < orders.Count; i++)
                if (orders[i].checkid(id))
                {
                    flag = true;
                    orders[i].customer = customer;
                    break;
                }
            if (flag == false)
            {
                string a = "Can not find the order";
                var h = new Find_abnormal(a);
                throw h;
            }
        }
        public Order findbyid(int id)
        {
            bool flag = false;
            for (int i = 0; i < orders.Count; i++)
                if (orders[i].checkid(id))
                    return orders[i];
            return null;
        }
        public List<Order> findbyname(string name)
        {
            var now_order = new List<Order>();
            for(int i=0;i<orders.Count;i++)
                if(orders[i].name==name)    
                    now_order.Add(orders[i]);
            return now_order;
        }
        public List<Order> findbycustomer(string customer)
        {
            var now_order = new List<Order>();
            for (int i = 0; i < orders.Count; i++)
                if (orders[i].customer == customer)
                    now_order.Add(orders[i]);
            return now_order;
        }
    }
    public class Progarm
    {
        static void Main(string[] agrs)
        {
            var now_s = new OrderService();
            now_s.Add("1", "myc");
            now_s.Add("2", "myc");
            now_s.Add("1", "cxy");
            now_s.Add("2", "cxy");
            try
            {
                now_s.findbycustomer("myc")[0].print();
                now_s.Delbyid(3);
                now_s.Delbyid(10);
            }
            catch (Find_abnormal a)
            {
                Console.WriteLine(a.a);
            }
            try
            {
                now_s.findbyname("1")[0].print();
                now_s.findbyid(1).print();
            }
            catch (Find_abnormal a)
            {
                Console.WriteLine(a.a);
            }
        }
    }
}
