using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB
{
    public class Create
    {
        DataSet ShopDb = new DataSet("ShopDb");

        public void CreateTableOrders()
        {
            DataTable orders = new DataTable("Orders");

            DataColumn idColumn = new DataColumn("Id", typeof(int));
            DataColumn customerId = new DataColumn("CustomerId", typeof(int));
            DataColumn employeeId = new DataColumn("EmployeeId", typeof(int));
            DataColumn price = new DataColumn("Price", typeof(float));
            orders.Columns.Add(idColumn);
            orders.PrimaryKey = new DataColumn[] { idColumn };
            orders.Columns.Add(price);
            orders.Columns.Add(customerId);
            orders.Columns.Add(employeeId);


            DataRow row = orders.NewRow();
            row["id"] = 1;
            row["Price"] = 3000;
            row["CustomerId"] = 1;
            row["EmployeeId"] = 1;
            orders.Rows.Add(row);
            ShopDb.Tables.Add(orders);

            orders.WriteXml("orders.xml");

            ForeignKeyConstraint fkCustomerOrder = new ForeignKeyConstraint(ShopDb.Tables["Customers"].Columns["Id"], ShopDb.Tables["Orders"].Columns["CustomerId"]);
            ForeignKeyConstraint fkEmployeeOrder = new ForeignKeyConstraint(ShopDb.Tables["Employees"].Columns["Id"], ShopDb.Tables["Orders"].Columns["EmployeeId"]);
            ShopDb.Tables["Orders"].Constraints.Add(fkCustomerOrder);
            ShopDb.Tables["Orders"].Constraints.Add(fkEmployeeOrder);
        }

        public void CreateTableCustomers()
        {
            DataTable customer = new DataTable("Customers");

            DataColumn idCustomer = new DataColumn("Id", typeof(int));
            DataColumn surname = new DataColumn("Surname", typeof(string));
            DataColumn name = new DataColumn("Name", typeof(string));
            customer.Columns.Add(idCustomer);
            customer.PrimaryKey = new DataColumn[] { idCustomer };
            customer.Columns.Add(surname);
            customer.Columns.Add(name);

            DataRow row = customer.NewRow();
            row["Id"] = 1;
            row["Surname"] = "Vasya";
            row["Name"] = "Pupkin";
            customer.Rows.Add(row);
            ShopDb.Tables.Add(customer);

            customer.WriteXml("customer.xml");

        }

        public void CreateTableEmployees()
        {
            DataTable employee = new DataTable("Employees");

            DataColumn idEmployee = new DataColumn("Id", typeof(int));
            DataColumn name = new DataColumn("Name", typeof(string));
            employee.Columns.Add(idEmployee);
            employee.PrimaryKey = new DataColumn[] { idEmployee };
            employee.Columns.Add(name);

            DataRow row = employee.NewRow();
            row["Id"] = 1;
            row["name"] = "Chaplin";
            employee.Rows.Add(row);
            ShopDb.Tables.Add(employee);

            employee.WriteXml("employee.xml");

        }
        public void CreateTableOrderDetails()
        {
            DataTable orderDetail = new DataTable("OrderDetails");

            DataColumn idOrderDetail = new DataColumn("Id", typeof(int));
            DataColumn idOrder = new DataColumn("OrderId", typeof(int));
            DataColumn idProduct = new DataColumn("ProductId", typeof(int));
            orderDetail.Columns.Add(idOrderDetail);
            orderDetail.PrimaryKey = new DataColumn[] { idOrderDetail };
            orderDetail.Columns.Add(idProduct);
            orderDetail.Columns.Add(idOrder);

            DataRow row = orderDetail.NewRow();
            row["Id"] = 1;
            row["OrderId"] = 1;
            row["ProductId"] = 1;
            orderDetail.Rows.Add(row);
            ShopDb.Tables.Add(orderDetail);

            orderDetail.WriteXml("orderDetail.xml");


            ForeignKeyConstraint fkOrderOrderDetails = new ForeignKeyConstraint(ShopDb.Tables["Orders"].Columns["Id"], ShopDb.Tables["OrderDetails"].Columns["OrderId"]);
            ForeignKeyConstraint fkProductOrderDetails = new ForeignKeyConstraint(ShopDb.Tables["Products"].Columns["Id"], ShopDb.Tables["OrderDetails"].Columns["ProductId"]);
            ShopDb.Tables["OrderDetails"].Constraints.AddRange(new Constraint[] { fkOrderOrderDetails, fkProductOrderDetails });


        }
        public void CreateTableProducts()
        {
            DataTable product = new DataTable("Products");

            DataColumn idProduct = new DataColumn("Id", typeof(int));
            DataColumn name = new DataColumn("Name", typeof(string));
            DataColumn price = new DataColumn("Price", typeof(int));
            product.Columns.Add(idProduct);
            product.PrimaryKey = new DataColumn[] { idProduct };
            product.Columns.Add(name);
            product.Columns.Add(price);

            DataRow row = product.NewRow();
            row["Id"] = 1;
            row["Name"] = "disc";
            row["Price"] = 300;
            product.Rows.Add(row);
            ShopDb.Tables.Add(product);

            product.WriteXml("product.xml");

        }
    }
}
