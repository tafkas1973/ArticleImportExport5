namespace Office4U.Articles.ImportExport.Api.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;

        }
    }
}