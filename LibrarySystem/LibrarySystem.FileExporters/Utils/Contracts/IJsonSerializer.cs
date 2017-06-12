// <copyright file="IJsonJournalsSerializer.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON serializer wrapper interface.</summary>

using System.Collections.Generic;
using LibrarySystem.Models.DTOs.JSON;

namespace LibrarySystem.FileExporters.Utils.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journals"></param>
        /// <returns></returns>
        string Serialize(IEnumerable<JournalJsonDto> journals);
    }
}
