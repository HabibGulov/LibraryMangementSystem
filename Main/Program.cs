#region Configuration
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ServiceCollection serviceCollection = new ServiceCollection();
// serviceCollection.AddServices();
builder.Services.AddServices();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#endregion

#region Author
app.MapGet("api/author", async (IAuthorRepository authorRepository)=>
{
    return await authorRepository.GetAllAsync();
});
app.MapPost("api/author", async (IAuthorRepository authorRepository, Author author)=>
{
    return await authorRepository.CreateAsync(author);
});
app.MapPut("api/author", async (IAuthorRepository authorRepository, Author author)=>
{
    return await authorRepository.UpdateAsync(author);
});
app.MapDelete("api/author", async (IAuthorRepository authorRepository, Guid authorId)=>
{
    return await authorRepository.DeleteAsync(authorId);
});
app.MapGet("api/author{id}", async (IAuthorRepository authorRepository, Guid authorId)=>
{
    return await authorRepository.GetByIdAsync(authorId);
});
#endregion

#region User
app.MapGet("api/user", async (IUserRepository userRepository)=>
{
    return await userRepository.GetAllAsync();
});
app.MapPost("api/user", async (IUserRepository userRepository, User user)=>
{
    return await userRepository.CreateAsync(user);
});
app.MapPut("api/user", async (IUserRepository userRepository, User user)=>
{
    return await userRepository.UpdateAsync(user);
});
app.MapDelete("api/user", async (IUserRepository userRepository, Guid userId)=>
{
    return await userRepository.DeleteAsync(userId);
});
app.MapGet("api/user{id}", async (IUserRepository userRepository, Guid userId)=>
{
    return await userRepository.GetByIdAsync(userId);
});
#endregion

#region Category
app.MapGet("api/category", async (ICategoryRepository categoryRepository)=>
{
    return await categoryRepository.GetAllAsync();
});
app.MapPost("api/category", async (ICategoryRepository categoryRepository, Category category)=>
{
    return await categoryRepository.CreateAsync(category);
});
app.MapPut("api/category", async (ICategoryRepository categoryRepository, Category category)=>
{
    return await categoryRepository.UpdateAsync(category);
});
app.MapDelete("api/category", async (ICategoryRepository categoryRepository, Guid categoryId)=>
{
    return await categoryRepository.DeleteAsync(categoryId);
});
app.MapGet("api/category{id}", async (ICategoryRepository categoryRepository, Guid categoryId)=>
{
    return await categoryRepository.GetByIdAsync(categoryId);
});
#endregion

#region BookRental
app.MapGet("api/bookRental", async (IBookRentalRepository bookRentalRepository)=>
{
    return await bookRentalRepository.GetAllAsync();
});
app.MapPost("api/bookRental", async (IBookRentalRepository bookRentalRepository, BookRental bookRental)=>
{
    return await bookRentalRepository.CreateAsync(bookRental);
});
app.MapPut("api/bookRental", async (IBookRentalRepository bookRentalRepository, BookRental bookRental)=>
{
    return await bookRentalRepository.UpdateAsync(bookRental);
});
app.MapDelete("api/bookRental", async (IBookRentalRepository bookRentalRepository, Guid bookRentalId)=>
{
    return await bookRentalRepository.DeleteAsync(bookRentalId);
});
app.MapGet("api/bookRental{id}", async (IBookRentalRepository bookRentalRepository, Guid bookRentalId)=>
{
    return await bookRentalRepository.GetByIdAsync(bookRentalId);
});
#endregion

#region Book
app.MapGet("api/book", async (IBookRepository bookRepository)=>
{
    return await bookRepository.GetAllAsync();
});
app.MapPost("api/book", async (IBookRepository bookRepository, Book book)=>
{
    return await bookRepository.CreateAsync(book);
});
app.MapPut("api/book", async (IBookRepository bookRepository, Book book)=>
{
    return await bookRepository.UpdateAsync(book);
});
app.MapDelete("api/book", async (IBookRepository bookRepository, Guid bookId)=>
{
    return await bookRepository.DeleteAsync(bookId);
});
app.MapGet("api/book{id}", async (IBookRepository bookRepository, Guid bookId)=>
{
    return await bookRepository.GetByIdAsync(bookId);
});
app.MapGet("api/getBooksWithAuthorAndCategory{id}", async (IBookRepository bookRepository)=>
{
    return await bookRepository.GetBooksWithAuthorAndCategory();
});
app.MapGet("api/getBooksByPublishedDate{publishedDate}", async (IBookRepository bookRepository, DateTime publishedDate)=>
{
    return await bookRepository.GetBooksByPublishedDate(publishedDate);
});
app.MapGet("api/getArrendedBooksByUser{id}", async (IBookRepository bookRepository, Guid userId)=>
{
    return await bookRepository.GetArrendedBooksByUser(userId);
});
app.MapGet("api/getBooksByAuthor", async (IBookRepository bookRepository, Guid authorId)=>
{
    return await bookRepository.GetBooksByAuthor(authorId);
});
app.Run();
#endregion
