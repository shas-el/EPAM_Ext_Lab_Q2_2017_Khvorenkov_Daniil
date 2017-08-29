namespace DAL
{
    using DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Linq;

    public class NorthwindDAL
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
                    "From Northwind.Orders";
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            CustomerID = (reader["CustomerID"] == DBNull.Value)
                            ? null : (string)reader["CustomerID"],
                            EmployeeID = (reader["EmployeeID"] == DBNull.Value)
                            ? null : (int?)reader["EmployeeID"],
                            OrderDate = (reader["OrderDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["OrderDate"],
                            RequiredDate = (reader["RequiredDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["RequiredDate"],
                            ShippedDate = (reader["ShippedDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["ShippedDate"],
                            ShipVia = (reader["ShipVia"] == DBNull.Value)
                            ? null : (int?)reader["ShipVia"],
                            Freight = (reader["Freight"] == DBNull.Value)
                            ? null : (decimal?)reader["Freight"],
                            ShipName = (reader["ShipName"] == DBNull.Value)
                            ? null : (string)reader["ShipName"],
                            ShipAddress = (reader["ShipAddress"] == DBNull.Value)
                            ? null : (string)reader["ShipAddress"],
                            ShipCity = (reader["ShipCity"] == DBNull.Value)
                            ? null : (string)reader["ShipCity"],
                            ShipRegion = (reader["ShipRegion"] == DBNull.Value)
                            ? null : (string)reader["ShipRegion"],
                            ShipPostalCode = (reader["ShipPostalCode"] == DBNull.Value)
                            ? null : (string)reader["ShipPostalCode"],
                            ShipCountry = (reader["ShipCountry"] == DBNull.Value)
                            ? null : (string)reader["ShipCountry"]
                        };

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

        public List<OrderExt> GetOrdersExt()
        {
            List<OrderExt> results = new List<OrderExt>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select o.OrderID" +
                    ", o.CustomerID" +
                    ", c.CompanyName" +
                    ", o.EmployeeID" +
                    ", e.LastName" +
                    ", e.FirstName" +
                    ", o.OrderDate" +
                    ", o.RequiredDate" +
                    ", o.ShippedDate" +
                    ", o.ShipVia" +
                    ", s.CompanyName as 'ShipperName'" +
                    ", o.Freight" +
                    ", o.ShipName" +
                    ", o.ShipAddress" +
                    ", o.ShipCity" +
                    ", o.ShipRegion" +
                    ", o.ShipPostalCode" +
                    ", o.ShipCountry " +
                    "From Northwind.Orders o " +
                    "Inner Join Northwind.Customers c " +
                    "On o.CustomerID = c.CustomerID " +
                    "Inner Join Northwind.Employees e " +
                    "On o.EmployeeID = e.EmployeeID " +
                    "Inner Join Northwind.Shippers s " +
                    "On o.ShipVia = s.ShipperID";
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderExt order = new OrderExt
                        {
                            OrderID = (int)reader["OrderID"],
                            CustomerID = (reader["CustomerID"] == DBNull.Value)
                            ? null : (string)reader["CustomerID"],
                            CustomerName = (string)reader["CompanyName"],
                            EmployeeID = (reader["EmployeeID"] == DBNull.Value)
                            ? null : (int?)reader["EmployeeID"],
                            EmployeeLastName = (string)reader["LastName"],
                            EmployeeFirstName = (string)reader["FirstName"],
                            OrderDate = (reader["OrderDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["OrderDate"],
                            RequiredDate = (reader["RequiredDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["RequiredDate"],
                            ShippedDate = (reader["ShippedDate"] == DBNull.Value)
                            ? null : (DateTime?)reader["ShippedDate"],
                            ShipVia = (reader["ShipVia"] == DBNull.Value)
                            ? null : (int?)reader["ShipVia"],
                            ShipperName = (reader["ShipperName"] == DBNull.Value)
                            ? null : (string)reader["ShipperName"],
                            Freight = (reader["Freight"] == DBNull.Value)
                            ? null : (decimal?)reader["Freight"],
                            ShipName = (reader["ShipName"] == DBNull.Value)
                            ? null : (string)reader["ShipName"],
                            ShipAddress = (reader["ShipAddress"] == DBNull.Value)
                            ? null : (string)reader["ShipAddress"],
                            ShipCity = (reader["ShipCity"] == DBNull.Value)
                            ? null : (string)reader["ShipCity"],
                            ShipRegion = (reader["ShipRegion"] == DBNull.Value)
                            ? null : (string)reader["ShipRegion"],
                            ShipPostalCode = (reader["ShipPostalCode"] == DBNull.Value)
                            ? null : (string)reader["ShipPostalCode"],
                            ShipCountry = (reader["ShipCountry"] == DBNull.Value)
                            ? null : (string)reader["ShipCountry"]
                        };

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

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select CustomerID" +
                    ", CompanyName " +
                    "From Northwind.Customers";
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            CustomerID = (string)reader["CustomerID"],
                            CompanyName = (string)reader["CompanyName"]
                        };
                        customers.Add(customer);
                    }
                }

                connection.Close();
            }

            return customers;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select EmployeeID" +
                    ", LastName" +
                    ", FirstName " +
                    "From Northwind.Employees";
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeID = (int)reader["EmployeeID"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"]
                        };
                        employees.Add(employee);
                    }
                }

                connection.Close();
            }

            return employees;
        }

        public List<Shipper> GetShippers()
        {
            List<Shipper> shippers = new List<Shipper>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select ShipperID" +
                    ", CompanyName " +
                    "From Northwind.Shippers";
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Shipper shipper = new Shipper
                        {
                            ShipperID = (int)reader["ShipperID"],
                            ShipperName = (string)reader["CompanyName"]
                        };
                        shippers.Add(shipper);
                    }
                }

                connection.Close();
            }

            return shippers;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            var connectionStringItem = ConfigurationManager.ConnectionStrings["LocalNorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Select ProductID" +
                    ", ProductName" +
                    ", UnitPrice" +
                    " From Northwind.Products";
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            UnitPrice = (decimal)reader["UnitPrice"]
                        };
                        products.Add(product);
                    }
                }

                connection.Close();
            }

            return products;
        }

        public List<OrderDetail> GetOrderDetails(int id)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

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
                    ", ProductID" +
                    ", UnitPrice" +
                    ", Quantity" +
                    ", Discount" +
                    " From Northwind.[Order Details]" +
                    " Where OrderID = @orderID";
                command.CommandType = CommandType.Text;

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = id;
                command.Parameters.Add(orderID);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDetail detail = new OrderDetail
                        {
                            OrderID = (int)reader["OrderID"],
                            ProductID = (int)reader["ProductID"],
                            UnitPrice = (decimal)reader["UnitPrice"],
                            Quantity = (Int16)reader["Quantity"],
                            Discount = (Single)reader["Discount"]
                        };
                        orderDetails.Add(detail);
                    }
                }

                connection.Close();
            }

            return orderDetails;
        }

        public OrderInfo GetOrderInfo(int id)
        {
            OrderInfo orderInfo = new OrderInfo();
            orderInfo.OrderID = id;

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
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = id;
                command.Parameters.Add(orderID);

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

        public Order GetOrder(int id)
        {
            Order order;

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
                    "From Northwind.Orders " +
                    "Where OrderID = @orderID";
                command.CommandType = CommandType.Text;

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = id;
                command.Parameters.Add(orderID);

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    order = new Order
                    {
                        OrderID = (int)reader["OrderID"],
                        CustomerID = (reader["CustomerID"] == DBNull.Value)
                        ? null : (string)reader["CustomerID"],
                        EmployeeID = (reader["EmployeeID"] == DBNull.Value)
                        ? null : (int?)reader["EmployeeID"],
                        OrderDate = (reader["OrderDate"] == DBNull.Value)
                        ? null : (DateTime?)reader["OrderDate"],
                        RequiredDate = (reader["RequiredDate"] == DBNull.Value)
                        ? null : (DateTime?)reader["RequiredDate"],
                        ShippedDate = (reader["ShippedDate"] == DBNull.Value)
                        ? null : (DateTime?)reader["ShippedDate"],
                        ShipVia = (reader["ShipVia"] == DBNull.Value)
                        ? null : (int?)reader["ShipVia"],
                        Freight = (reader["Freight"] == DBNull.Value)
                        ? null : (decimal?)reader["Freight"],
                        ShipName = (reader["ShipName"] == DBNull.Value)
                        ? null : (string)reader["ShipName"],
                        ShipAddress = (reader["ShipAddress"] == DBNull.Value)
                        ? null : (string)reader["ShipAddress"],
                        ShipCity = (reader["ShipCity"] == DBNull.Value)
                        ? null : (string)reader["ShipCity"],
                        ShipRegion = (reader["ShipRegion"] == DBNull.Value)
                        ? null : (string)reader["ShipRegion"],
                        ShipPostalCode = (reader["ShipPostalCode"] == DBNull.Value)
                        ? null : (string)reader["ShipPostalCode"],
                        ShipCountry = (reader["ShipCountry"] == DBNull.Value)
                        ? null : (string)reader["ShipCountry"]
                    };

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
                }

                connection.Close();
            }

            return order;
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

        public int AddOrder(Order order)
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
                command.CommandText = "Insert into Northwind.Orders (CustomerID" +
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
                    ", ShipCountry)" +
                    " Values (@customerID" +
                    ", @employeeID" +
                    ", @orderDate" +
                    ", @requiredDate" +
                    ", @shippedDate" +
                    ", @shipVia" +
                    ", @freight" +
                    ", @shipName" +
                    ", @shipAddress" +
                    ", @shipCity" +
                    ", @shipRegion" +
                    ", @shipPostalCode" +
                    ", @shipCountry);" +
                    " Select Cast(SCOPE_IDENTITY() as int)";

                var customerID = command.CreateParameter();
                customerID.ParameterName = "@customerID";
                customerID.DbType = DbType.String;
                customerID.Value = (object)order.CustomerID ?? DBNull.Value;
                command.Parameters.Add(customerID);

                var employeeID = command.CreateParameter();
                employeeID.ParameterName = "@employeeID";
                employeeID.DbType = DbType.Int32;
                employeeID.Value = (object)order.EmployeeID ?? DBNull.Value;
                command.Parameters.Add(employeeID);

                var orderDate = command.CreateParameter();
                orderDate.ParameterName = "@orderDate";
                orderDate.DbType = DbType.DateTime;
                orderDate.Value = (object)order.OrderDate ?? DBNull.Value;
                command.Parameters.Add(orderDate);

                var requiredDate = command.CreateParameter();
                requiredDate.ParameterName = "@requiredDate";
                requiredDate.DbType = DbType.DateTime;
                requiredDate.Value = (object)order.RequiredDate ?? DBNull.Value;
                command.Parameters.Add(requiredDate);

                var shippedDate = command.CreateParameter();
                shippedDate.ParameterName = "@shippedDate";
                shippedDate.DbType = DbType.DateTime;
                shippedDate.Value = (object)order.ShippedDate ?? DBNull.Value;
                command.Parameters.Add(shippedDate);

                var shipVia = command.CreateParameter();
                shipVia.ParameterName = "@shipVia";
                shipVia.DbType = DbType.Int32;
                shipVia.Value = (object)order.ShipVia ?? DBNull.Value;
                command.Parameters.Add(shipVia);

                var freight = command.CreateParameter();
                freight.ParameterName = "@freight";
                freight.DbType = DbType.Decimal;
                freight.Value = (object)order.Freight ?? DBNull.Value;
                command.Parameters.Add(freight);

                var shipName = command.CreateParameter();
                shipName.ParameterName = "@shipName";
                shipName.DbType = DbType.String;
                shipName.Value = (object)order.ShipName ?? DBNull.Value;
                command.Parameters.Add(shipName);

                var shipAddress = command.CreateParameter();
                shipAddress.ParameterName = "@shipAddress";
                shipAddress.DbType = DbType.String;
                shipAddress.Value = (object)order.ShipAddress ?? DBNull.Value;
                command.Parameters.Add(shipAddress);

                var shipCity = command.CreateParameter();
                shipCity.ParameterName = "@shipCity";
                shipCity.DbType = DbType.String;
                shipCity.Value = (object)order.ShipCity ?? DBNull.Value;
                command.Parameters.Add(shipCity);

                var shipRegion = command.CreateParameter();
                shipRegion.ParameterName = "@shipRegion";
                shipRegion.DbType = DbType.String;
                shipRegion.Value = (object)order.ShipRegion ?? DBNull.Value;
                command.Parameters.Add(shipRegion);

                var shipPostalCode = command.CreateParameter();
                shipPostalCode.ParameterName = "@shipPostalCode";
                shipPostalCode.DbType = DbType.String;
                shipPostalCode.Value = (object)order.ShipPostalCode ?? DBNull.Value;
                command.Parameters.Add(shipPostalCode);

                var shipCountry = command.CreateParameter();
                shipCountry.ParameterName = "@shipCountry";
                shipCountry.DbType = DbType.String;
                shipCountry.Value = (object)order.ShipCountry ?? DBNull.Value;
                command.Parameters.Add(shipCountry);

                int insertedID = (int)command.ExecuteScalar();

                connection.Close();

                return insertedID;
            }
        }

        public void UpdateOrder(Order order)
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
                    "Set CustomerID = @customerID" +
                    ", EmployeeID = @employeeID" +
                    ", OrderDate = @orderDate" +
                    ", RequiredDate = @requiredDate" +
                    ", ShippedDate = @shippedDate" +
                    ", ShipVia = @shipVia" +
                    ", Freight = @freight" +
                    ", ShipName = @shipName" +
                    ", ShipAddress = @shipAddress" +
                    ", ShipCity = @shipCity" +
                    ", ShipRegion = @shipRegion" +
                    ", ShipPostalCode = @shipPostalCode" +
                    ", ShipCountry = @shipCountry " +
                    "Where OrderID = @orderID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = order.OrderID;
                command.Parameters.Add(orderID);

                var customerID = command.CreateParameter();
                customerID.ParameterName = "@customerID";
                customerID.DbType = DbType.String;
                customerID.Value = (object)order.CustomerID ?? DBNull.Value;
                command.Parameters.Add(customerID);

                var employeeID = command.CreateParameter();
                employeeID.ParameterName = "@employeeID";
                employeeID.DbType = DbType.Int32;
                employeeID.Value = (object)order.EmployeeID ?? DBNull.Value;
                command.Parameters.Add(employeeID);

                var orderDate = command.CreateParameter();
                orderDate.ParameterName = "@orderDate";
                orderDate.DbType = DbType.DateTime;
                orderDate.Value = (object)order.OrderDate ?? DBNull.Value;
                command.Parameters.Add(orderDate);

                var requiredDate = command.CreateParameter();
                requiredDate.ParameterName = "@requiredDate";
                requiredDate.DbType = DbType.DateTime;
                requiredDate.Value = (object)order.RequiredDate ?? DBNull.Value;
                command.Parameters.Add(requiredDate);

                var shippedDate = command.CreateParameter();
                shippedDate.ParameterName = "@shippedDate";
                shippedDate.DbType = DbType.DateTime;
                shippedDate.Value = (object)order.ShippedDate ?? DBNull.Value;
                command.Parameters.Add(shippedDate);

                var shipVia = command.CreateParameter();
                shipVia.ParameterName = "@shipVia";
                shipVia.DbType = DbType.Int32;
                shipVia.Value = (object)order.ShipVia ?? DBNull.Value;
                command.Parameters.Add(shipVia);

                var freight = command.CreateParameter();
                freight.ParameterName = "@freight";
                freight.DbType = DbType.Decimal;
                freight.Value = (object)order.Freight ?? DBNull.Value;
                command.Parameters.Add(freight);

                var shipName = command.CreateParameter();
                shipName.ParameterName = "@shipName";
                shipName.DbType = DbType.String;
                shipName.Value = (object)order.ShipName ?? DBNull.Value;
                command.Parameters.Add(shipName);

                var shipAddress = command.CreateParameter();
                shipAddress.ParameterName = "@shipAddress";
                shipAddress.DbType = DbType.String;
                shipAddress.Value = (object)order.ShipAddress ?? DBNull.Value;
                command.Parameters.Add(shipAddress);

                var shipCity = command.CreateParameter();
                shipCity.ParameterName = "@shipCity";
                shipCity.DbType = DbType.String;
                shipCity.Value = (object)order.ShipCity ?? DBNull.Value;
                command.Parameters.Add(shipCity);

                var shipRegion = command.CreateParameter();
                shipRegion.ParameterName = "@shipRegion";
                shipRegion.DbType = DbType.String;
                shipRegion.Value = (object)order.ShipRegion ?? DBNull.Value;
                command.Parameters.Add(shipRegion);

                var shipPostalCode = command.CreateParameter();
                shipPostalCode.ParameterName = "@shipPostalCode";
                shipPostalCode.DbType = DbType.String;
                shipPostalCode.Value = (object)order.ShipPostalCode ?? DBNull.Value;
                command.Parameters.Add(shipPostalCode);

                var shipCountry = command.CreateParameter();
                shipCountry.ParameterName = "@shipCountry";
                shipCountry.DbType = DbType.String;
                shipCountry.Value = (object)order.ShipCountry ?? DBNull.Value;
                command.Parameters.Add(shipCountry);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteOrder(int id)
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
                command.CommandText = "Delete from Northwind.[Order Details] " +
                    "Where OrderID = @orderID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = id;
                command.Parameters.Add(orderID);

                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete from Northwind.Orders " +
                    "Where OrderID = @orderID";

                orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = id;
                command.Parameters.Add(orderID);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void UpdateOrderDetails(int orderID, List<OrderDetail> details)
        {
            if (details != null)
            {
                List<OrderDetail> oldDetails = GetOrderDetails(orderID);
                List<OrderDetail> newDetails;
                List<OrderDetail> deprecatedDetails;

                if (oldDetails == null)
                {
                    newDetails = details;
                    deprecatedDetails = new List<OrderDetail>();
                }
                else
                {
                    newDetails = details.Except(oldDetails).ToList();
                    deprecatedDetails = oldDetails.Except(details).ToList();
                }

                foreach (var detail in deprecatedDetails)
                {
                    DeleteOrderDetail(detail);
                }

                foreach (var detail in newDetails)
                {
                    AddOrderDetail(detail);
                }
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
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
                command.CommandText = "Insert into Northwind.[Order Details] (OrderID" +
                    ", ProductID" +
                    ", UnitPrice" +
                    ", Quantity" +
                    ", Discount)" +
                    " Values (@orderID" +
                    ", @productID" +
                    ", @unitPrice" +
                    ", @quantity" +
                    ", @discount)";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = orderDetail.OrderID;
                command.Parameters.Add(orderID);

                var productID = command.CreateParameter();
                productID.ParameterName = "@productID";
                productID.DbType = DbType.Int32;
                productID.Value = orderDetail.ProductID;
                command.Parameters.Add(productID);

                var unitPrice = command.CreateParameter();
                unitPrice.ParameterName = "@unitPrice";
                unitPrice.DbType = DbType.Decimal;
                unitPrice.Value = orderDetail.UnitPrice;
                command.Parameters.Add(unitPrice);

                var quantity = command.CreateParameter();
                quantity.ParameterName = "@quantity";
                quantity.DbType = DbType.Int16;
                quantity.Value = orderDetail.Quantity;
                command.Parameters.Add(quantity);

                var discount = command.CreateParameter();
                discount.ParameterName = "@discount";
                discount.DbType = DbType.Single;
                discount.Value = orderDetail.Discount;
                command.Parameters.Add(discount);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
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
                command.CommandText = "Delete from Northwind.[Order Details] " +
                    "Where OrderID = @orderID And ProductID = @productID";

                var orderID = command.CreateParameter();
                orderID.ParameterName = "@orderID";
                orderID.DbType = DbType.Int32;
                orderID.Value = orderDetail.OrderID;
                command.Parameters.Add(orderID);

                var productID = command.CreateParameter();
                productID.ParameterName = "@productID";
                productID.DbType = DbType.Int32;
                productID.Value = orderDetail.ProductID;
                command.Parameters.Add(productID);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void SetOrderDate(int id, DateTime date)
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
                orderID.Value = id;
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

        public void SetShippedDate(int id, DateTime date)
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
                orderID.Value = id;
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

        public OrderInfo GetOrderInfoStored(int id)
        {
            OrderInfo orderInfo = new OrderInfo();
            orderInfo.OrderID = id;

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
                orderID.Value = id;
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
