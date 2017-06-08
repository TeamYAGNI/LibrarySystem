// <copyright file = "Validator.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Validator class.</summary>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

using LibrarySystem.Framework.Contracts;

namespace LibrarySystem.Framework.Providers
{
    /// <summary>
    /// Represent a <see cref="Validator"/> class, implementator of <see cref="IValidator"/> interface.
    /// </summary>
    public class Validator : IValidator
    {
        /// <summary>
        /// Represent the method witch validate a generic object.
        /// </summary>
        /// <typeparam name="T">The type of object to be validated.</typeparam>
        /// <param name="obj">Generic object to be validated by the <see cref="Validator"/> instance.</param>
        /// <param name="onValidationFail">Action to be executed in case of validation failure.</param>
        public void Validate<T>(T obj, Action<string> onValidationFail = null) where T : class
        {
            IEnumerable<string> validationErrors = this.GetValidationErrors(obj);

            if (onValidationFail == null)
            {
                onValidationFail = message => throw new ValidationException(message);
            }

            if (validationErrors.Count() > 0)
            {
                onValidationFail(validationErrors.First());
            }
        }

        /// <summary>
        /// Represent the method witch collect error messages while object validation.
        /// </summary>
        /// <param name="obj">Object to be validated.</param>
        /// <returns>Collection of error messages.</returns>
        private IEnumerable<string> GetValidationErrors(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Type attrType = typeof(ValidationAttribute);

            foreach (var propertyInfo in properties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);

                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;

                    bool valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}
