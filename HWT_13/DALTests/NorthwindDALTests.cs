namespace DAL.Tests
{
    using DAL.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Linq;

    [TestClass]
    public class OrderDALTests
    {
        [TestMethod]
        public void GetOrdersTest()
        {
            int expected;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select COUNT(*) From Northwind.Orders";
                command.CommandType = CommandType.Text;
                expected = (int)command.ExecuteScalar();

                connection.Close();
            }
                
            NorthwindDAL testDAL = new NorthwindDAL();
            List<Order> orders = testDAL.GetOrders();
            Assert.AreEqual(expected, orders.Count());
        }

        [TestMethod]
        public void GetOrderInfoTest()
        {
            const decimal expected = 440;
            Order order = new Order();
            order.OrderID = 10248;

            NorthwindDAL testDAL = new NorthwindDAL();
            OrderInfo orderInfo = testDAL.GetOrderInfo(order.OrderID.Value);
            decimal actual = orderInfo.GetTotalCost();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            int expected;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select COUNT(*) From Northwind.Orders";
                command.CommandType = CommandType.Text;
                expected = (int)command.ExecuteScalar();

                connection.Close();
            }

            expected++;
            NorthwindDAL testDAl = new NorthwindDAL();
            testDAl.AddOrder();
            int actual;

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select COUNT(*) From Northwind.Orders";
                command.CommandType = CommandType.Text;
                actual = (int)command.ExecuteScalar();

                connection.Close();
            }

            Assert.AreEqual(expected, actual);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                const int ID = 11077;

                var command = connection.CreateCommand();
                command.CommandText = "Delete From Northwind.Orders" +
                    " Where OrderID > @LastID";//todo pn лучше не хардкодить в запросах по тем же причинам, почему не нужно вообще хардкодить.
                command.CommandType = CommandType.Text;

                var lastID = command.CreateParameter();
                lastID.DbType = DbType.Int32;
                lastID.ParameterName = "@LastID";
                lastID.Value = ID;
                command.Parameters.Add(lastID);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        [TestMethod]
        public void SetOrderDateTest()
        {
            DateTime oldDate = new DateTime(1996, 7, 4);
            Order order = new Order();
            order.OrderID = 10248;
            DateTime expected = new DateTime(2000, 1, 1);

            NorthwindDAL testDAL = new NorthwindDAL();
            testDAL.SetOrderDate(order.OrderID.Value, expected);

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);
            DateTime actual;

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select OrderDate " +
                    "From Northwind.Orders " +
                    "Where OrderID = @orderID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = order.OrderID;
                command.Parameters.Add(orderID);

                actual = (DateTime)command.ExecuteScalar();

                connection.Close();
            }

            Assert.AreEqual(expected, actual);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Update Northwind.Orders " +
                    "Set OrderDate = @orderDate " +
                    "Where OrderID = @orderID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = order.OrderID;
                command.Parameters.Add(orderID);

                var orderDate = command.CreateParameter();
                orderDate.ParameterName = "@orderDate";
                orderDate.DbType = DbType.DateTime;
                orderDate.Value = oldDate;
                command.Parameters.Add(orderDate);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        [TestMethod]
        public void SetShippedDateTest()
        {
            DateTime oldDate = new DateTime(1996, 7, 16);
            Order order = new Order();
            order.OrderID = 10248;
            DateTime expected = new DateTime(2000, 1, 1);

            NorthwindDAL testDAL = new NorthwindDAL();
            testDAL.SetShippedDate(order.OrderID.Value, expected);

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);
            DateTime actual;

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ShippedDate " +
                    "From Northwind.Orders " +
                    "Where OrderID = @orderID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = order.OrderID;
                command.Parameters.Add(orderID);

                actual = (DateTime)command.ExecuteScalar();

                connection.Close();
            }

            Assert.AreEqual(expected, actual);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Update Northwind.Orders " +
                    "Set ShippedDate = @shippedDate " +
                    "Where OrderID = @orderID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = order.OrderID;
                command.Parameters.Add(orderID);

                var shippedDate = command.CreateParameter();
                shippedDate.ParameterName = "@shippedDate";
                shippedDate.DbType = DbType.DateTime;
                shippedDate.Value = oldDate;
                command.Parameters.Add(shippedDate);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        [TestMethod]
        public void GetCustomerHistoryTest()
        {
            const int expected = 174;
            string customerID = "ALFKI";

            NorthwindDAL testDAL = new NorthwindDAL();
            CustomerOrderHistory customerHistory = testDAL.GetCustomerHistory(customerID);
            int actual = customerHistory.TotalQuantity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderInfoStoredTest()
        {
            const decimal expected = 440;
            Order order = new Order();
            order.OrderID = 10248;

            NorthwindDAL testDAL = new NorthwindDAL();
            OrderInfo orderInfo = testDAL.GetOrderInfoStored(order.OrderID.Value);
            decimal actual = orderInfo.GetTotalCost();

            Assert.AreEqual(expected, actual);
        }
    }
}