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
            return View();
        }

       
    }
}