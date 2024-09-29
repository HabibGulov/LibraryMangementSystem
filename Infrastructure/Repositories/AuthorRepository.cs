using Dapper;
using Npgsql;

public class AuthorRepository : IAuthorRepository
{
    public async Task<bool> CreateAsync(Author author)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();

                return connection.Execute(SqlCommands.CreateAuhtor, author) > 0;
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

                return connection.Execute(SqlCommands.DeleteAuthor, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<Author>(SqlCommands.GetAllAuthors);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Author>();
        }
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();

                return connection.QuerySingleOrDefault<Author>(SqlCommands.GetAuthorById, new { Id = id });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new Author();
        }
    }

    public async Task<bool> UpdateAsync(Author author)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();

                return connection.Execute(SqlCommands.UpdateAuthor, author) > 0;
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
    public const string CreateAuhtor = @"insert into authors (id, firstname, lastname, dateofbirth, biography, createdat)values (@id, @firstname, @lastname, @dateofbirth, @biography, @createdat);";
    public const string GetAuthorById = @"select * from authors where id = @id;";
    public const string GetAllAuthors = @"select * from authors;";
    public const string UpdateAuthor = @"update authors set firstname = @firstname, lastname = @lastname, dateofbirth = @dateofbirth, biography = @biography, createdat = @createdat where id = @id;";
    public const string DeleteAuthor = @"delete from authors where id = @id;";
}