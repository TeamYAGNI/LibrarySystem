namespace LibrarySystem.Repositories.Data.Users.Utils.Contracts
{
    public interface IHashProvider
    {
        string Hash(string password);

        string Hash(string password, int iterations);

        bool IsHashSupported(string hashString);

        bool Verify(string password, string hashedPassword);
    }
}