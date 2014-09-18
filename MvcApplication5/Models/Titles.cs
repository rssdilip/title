using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class Titles
    {
        public IEnumerable<Title> Title;
        public string SearchKeyword { get; set; }
    }
}