namespace LibrarySystem.Commands.Contracts
{
    public interface IAuthKeyProvider
    {
        string GenerateAuthKey(string password);
    }
}
