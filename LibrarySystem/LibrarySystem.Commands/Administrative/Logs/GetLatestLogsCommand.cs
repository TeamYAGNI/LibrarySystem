using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Logs;

namespace LibrarySystem.Commands.Administrative.Logs
{
    public class GetLatestLogsCommand : Command, ICommand
    {
        private readonly ILogsRepository logsRepository;

        public GetLatestLogsCommand(ILogsRepository logsRepository) : base(new List<object>() { logsRepository }, 0)
        {
            this.logsRepository = logsRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var logs = this.logsRepository.Get10LatestLogs();

            if (logs.Count() == 0)
            {
                return $"Sorry, no available logs.";
            }

            var sb = new StringBuilder();

            sb.AppendLine("* List of latest Logs:");
            foreach (var log in logs)
            {
                sb.AppendLine($"* Log Type: {log.LogType.Name}");
                sb.AppendLine($"* Log Date: {log.DateTime.Date}");
                sb.AppendLine($"* Log Message: {log.Message}");
            }

            return sb.ToString();
        }
    }
}
