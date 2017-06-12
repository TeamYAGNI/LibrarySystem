namespace LibrarySystem.Commands.Contracts
{
    public interface IAuthValidator
    {
        bool isAuth(IUserPassport passport);
    }
}
