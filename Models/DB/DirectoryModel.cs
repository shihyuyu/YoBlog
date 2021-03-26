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
		[DisplayName("���D")]
		public string DirTitle { get; set; }
		[AllowHtml]
		[DisplayName("���e")]
		public string DirDesc { get; set; }
		[DisplayName("�Ƨ�")]
		public int Seqno { get; set; }
		[DisplayName("�إ߮ɶ�")]
		public DateTime? CreateTime { get; set; }
		[DisplayName("�ק�ɶ�")]
		public DateTime? ReviseTime { get; set; }
	}
}
