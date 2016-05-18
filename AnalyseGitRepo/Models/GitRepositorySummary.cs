using AnalyseGitRepo.Interfaces;

namespace AnalyseGitRepo.Models
{
    class GitRepositorySummary : IGitRepositorySummary
    {
        public int NumberOfCommits { get; private set; }
        public int NumberOfEntities { get; private set; }
        public int NumberOfEntitiesChanged { get; private set; }
        public int NumberOfAuthors { get; private set; }

        public GitRepositorySummary(int numberOfCommits, int numberOfEntities, int numberOfEntitiesChanged, int numberOfAuthors)
        {
            NumberOfCommits = numberOfCommits;
            NumberOfEntities = numberOfEntities;
            NumberOfEntitiesChanged = NumberOfEntitiesChanged;
            NumberOfAuthors = numberOfAuthors;
        }

        public override string ToString()
        {
            return string.Format("NumberOfCommits: {0}, NumberOfEntities: {1}, NumberOfEntitiesChanged: {2}, NumberOfAuthors: {3}", NumberOfCommits, NumberOfEntities, NumberOfEntitiesChanged, NumberOfAuthors);
        }
    }
}
