using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Data.Models
{
    public class Articles
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Anchor { get; set; }
        public string ImagePath { get; set; }
    }
}