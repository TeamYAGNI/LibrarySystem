using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetRemarksByClientPINCommand : IAdministratorCommand
    {
        private readonly ILendingRepository lendingRepository;

        public GetRemarksByClientPINCommand(ILendingRepository lendingRepository)
        {
            Guard.WhenArgument(lendingRepository, "lendingRepository").IsNull().Throw();

            this.lendingRepository = lendingRepository;
        }

        public string Execute(IList<string> parameters)
        {
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
