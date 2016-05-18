using AnalyseGitRepo.Interfaces;
using AnalyseGitRepo.Models;
using LibGit2Sharp;
using System.Collections.Generic;

namespace AnalyseGitRepo.Services
{
    class GitRepository : IGitRepository
    {
        private readonly Repository _repo;

        public GitRepository(Repository repo)
        {
            _repo = repo;
        }

        public IGitRepositorySummary GetSummary()
        {
            int numberOfCommits = 0, numberOfEntitiesChanged = 0;

            List<string> entities = new List<string>();
            List<string> authors = new List<string>();

            foreach (Commit commit in _repo.Commits)
            {
                foreach (var parent in commit.Parents)
                {
                    var treeChanges = _repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree);
                    foreach (TreeEntryChanges change in treeChanges)
                    {
                        numberOfEntitiesChanged++;
                        if (!entities.Contains(change.Path)) { entities.Add(change.Path); }
                    }
                }
                
                numberOfCommits++;
                if (!authors.Contains(commit.Author.Name)) { authors.Add(commit.Author.Name); }
            }

            return new GitRepositorySummary(numberOfCommits, entities.Count, numberOfEntitiesChanged, authors.Count);
        }
    }
}
