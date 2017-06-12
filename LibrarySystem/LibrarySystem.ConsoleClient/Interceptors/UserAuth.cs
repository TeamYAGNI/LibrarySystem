// <copyright file = "UserAuth.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of UserAuth class.</summary>
using System;

using Bytes2you.Validation;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Exceptions;

using Ninject.Extensions.Interception;

namespace LibrarySystem.ConsoleClient.Interceptors
{
    /// <summary>
    /// Represent a <see cref="UserAuth"/> class, implementator of <see cref="IInterceptor"/> interface.
    /// </summary>
    public class UserAuth : IInterceptor
    {
        /// <summary>
        /// Validator to be used to auth users.
        /// </summary>
        private readonly IAuthValidator authValidator;

        /// <summary>
        /// Passport for providing authentication key of the user.
        /// </summary>
        private readonly IUserPassport passport;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidation"/> class.
        /// </summary>
        /// <param name="authValidator">Validator to be used to auth users.</param>
        public UserAuth(IAuthValidator authValidator, IUserPassport passport)
        {
            Guard.WhenArgument(authValidator, "UserAuth authValidator").IsNull().Throw();
            Guard.WhenArgument(passport, "UserAuth passport").IsNull().Throw();

            this.authValidator = authValidator;
            this.passport = passport;
        }

        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation to intercept.</param>
        public void Intercept(IInvocation invocation)
        {
            if (this.authValidator.isAuth(this.passport))
            {
                invocation.Proceed();
            }
            else
            {
                throw new UserAuthException("You have to login first!");
            }
        }
    }
}
