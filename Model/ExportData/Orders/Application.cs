﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ExportData.Orders
{
	[Serializable]
	public class Application
	{
		public string ApplicationUID { get; set; }
		public string OrderUID { get; set; }
		public int OrderTypeID { get; set; }
		public string CompetitiveGroupUID { get; set; }
		public string OrderIdLevelBudget { get; set; }
		public string IsDisagreedDate { get; set; }
	}
}
