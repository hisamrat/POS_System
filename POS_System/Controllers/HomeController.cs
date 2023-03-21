using POS_System.DataAccess;
using POS_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseConnections _databaseConnections=new DatabaseConnections();
        public ActionResult Index()
        {
           
            ViewBag.Date = DateTime.Now;
            ViewBag.Time = DateTime.Now.ToString("HH:mm:ss tt");
            return View();
        }
        [HttpGet]
        public ActionResult GetItems()
        {
            try
            {
                _databaseConnections.connection();
                List<Items> itemslist = new List<Items>();
                SqlCommand cmd = new SqlCommand("GetItemDetails", _databaseConnections.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                _databaseConnections.con.Open();
                sd.Fill(dt);
                _databaseConnections.con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    itemslist.Add(
                        new Items
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            ItemName = Convert.ToString(dr["ItemName"]),
                            Price = Convert.ToInt32(dr["Price"]),

                        });
                }

                return Json(itemslist.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult SaveOrder(List<Order> orders)
        {
            try
            {
                var OrderId = Guid.NewGuid();
                int i = 0;
                _databaseConnections.connection();
                SqlCommand cmd = new SqlCommand("AddNewOrderBill", _databaseConnections.con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var odr in orders)
                {
                    cmd.Parameters.AddWithValue("@OrderId", OrderId);
                    cmd.Parameters.AddWithValue("@ItemName", odr.ItemName);
                    cmd.Parameters.AddWithValue("@Price", odr.Price);
                    cmd.Parameters.AddWithValue("@Quantity", odr.Quantity);
                    cmd.Parameters.AddWithValue("@Amount", odr.Amount);
                    cmd.Parameters.AddWithValue("@OrderDate", odr.OrderDate);
                    cmd.Parameters.AddWithValue("@OrderTime", odr.OrderTime);
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }

                    i = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                };

                if (i >= 1)
                {
                    cmd.Connection.Close();
                    bool Result = true;
                    return Json(Result);
                }

                else
                {
                    bool Result = false;
                    return Json(Result);
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

       
    }
}