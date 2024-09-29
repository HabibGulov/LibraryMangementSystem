public interface IBookRepository
{
    Task<bool> CreateAsync(Book book);
    Task<Book?> GetByIdAsync(Guid id);
    Task<IEnumerable<Book>> GetAllAsync();
    Task<bool> UpdateAsync(Book book);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<BookWithAuthorAndCategory>> GetBooksWithAuthorAndCategory();
    Task<IEnumerable<Book>> GetBooksByPublishedDate(DateTime publishedDate);
    Task<IEnumerable<Book>> GetArrendedBooksByUser(Guid userId);
    Task<IEnumerable<Book>> GetBooksByAuthor(Guid authorId);
}
