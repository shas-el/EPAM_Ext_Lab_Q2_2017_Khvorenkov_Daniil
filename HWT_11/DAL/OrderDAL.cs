namespace DAL
{
    using DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class OrderDAL
    {
        public List<Order> GetOrders()
        {
            List<Order> results = new List<Order>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select OrderID" +
                    ", CustomerID" +
                    ", EmployeeID" +
                    ", OrderDate" +
                    ", RequiredDate" +
                    ", ShippedDate" +
                    ", ShipVia" +
                    ", Freight" +
                    ", ShipName" +
                    ", ShipAddress" +
                    ", ShipCity" +
                    ", ShipRegion" +
                    ", ShipPostalCode" +
                    ", ShipCountry " +
                    "From Northwind.Orders";//todo pn нехорошо писать звездочку, потому что всегда таблица может измениться и мы долго будем искать, где у нас упало. Лучше перечислить все столбцы руками. Так будет безопаснее.
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.OrderID = (int)reader["OrderID"];
                        order.CustomerID = (reader["CustomerID"] == DBNull.Value)
                            ? null : (string)reader["CustomerID"];
                        order.EmployeeID = (reader["EmployeeID"] == DBNull.Value)
                            ? null : (int?)reader["EmployeeID"];
                        order.OrderDate = (reader["OrderDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["OrderDate"];
                        order.RequiredDate = (reader["RequiredDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["RequiredDate"];
                        order.ShippedDate = (reader["ShippedDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["ShippedDate"];
                        order.ShipVia = (reader["ShipVia"] == DBNull.Value)
                            ? null : (int?)reader["ShipVia"];
                        order.Freight = (reader["Freight"] == DBNull.Value)
                            ? null : (decimal?)reader["Freight"];
                        order.ShipName = (reader["ShipName"] == DBNull.Value)
                            ? null : (string)reader["ShipName"];
                        order.ShipAddress = (reader["ShipAddress"] == DBNull.Value)
                            ? null : (string)reader["ShipAddress"];
                        order.ShipCity = (reader["ShipCity"] == DBNull.Value)
                            ? null : (string)reader["ShipCity"];
                        order.ShipRegion = (reader["ShipRegion"] == DBNull.Value)
                            ? null : (string)reader["ShipRegion"];
                        order.ShipPostalCode = (reader["ShipPostalCode"] == DBNull.Value)
                            ? null : (string)reader["ShipPostalCode"];
                        order.ShipCountry = (reader["ShipCountry"] == DBNull.Value)
                            ? null : (string)reader["ShipCountry"];

                        if (order.OrderDate == null)
                        {
                            order.Status = OrderStatus.New;
                        }
                        else if (order.ShippedDate == null)
                        {
                            order.Status = OrderStatus.Underway;
                        }
                        else
                        {
                            order.Status = OrderStatus.Shipped;
                        }

                        results.Add(order);
                    }
                }

                connection.Close();
            }

            return results;
        }

        public OrderInfo GetOrderInfo(Order order)
        {
            OrderInfo orderInfo = new OrderInfo();
            orderInfo.OrderID = order.OrderID;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select p.ProductName" +
                    ", od.UnitPrice" +
                    ", od.Discount" +
                    ", od.Quantity" +
                    " From Northwind.Orders as o" +
                    " Inner Join Northwind.[Order Details] as od" +
                    " On o.OrderID = od.OrderID" +
                    " Inner Join Northwind.Products as p" +
                    " On od.ProductID = p.ProductID" +
                    " Where o.OrderID = @orderID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";//todo pn .AddWithValue не нравится?
                orderID.DbType = DbType.Int32;
                orderID.Value = order.OrderID;
                command.Parameters.Add(orderID);
                //command.Parameters.AddWithValue("@orderID", order.OrderID); для DbCommand нужно свой экстеншен писать, насколько я понял

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderInfoDetail detail = new OrderInfoDetail();
                        detail.ProductName = (string)reader["ProductName"];
                        detail.UnitPrice = (decimal)reader["UnitPrice"];
                        detail.Discount = (Single)reader["Discount"];
                        detail.Quantity = (Int16)reader["Quantity"];
                        orderInfo.Details.Add(detail);
                    }
                }

                connection.Close();
            }

            return orderInfo;
        }

        public void AddOrder()
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Insert into Northwind.Orders Default Values";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void SetOrderDate(Order order, DateTime date)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

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
                orderDate.Value = date;
                command.Parameters.Add(orderDate);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void SetShippedDate(Order order, DateTime date)
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

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
                shippedDate.Value = date;
                command.Parameters.Add(shippedDate);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public CustomerOrderHistory GetCustomerHistory(string customerID)
        {
            CustomerOrderHistory customerHistory = new CustomerOrderHistory();
            customerHistory.CustomerID = customerID;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Northwind.CustOrderHist";

                var cstmrID = command.CreateParameter();
                cstmrID.ParameterName = "@CustomerID";
                cstmrID.DbType = DbType.String;
                cstmrID.Value = customerID;
                command.Parameters.Add(cstmrID);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerOrderHistoryDetail detail = new CustomerOrderHistoryDetail();
                        detail.ProductName = (string)reader["ProductName"];
                        detail.Quantity = (int)reader["Total"];
                        customerHistory.Details.Add(detail);
                    }
                }

                connection.Close();
            }

            return customerHistory;
        }

        public OrderInfo GetOrderInfoStored(Order order)
        {
            OrderInfo orderInfo = new OrderInfo();
            orderInfo.OrderID = order.OrderID;

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Northwind.CustOrdersDetail";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@OrderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = order.OrderID;
                command.Parameters.Add(orderID);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderInfoDetail detail = new OrderInfoDetail();
                        detail.ProductName = (string)reader["ProductName"];
                        detail.UnitPrice = (decimal)reader["UnitPrice"];
                        detail.Discount = (int)reader["Discount"];
                        detail.Quantity = (Int16)reader["Quantity"];
						orderInfo.Details.Add(detail);
                    }
                }

                connection.Close();
            }

            return orderInfo;
        }
    }
}
