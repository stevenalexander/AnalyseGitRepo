using AnalyseGitRepo.Interfaces;
using AnalyseGitRepo.Services;
using System;

namespace AnalyseGitRepo
{
    public class AnalyseGitRepo
    {
        private readonly IGitRepositoryLoader _gitRepositoryLoader;

        private readonly IGitRepository _gitRepository;

        public AnalyseGitRepo(string pathToRepo, IGitRepositoryLoader gitRepositoryLoader = null)
        {
            _gitRepositoryLoader = gitRepositoryLoader ?? new GitRepositoryLoader();

            if (string.IsNullOrWhiteSpace(pathToRepo))
            {
                throw new ArgumentNullException("You must supply a valid path to a git repository");
            }

            _gitRepository = _gitRepositoryLoader.GetRepo(pathToRepo);

            if (_gitRepository == null)
            {
                throw new ArgumentException("Not a valid path to a git repository");
            }
        }

        public IGitRepositorySummary GetSummary()
        {
            return _gitRepository.GetSummary();
        }
    }
}
