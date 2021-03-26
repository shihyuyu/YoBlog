using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoBlog.Models
{
	public class HomeModel
	{
		/// <summary>
		/// 查詢文字
		/// </summary>
		public string Search { get; set; }

		public string DeleteDirID { get; set; }
	}
}