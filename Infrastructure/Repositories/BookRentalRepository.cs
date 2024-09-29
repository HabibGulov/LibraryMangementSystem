using Dapper;
using Npgsql;

public class BookRentalRepository : IBookRentalRepository
{
    public async Task<bool> CreateAsync(BookRental bookRental)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.CreateBookRental, bookRental) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.DeleteBookRental, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<BookRental>> GetAllAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<BookRental>(SqlCommands.GetAllBookRentals);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<BookRental>();
        }
    }

    public async Task<BookRental?> GetByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.QuerySingleOrDefault<BookRental>(SqlCommands.GetBookRentalById, new { Id = id });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(BookRental bookRental)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.UpdateBookRental, bookRental) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }
}

file class SqlCommands
{
    public const string ConnectionString = "Server=localhost;Port=5432;Database=library_db;Username=postgres;Password=12345";
    public const string CreateBookRental = @"insert into bookrentals (id, bookid, userid, rentaldate, returndate, createdat) values (@id, @bookid, @userid, @rentaldate, @returndate, @createdat);";
    public const string GetBookRentalById = @"select * from bookrentals where id = @id;";
    public const string GetAllBookRentals = @"select * from bookrentals;";
    public const string UpdateBookRental = @"update bookrentals set bookid = @bookid, userid = @userid, rentaldate = @rentaldate, returndate = @returndate, createdat = @createdat where id = @id;";
    public const string DeleteBookRental = @"delete from bookrentals where id = @id;";
}
