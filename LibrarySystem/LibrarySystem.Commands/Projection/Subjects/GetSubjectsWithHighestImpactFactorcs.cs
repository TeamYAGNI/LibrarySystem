using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Projection.Subjects
{
    public class GetSubjectsWithHighestImpactFactorcs : ICommand
    {
        private readonly ISubjectRepository subjectRepository;

        public GetSubjectsWithHighestImpactFactorcs(ISubjectRepository subjectRepository)
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
                var impactFactor = subject.Journals.Select(j => j.ImpactFactor).FirstOrDefault();
                sb.AppendLine($"* Subject Name: {subject.Name}");
                sb.AppendLine($"* Impact Factor: {impactFactor}");
            }

            return sb.ToString();
        }
    }
}
