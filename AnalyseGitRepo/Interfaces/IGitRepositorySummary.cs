namespace AnalyseGitRepo.Interfaces
{
    public interface IGitRepositorySummary
    {
        int NumberOfCommits { get; }
        int NumberOfEntities { get; }
        int NumberOfEntitiesChanged { get; }
        int NumberOfAuthors { get; }
    }
}
