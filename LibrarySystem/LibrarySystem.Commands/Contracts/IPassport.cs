namespace LibrarySystem.Commands.Contracts
{
    public interface IUserPassport
    {
        string Username { get; set; }

        string AuthKey { get; set; }
    }
}