using Dapper;
using Npgsql;

public class UserRepository : IUserRepository
{
    public async Task<bool> CreateAsync(User user)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.CreateUser, user) > 0;
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
                return connection.Execute(SqlCommands.DeleteUser, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<User>(SqlCommands.GetAllUsers);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<User>();
        }
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.QuerySingleOrDefault<User>(SqlCommands.GetUserById, new { Id = id });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> UpdateAsync(User user)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.UpdateUser, user) > 0;
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
    public const string CreateUser = @"insert into users (id, username, email, passwordhash, createdat) values (@id, @username, @email, @passwordhash, @createdat);";
    public const string GetUserById = @"select * from users where id = @id;";
    public const string GetAllUsers = @"select * from users;";
    public const string UpdateUser = @"update users set username = @username, email = @email, passwordhash = @passwordhash, createdat = @createdat where id = @id;";
    public const string DeleteUser = @"delete from users where id = @id;";
}
