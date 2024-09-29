using Dapper;
using Npgsql;

public class BookRepository : IBookRepository
{
    public async Task<bool> CreateAsync(Book book)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.CreateBook, book) > 0;
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
                return connection.Execute(SqlCommands.DeleteBook, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Book>(SqlCommands.GetAllBooks);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Book>();
        }
    }

    public async Task<IEnumerable<Book>> GetArrendedBooksByUser(Guid userId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<Book>(SqlCommands.GetArrendedBooksByUser, new { UserId = userId });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Book>();
        }
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthor(Guid authorId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<Book>(SqlCommands.GetBooksByAuthor, new {AuthorId=authorId});
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Book>();
        }
    }

    public async Task<IEnumerable<Book>> GetBooksByPublishedDate(DateTime publishedDate)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<Book>(SqlCommands.GetBooksByPublishedDate, new { PublishedDate = publishedDate });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Book>();
        }
    }
    public async Task<IEnumerable<BookWithAuthorAndCategory>> GetBooksWithAuthorAndCategory()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<BookWithAuthorAndCategory>(SqlCommands.GetBooksWithAuthorAndCategory);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<BookWithAuthorAndCategory>();
        }
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.QuerySingleOrDefault<Book>(SqlCommands.GetBookById, new { Id = id });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task<bool> UpdateAsync(Book book)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return connection.Execute(SqlCommands.UpdateBook, book) > 0;
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
    public const string CreateBook = @"insert into books (id, title, description, isbn, publisheddate, authorid, categoryid, createdat) values (@id, @title, @description, @isbn, @publisheddate, @authorid, @categoryid, @createdat);";
    public const string GetBookById = @"select * from books where id = @id;";
    public const string GetAllBooks = @"select * from books;";
    public const string UpdateBook = @"update books set title = @title, description = @description, isbn = @isbn, publisheddate = @publisheddate, authorid = @authorid, categoryid = @categoryid, createdat = @createdat where id = @id;";
    public const string DeleteBook = @"delete from books where id = @id;";
    public const string GetBooksWithAuthorAndCategory = @"select b.id, b.title, b.description, b.isbn, b.publisheddate, b.createdat, a.id as authorid, a.firstname, a.lastname, a.dateofbirth, a.biography, c.id, c.name from books b
                                        join authors a on a.id=b.authorid
                                        join categories c on c.id=b.categoryid";
    public const string GetBooksByPublishedDate = @"select * from books where publisheddate=@publisheddate";
    public const string GetBooksByAuthor = @"select b.id, b.title, b.description, b.isbn, b.publisheddate, b.authorid, b.categoryid, b.createdat from books b
                                            join authors a on b.authorid=a.id
                                            where a.id=@authorid";
    public const string GetArrendedBooksByUser = @"select b.id, b.title, b.description, b.isbn, b.publisheddate, b.authorid, b.categoryid, b.createdat from books b
                                                join bookrentals br on br.bookid=b.id
                                                join users u on u.id=br.userid
                                                where u.id=@userId";
}
