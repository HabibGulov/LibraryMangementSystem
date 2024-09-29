public static class Extension
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IAuthorRepository, AuthorRepository>();
        serviceCollection.AddTransient<IBookRepository, BookRepository>();
        serviceCollection.AddTransient<IUserRepository, UserRepository>();
        serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddTransient<IBookRentalRepository, BookRentalRepository>();
    }
}