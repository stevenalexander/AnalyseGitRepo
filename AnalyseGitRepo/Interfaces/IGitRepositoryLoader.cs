namespace AnalyseGitRepo.Interfaces
{
    public interface IGitRepositoryLoader
    {
        IGitRepository GetRepo(string pathToRepo);
    }
}
