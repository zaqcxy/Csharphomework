using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ordertest {
	/// <summary>
	/// OrderService:provide ordering service,
	/// like add order, remove order, query order and so on
	/// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
	/// </summary>
	public class OrderService {
        private List<Order> orderList;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService() {
            orderList = new List<Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order) {
            foreach (Order o in orderList) {
                if (o.Id.Equals(order.Id)) {
                    throw new Exception($"order-{order.Id} is already existed!");
                }
            }
            orderList.Add(order);
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns>
        public Order GetById(uint orderId) {
            var res = from o in orderList where o.Id == orderId select o;
            foreach (Order o in res) {
                return o;
            }
            return null;
        }

        /// <summary>
        /// remove order
        /// </summary>
        /// <param name="orderId">id of the order which will be removed</param>
        public void RemoveOrder(uint orderId) {
            Order order = GetById(orderId);
            if (order == null) return;
            orderList.Remove(order);
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns>
        public List<Order> QueryAllOrders() {
            return orderList;
        }


        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns>
        public List<Order> QueryByGoodsName(string goodsName) {
            var res = orderList.Where(
                o => o.Details.Exists(
                    d => d.Goods.Name == goodsName));
            return res.ToList();
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns>
        public List<Order> QueryByCustomerName(string customerName) {
            var query = orderList
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public void SortByPrice() {
            orderList.Sort((order1, order2) => {
                return order1.SumOfPrice().CompareTo(order2.SumOfPrice());
            });
        }

        public void Export(string path) {
            XmlSerializer ser = new XmlSerializer(typeof(List<Order>));
            try {
                System.IO.FileStream file = System.IO.File.Create(path);
                ser.Serialize(file, orderList);
                file.Close();
            } catch (Exception e) {
                throw e;
            }
        }

        public List<Order> Import(string path) {
            XmlSerializer ser = new XmlSerializer(typeof(List<Order>));
            System.IO.FileStream file = System.IO.File.Create(path);
            List<Order> res = new List<Order>();
            try {
                res = (List<Order>)ser.Deserialize(file);
            } catch (Exception e) {
                throw e;
            }
            file.Close();
            return res;
        }
    }
}
