// <copyright file = "ModelValidation.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of ModelValidation class.</summary>

using System.ComponentModel.DataAnnotations;

using Bytes2you.Validation;
using LibrarySystem.Framework.Contracts;
using Ninject.Extensions.Interception;

namespace LibrarySystem.ConsoleClient.Interceptors
{
    /// <summary>
    /// Represent a <see cref="ModelValidation"/> class, implementator of <see cref="IInterceptor"/> interface.
    /// </summary>
    public class ModelValidation : IInterceptor
    {
        /// <summary>
        /// Validator to be used to validate models.
        /// </summary>
        private readonly IValidator validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidation"/> class.
        /// </summary>
        /// <param name="validator">Validator to be used to validate models.</param>
        public ModelValidation(IValidator validator)
        {
            Guard.WhenArgument(validator, "ModelValidation validator").IsNull().Throw();

            this.validator = validator;
        }

        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation to intercept.</param>
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            this.validator.Validate(invocation.ReturnValue, message => throw new ValidationException(message)); // TODO: Implement ModelValidationException
        }
    }
}