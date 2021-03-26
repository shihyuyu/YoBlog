using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Newtonsoft.Json;
using YoBlog.Models;

namespace YoBlog.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index(string page)
		{
			switch (page?.ToLower()) {
				case "about":
					return View("About");
				case "contact":
					return View("Contact");
				case "handle":
					return View();
				case "mgt":
				default:
					string strSQL = "select * from Directory";
					var list = DBHelper.query<DirectoryModel>(strSQL, new { });
					return View(list);
			}		
		}
		[HttpPost]
		public ActionResult Index(string page, HomeModel vo)
		{
			switch (page?.ToLower())
			{
				case "about":
					break;
				case "contact":
					break;
				case "delete":
					string delSQL = "delete from Directory where DirID=@DirID";
					DBHelper.execute(delSQL, new { DirID = vo.DeleteDirID });
					break;
			}

			string whereSQL = "";
			if (!string.IsNullOrEmpty(vo.Search))
			{
				whereSQL = " and DirTitle like @Search";
				DBHelper.pa.Add("Search", "%" + vo.Search + "%");

				ViewBag.Search = vo.Search;
			}

			string strSQL = string.Format("select top 9 * from Directory where 1=1 {0} order by ReviseTime desc", whereSQL);

			var list = DBHelper.query<DirectoryModel>(strSQL, DBHelper.pa);
			return View(list);
		}
		public ActionResult Create()
		{		
			return View();
		}
		[HttpPost]
		public ActionResult Create(DirectoryModel vo)
		{
			string strSQL = "insert into Directory(DirTitle, DirDesc) values (@DirTitle, @DirDesc)";
			DBHelper.execute(strSQL, new { DirTitle = vo.DirTitle, DirDesc  = HttpUtility.HtmlDecode(vo.DirDesc) });
			return RedirectToAction("Index", "Home", new { page = "mgt" });
		}
		public ActionResult Details(string id)
		{
			string strSQL = "select * from Directory where DirID=@DirID";
			var data = DBHelper.query<DirectoryModel>(strSQL, new { DirID = id }).FirstOrDefault();
			//data.DirDesc = System.Xml.Linq.XElement.Parse(data.DirDesc).ToString();
			return View(data);
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		[HttpPost]
		public JsonResult GetTagName()
		{
			string strSQL = "select Name from IntelligenceCode";
			var data = DBHelper.query(strSQL);
			return Json(data);
		}
	}
}