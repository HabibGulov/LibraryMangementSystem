using Dapper;
using Npgsql;
public class CategoryRepository : ICategoryRepository
{
    public async Task<bool> CreateAsync(Category category)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.CreateCategory, category) > 0;
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
                return connection.Execute(SqlCommands.DeleteCategory, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Category>(SqlCommands.GetAllCategories);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Category>();
        }
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.QuerySingleOrDefault<Category>(SqlCommands.GetCategoryById, new { Id = id });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.UpdateCategory, category) > 0;
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
    public const string CreateCategory = @"insert into categories (id, name, createdat) values (@id, @name, @createdat);";
    public const string GetCategoryById = @"select * from categories where id = @id;";
    public const string GetAllCategories = @"select * from categories;";
    public const string UpdateCategory = @"update categories set name = @name, createdat = @createdat where id = @id;";
    public const string DeleteCategory = @"delete from categories where id = @id;";
}
