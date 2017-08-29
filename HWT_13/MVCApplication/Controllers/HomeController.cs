using DAL;
using DAL.Model;
using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindDAL dal;

        public HomeController()
        {
            dal = new NorthwindDAL();
        }

        public ActionResult Index()
        {
            List<OrderExt> orders = dal.GetOrdersExt();
            List<OrderIntroViewModel> orderIntros = new List<OrderIntroViewModel>();

            foreach (OrderExt o in orders)
            {
                OrderIntroViewModel intro = new OrderIntroViewModel();
                intro.OrderID = o.OrderID.Value;
                intro.CustomerName = o.CustomerName;
                intro.Status = o.Status;
                intro.OrderDate = o.OrderDate;
                intro.TotalCost = dal.GetOrderInfo(o.OrderID.Value).GetTotalCost();
                orderIntros.Add(intro);
            }

            return View(orderIntros);
        }

        public ActionResult OrderDetails(int id)
        {
            try
            {
                OrderDetailsViewModel orderDetails = new OrderDetailsViewModel();
                orderDetails.Order = dal.GetOrdersExt().First(x => x.OrderID == id);
                orderDetails.OrderInfo = dal.GetOrderInfo(id);
                return View(orderDetails);
            }
            catch (Exception e)
            {
                return HttpNotFound(e.Message);
            }
        }

        public ActionResult EditPopUp(int id)
        {
            EditViewModel editViewModel = new EditViewModel();

            if (id == 0)
            {
                ViewBag.Title = "Create New Order";
                editViewModel.Order = new Order();
                editViewModel.OrderDetails = new List<OrderDetail>();
            }
            else
            {
                ViewBag.Title = string.Format("Edit Order #{0}", id);
                editViewModel.Order = dal.GetOrder(id);
                editViewModel.OrderDetails = dal.GetOrderDetails(id);
            }

            editViewModel.AvailableCustomers = from c in dal.GetCustomers()
                                               select new SelectListItem
                                               {
                                                   Text = c.CompanyName,
                                                   Value = c.CustomerID,
                                                   Selected = c.CustomerID == editViewModel.Order.CustomerID
                                               };

            editViewModel.AvailableEmployees = from e in dal.GetEmployees()
                                               select new SelectListItem
                                               {
                                                   Text = e.FirstName + ' ' + e.LastName,
                                                   Value = e.EmployeeID.ToString(),
                                                   Selected = e.EmployeeID == editViewModel.Order.EmployeeID
                                               };

            editViewModel.AvailableProducts = dal.GetProducts();

            editViewModel.AvailableShippers = from s in dal.GetShippers()
                                              select new SelectListItem
                                              {
                                                  Text = s.ShipperName,
                                                  Value = s.ShipperID.ToString(),
                                                  Selected = s.ShipperID == editViewModel.Order.ShipVia
                                              };

            return PartialView(editViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            if (!(model.Order.OrderID.HasValue))
            {
                var id = dal.AddOrder(model.Order);
                dal.UpdateOrderDetails(id, model.OrderDetails);
            }
            else
            {
                dal.UpdateOrder(model.Order);
                dal.UpdateOrderDetails(model.Order.OrderID.Value, model.OrderDetails);
            }

            return new EmptyResult();
        }

        public ActionResult OrderDetailTemplate(int index, int id)
        {
            OrderDetailTemplateViewModel orderDetails = new OrderDetailTemplateViewModel();
            orderDetails.Index = index;
            orderDetails.OrderDetails.OrderID = id;
            orderDetails.AvailableProducts = dal.GetProducts();
            return PartialView(orderDetails);
        }

        public ActionResult DeletePopUp(int id)
        {
            DeleteViewModel deleteViewModel = new DeleteViewModel();
            deleteViewModel.OrderID = id;
            return PartialView(deleteViewModel);
        }

        public void DeleteOrder(int id)
        {
            dal.DeleteOrder(id);
        }
    }
}