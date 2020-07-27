using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatchingProgram
{
	public class FileEvent
	{
		public FileEvent()
		{
		}
		public String FileName
		{
			get; set;
		}
		public String Extension
		{
			get; set;
		}
		public String Path
		{
			get; set;
		}
		public String Event
		{
			get; set;
		}
		public String DateAndTime
		{
			get; set;
		}
	}

}
