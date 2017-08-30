using LakewoodScoop.Scraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LakewoodScoop.web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Scoop> Posts { get; set; }
    }
}