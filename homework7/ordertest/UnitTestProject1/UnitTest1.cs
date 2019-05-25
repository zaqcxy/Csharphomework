using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1 {
		public Order[] GetOrders() {
			Customer customer1 = new Customer(1, "Customer1");
			Customer customer2 = new Customer(2, "Customer2");

			Goods milk = new Goods(1, "Milk", 69.9);
			Goods eggs = new Goods(2, "eggs", 4.99);
			Goods apple = new Goods(3, "apple", 5.59);

			OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
			OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
			OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

			Order[] orders = new Order[3];
			orders[0] = new Order(1, customer1);
			orders[1] = new Order(2, customer2);
			orders[2] = new Order(3, customer2);

			orders[0].AddDetails(orderDetails1);
			orders[0].AddDetails(orderDetails2);
			orders[0].AddDetails(orderDetails3);

			orders[1].AddDetails(orderDetails2);
			orders[1].AddDetails(orderDetails3);
			orders[2].AddDetails(orderDetails3);
			return orders;
		}
        [TestMethod]
        public void TestConstructor() {
			OrderService os = new OrderService();
			Assert.IsInstanceOfType(os, typeof(OrderService));
		}

		[TestMethod]
		public void TestAddOrder() {
			OrderService os = new OrderService();
			Order[] orders = GetOrders();
			os.AddOrder(orders[0]);
			Assert.ThrowsException<Exception>(() => { os.AddOrder(orders[0]); }, $"order-{orders[0].Id} is already existed!");
		}

		[TestMethod]
		public void TestGetById() {
			OrderService os = new OrderService();
			Order[] orders = GetOrders();
			os.AddOrder(orders[0]);
			Order o = os.GetById(123);
			Assert.IsNull(o);
			o = os.GetById(orders[0].Id);
			Assert.AreEqual(orders[0], o);
		}

		[TestMethod]
		public void TestRemoveOrder() {
			OrderService os = new OrderService();
			Order[] orders = GetOrders();
			os.AddOrder(orders[0]);
			Order o = os.GetById(1);
			Assert.AreEqual(o, orders[0]);
			os.RemoveOrder(1);
			Assert.IsNull(os.GetById(1));
		}

		[TestMethod]
		public void TestQueryAllOrders() {
			OrderService os = new OrderService();
			List<Order> orders = new List<Order>(GetOrders());
			foreach (Order o in orders) {
				os.AddOrder(o);
			}
			Assert.AreEqual(os.QueryAllOrders(), orders);
		}

		[TestMethod]
		public void TestQueryByGoodsName() {
			OrderService os = new OrderService();
			List<Order> orders = new List<Order>(GetOrders());
			foreach (Order o in orders) {
				os.AddOrder(o);
			}
			foreach (Order o in orders) {
				string name = o.Details[0].Goods.Name;
				List<Order> queryList = os.QueryByGoodsName(name);
				List<Order> expectList = new List<Order>();
				foreach (Order o2 in orders) {
					foreach (OrderDetail d in o2.Details) {
						if (d.Goods.Name == name) {
							expectList.Add(o2);
							break;
						}
					}
				}
				Assert.AreEqual(queryList, expectList);
			}
		}

		[TestMethod]
		public void TestQueryByCustomerName() {
			OrderService os = new OrderService();
			List<Order> orders = new List<Order>(GetOrders());
			foreach (Order o in orders) {
				os.AddOrder(o);
			}
			foreach (Order o in orders) {
				string name = o.Customer.Name;
				List<Order> queryList = os.QueryByCustomerName(name);
				List<Order> expectList = new List<Order>();
				foreach (Order o2 in orders) {
					if (o2.Customer.Name == name) {
						expectList.Add(o2);
					}
				}
				Assert.AreEqual(queryList, expectList);
			}
		}

		[TestMethod]
		public void TestSortByPrice() {
			OrderService os = new OrderService();
			List<Order> orders = new List<Order>(GetOrders());
			foreach (Order o in orders) {
				os.AddOrder(o);
			}
			os.SortByPrice();
			List<Order> queryOrders = os.QueryAllOrders();
			for (int i = 1; i < queryOrders.Count; i++) {
				Assert.IsTrue(queryOrders[i].SumOfPrice() > queryOrders[i - 1].SumOfPrice());
			}
		}


	}
}
