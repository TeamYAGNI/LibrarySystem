using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Projection.Subjects
{
    public class GetSubjectsWithMostJournalsCommand : ICommand
    {
        private readonly ISubjectRepository subjectRepository;

        public GetSubjectsWithMostJournalsCommand(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var subjects = this.subjectRepository.GetTop5SubjectsWithMostJournals();

            if (subjects.Count() == 0)
            {
                return $"There are no specified subjects at the moment";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Top {subjects.Count()} Subjects:");
            foreach (var subject in subjects)
            {
                sb.AppendLine($"* Subject Name: {subject.Name}");
                sb.AppendLine($"* Journals Count: {subject.Journals.Count}");
            }

            return sb.ToString();
        }
    }
}
