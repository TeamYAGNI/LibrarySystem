using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models.Logs;
using LibrarySystem.Repositories.Contracts.Data.Logs;
using LibrarySystem.Repositories.Contracts.Data.Logs.UnitOfWork;

namespace LibrarySystem.Commands.Administrative.Logs
{
    public class AddLogCommand : Command, ICommand
    {
        private readonly ILogsUnitOfWork logsUnitOfWork;
        private readonly ILogsRepository logsRepository;
        private readonly ILogTypesRepository logTypesRepository;

        public AddLogCommand(ILogsUnitOfWork logsUnitOfWork, ILogsRepository logsRepository, ILogTypesRepository logTypesRepository) : base(new List<object>() { logsUnitOfWork, logsRepository, logTypesRepository }, 2)
        {
            this.logsUnitOfWork = logsUnitOfWork;
            this.logsRepository = logsRepository;
            this.logTypesRepository = logTypesRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var logMessage = parameters[0];
            if (logMessage.Length > 1024)
            {
                logMessage = logMessage.Substring(0, 1024);
            }
            var logTypeName = parameters[1];

            var logType = this.logTypesRepository.GetLogTypeByName(logTypeName);

            if (logType == null)
            {
                logType = new LogType()
                {
                    Name = logTypeName
                };
            }

            var log = new Log()
            {
                DateTime = TimeProvider.Current.Now,
                LogType = logType,
                Message = logMessage
            };

            logsRepository.Add(log);

            logsUnitOfWork.Commit();
            return $"Log into {logTypeName} successfully created.";
        }
    }
}
