public interface IAuthorRepository
{
    Task<bool> CreateAsync(Author author);
    Task<Author?> GetByIdAsync(Guid id);
    Task<IEnumerable<Author>> GetAllAsync();
    Task<bool> UpdateAsync(Author author);
    Task<bool> DeleteAsync(Guid id);
}