using AnalyseGitRepo.Interfaces;
using GitTools.Git;
using System.IO;

namespace AnalyseGitRepo.Services
{
    class GitRepositoryLoader : IGitRepositoryLoader
    {
        public IGitRepository GetRepo(string pathToRepo)
        {
            FileAttributes attr = File.GetAttributes(pathToRepo);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                return new GitRepository(RepositoryLoader.GetRepo(pathToRepo));
            }

            return null;
        }
    }
}
