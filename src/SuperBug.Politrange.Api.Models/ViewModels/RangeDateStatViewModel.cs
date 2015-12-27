using System;
using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Api.Models.ViewModels
{
    public class RangeDateStatViewModel
    {
        public DateTime Date { get; set; }
        public IEnumerable<PersonRankViewModel> Persons { get; set; } 
    }

    public class PersonRankViewModel
    {
        public string Name { get; set; }
        public int Rank { get; set; }
    }
}