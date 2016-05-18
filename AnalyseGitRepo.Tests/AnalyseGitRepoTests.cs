using System;
using NSubstitute;
using NUnit.Framework;
using AnalyseGitRepo.Interfaces;

namespace AnalyseGitRepo.Tests
{
    [TestFixture]
    public class AnalyseGitRepoTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void AnalyseGitRepo_Ctor_EmptyPathThrowsArgumentNullException(string invalidPathToRepo)
        {
            Assert.Throws<ArgumentNullException>(() => new AnalyseGitRepo(invalidPathToRepo));
        }

        [Test]
        public void AnalyseGitRepo_Ctor_BadRepoPathThrowsArgumentException()
        {
            var pathToRepo = "bad path";
            var gitRepositoryLoader = Substitute.For<IGitRepositoryLoader>();
            gitRepositoryLoader.GetRepo(pathToRepo).Returns((IGitRepository)null);

            Assert.Throws<ArgumentException>(() => new AnalyseGitRepo(pathToRepo, gitRepositoryLoader));
            gitRepositoryLoader.Received().GetRepo(pathToRepo);
        }

        [Test]
        public void AnalyseGitRepo_Ctor_ValidPath()
        {
            var pathToRepo = "good path";
            var gitRepositoryLoader = Substitute.For<IGitRepositoryLoader>();
            var gitRepository = Substitute.For<IGitRepository>();
            gitRepositoryLoader.GetRepo(pathToRepo).Returns(gitRepository);

            var analyseGitRepo = new AnalyseGitRepo(pathToRepo, gitRepositoryLoader);

            gitRepositoryLoader.Received().GetRepo(pathToRepo);
        }

        [Test]
        [Ignore("Need test helper to construct sample repo")]
        public void AnalyseGitRepo_GetSummary()
        {
            var pathToRepo = @"C:\PathToRepo";

            var analyseGitRepo = new AnalyseGitRepo(pathToRepo);

            var result = analyseGitRepo.GetSummary();

            Console.Out.WriteLine(result);
        }
    }
}

