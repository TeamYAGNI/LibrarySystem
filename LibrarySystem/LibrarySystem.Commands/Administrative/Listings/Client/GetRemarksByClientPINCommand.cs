﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetRemarksByClientPINCommand : Command, ICommand
    {
        private readonly ILendingRepository lendingRepository;

        public GetRemarksByClientPINCommand(ILendingRepository lendingRepository) : base(new List<object>() { lendingRepository }, 1)
        {
            this.lendingRepository = lendingRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var PIN = parameters[0];

            var remarks = this.lendingRepository.GetAllLendingsRemarksByClientPIN(PIN);

            if (remarks.Count() == 0)
            {
                return $"Client with PIN {PIN} has no remarks.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Client with PIN {PIN} Remarks:");
            foreach (var remark in remarks)
            {
                sb.AppendLine($"* Remark: {remark}");
            }

            return sb.ToString();
        }
    }
}
