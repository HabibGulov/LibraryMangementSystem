public class BookWithAuthorAndCategory
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AuhtorId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; } = null!;
    public Guid CategotyId { get; set; }
    public string Name { get; set; } = null!;
}