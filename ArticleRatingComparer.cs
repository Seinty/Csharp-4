using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ArticleRatingComparer : IComparer<Article>
    {
        public int Compare(Article x, Article y)
        {
            if (x.Raiting < y.Raiting)
                return 1;
            if (x.Raiting > y.Raiting)
                return -1;
            return 0;
        }
    }
}
