using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Subjects
{
    public class GetSubjectsWithHighestImpactFactorCommand : Command, ICommand
    {
        private readonly ISubjectRepository subjectRepository;

        public GetSubjectsWithHighestImpactFactorCommand(ISubjectRepository subjectRepository) : base(new List<object>() { subjectRepository }, 0)
        {
            this.subjectRepository = subjectRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
