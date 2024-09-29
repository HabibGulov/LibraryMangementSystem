public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }=null!;
    public string LastName { get; set; }=null!;
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }=null!;
    public DateTime CreatedAt { get; set; }
}

