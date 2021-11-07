using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomager.Web.Viewmodels.PaymentsViewModels
{
    public class PaymentsRecordPagingInfo
    {
        public List<int> PagingYears { get; set; }

        public int CurrentPage { get; set; }

        public bool DisplayPrev => PagingYears != null && CurrentPage != PagingYears.First();

        public bool DisplayNext => PagingYears != null && CurrentPage != PagingYears.Last();

        public bool DisplayFirst => PagingYears != null && CurrentPage != PagingYears.First();

        public bool DisplayLast => PagingYears != null && CurrentPage != PagingYears.Last();

        public int GetPrevPage()
        {
            int prevPage = 0;

            int currentIndex = PagingYears.IndexOf(CurrentPage);

            if (currentIndex > 0)
            {
                prevPage = PagingYears[currentIndex - 1];
            }

            return prevPage;
        }

        public int GetNextPage()
        {
            int nextPage = 0;

            int currentIndex = PagingYears.IndexOf(CurrentPage);

            if (currentIndex < PagingYears.Count - 1)
            {
                nextPage = PagingYears[currentIndex + 1];
            }

            return nextPage;
        }
    }
}
