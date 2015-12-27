using System;
using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Api.Models.Models
{
    public class RangeDatePersonRank
    {
        public DateTime FoundDate { get; set; }
        public IEnumerable<PersonPageRank> PersonPageRanks { get; set; }  
    }
}