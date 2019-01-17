namespace Passenger.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
    }
}