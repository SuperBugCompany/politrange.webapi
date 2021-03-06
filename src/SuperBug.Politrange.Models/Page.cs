﻿using System;
using System.Collections.Generic;

namespace SuperBug.Politrange.Models
{
	public class Page
	{
		public int PageId { get; set; }
		public string Uri { get; set; }
		public DateTime? FoundDate { get; set; }
		public DateTime? LastScanDate { get; set; }
	    public int SiteId { get; set; }
		public virtual Site Site { get; set; }
	    public virtual ICollection<PersonPageRank> PersonPageRanks { get; set; }
	}
}