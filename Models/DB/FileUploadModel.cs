using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoBlog.Models
{
	public partial class FileUploadModel
	{

		public string FileID { get; set; }

		public int DirID { get; set; }

		public string FileName { get; set; }

		public string FIleUrl { get; set; }

		public string FileType { get; set; }

		public int FileSize { get; set; }
	}
}
