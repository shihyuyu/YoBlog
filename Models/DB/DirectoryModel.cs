using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YoBlog.Models
{
	public partial class DirectoryModel
	{
		public int DirID { get; set; }

		public int DirPID { get; set; }
		[DisplayName("標題")]
		public string DirTitle { get; set; }
		[AllowHtml]
		[DisplayName("內容")]
		public string DirDesc { get; set; }
		[DisplayName("排序")]
		public int Seqno { get; set; }
		[DisplayName("建立時間")]
		public DateTime? CreateTime { get; set; }
		[DisplayName("修改時間")]
		public DateTime? ReviseTime { get; set; }
	}
}
