namespace EfCore_Task.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Username { get; set; } = null!;
        public string Password { get; set; }
    };
}
