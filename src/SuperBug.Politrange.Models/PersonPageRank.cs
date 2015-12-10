﻿using System.Security.AccessControl;

namespace SuperBug.Politrange.Models
{
	public class PersonPageRank
	{
	    public int PersonPageRankId { get; set; }
	    public int PersonId { get; set; }
		public Person Person { get; set; }
	    public int PageId { get; set; }
		public Page Page { get; set; }
		public int Rank { get; set; }
	}
}