namespace ogloszenia.Models
{
    public class Pager
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public Pager() { }
        public Pager(int totalItems, int page, int pagesize = 10)
        {
            TotalPages = (int)Math.Ceiling((decimal)totalItems/(decimal)pagesize);
            CurrentPage = page;
            StartPage = CurrentPage - 2;
            EndPage = CurrentPage + 2;
            if(StartPage <= 0)
            {
                StartPage = 1;
            }
            if(EndPage > TotalPages)
            {
                EndPage = TotalPages;
                if(EndPage > 7)
                {
                    StartPage = EndPage - 6;
                }
            }
            TotalItems = totalItems;
            PageSize = pagesize;
        }
    }
}
