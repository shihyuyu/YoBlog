using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoBlog
{
	public class FormatHelper
	{
		public enum FormatType {
			Html,
			Css,
			JavaScript
		}
		public static string Format(FormatType formatType, string val)
		{
			string ret = "";

			try
			{

			}
			catch (Exception ex)
			{
				ret = val;
			}

			return ret;
		}

		private string HtmlFormat(string val)
		{
			string ret = "";



			return ret;
		}

		private List<string> getHeadTag(string val)
		{
			List<string> ret = new List<string>();

			if (!string.IsNullOrEmpty(val))
			{
				string tmpStr = "";
				for(int i = 0; i < val.Length; i++)
				{
					char c = val[i];
					if (c == '<')
					{
						tmpStr += c;
						while (c != '>' || i == val.Length)
						{
							tmpStr += c;
							c = val[i];
							i++;
						} // while
						tmpStr += c;
						ret.Add(tmpStr);
						tmpStr = "";
					}
					else 
					{
						ret.Add(tmpStr);
						tmpStr = "";
					}

					tmpStr += c;
				}

				ret.Add(tmpStr);
			}
			return ret;
		}

	}
}