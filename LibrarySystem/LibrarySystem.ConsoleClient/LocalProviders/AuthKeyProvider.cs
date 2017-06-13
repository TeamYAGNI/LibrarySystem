using System;
using System.Text;

using LibrarySystem.Commands.Contracts;

namespace LibrarySystem.ConsoleClient.LocalProviders
{
    public class AuthKeyProvider : IAuthKeyProvider
    {
        private const string ValidCharacters = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXWZ!@#$%^&*()";
        private const int AuthKeyLength = 128;

        public string GenerateAuthKey(string password)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();

            builder.Append(password);

            for (int i = password.Length; i < AuthKeyLength; i++)
            {
                int nextIndex = random.Next(ValidCharacters.Length);

                builder.Append(ValidCharacters[nextIndex]);
            }

            return builder.ToString();
        }
    }
}
