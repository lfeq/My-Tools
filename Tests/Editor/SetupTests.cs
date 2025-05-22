using NUnit.Framework;
using UnityEngine;
using System.IO;
using MyTools; // Assuming Setup class is in MyTools namespace

public class SetupTests
{
    [Test]
    public void InitializeGitRepo_GeneratesGitignoreWithoutLeadingWhitespace()
    {
        // Arrange
        string gitignorePath = Application.dataPath + "/../.gitignore";

        // Act
        Setup.InitializeGitRepo();

        // Assert
        Assert.IsTrue(File.Exists(gitignorePath), ".gitignore file was not created.");

        string[] gitignoreLines = File.ReadAllLines(gitignorePath);
        Assert.Greater(gitignoreLines.Length, 0, ".gitignore file is empty.");

        for (int i = 0; i < gitignoreLines.Length; i++)
        {
            string line = gitignoreLines[i];
            // We only care about lines that are not empty
            if (!string.IsNullOrWhiteSpace(line))
            {
                Assert.IsFalse(char.IsWhiteSpace(line[0]), $"Line {i + 1} in .gitignore starts with whitespace: \"{line}\"");
            }
        }
    }
}
