public interface IBookRentalRepository
{
    Task<bool> CreateAsync(BookRental bookRental);
    Task<BookRental?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookRental>> GetAllAsync();
    Task<bool> UpdateAsync(BookRental bookRental);
    Task<bool> DeleteAsync(Guid id);
}
