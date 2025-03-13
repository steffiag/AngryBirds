// Bomie Jun
/*
The primary functions of the score is that it's capable of adding or removing points, but never goes below zero. In order to test that this works, I tested that the score can increase.
Furthermore, I tested whether it could decrease when there are more than enough points, exactly enough, or too few, to see whether it would correctly subtract while remaining at least zero.
These tests check the boundary of zero in addition to handling operations with positive and negative numbers
*/
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;


[TestFixture]
public class ScoreTests
{
    private ScoreManager scoreManager;
    private Text mockScoreText;

    [SetUp]
    public void SetUp()
    {
        scoreManager = new GameObject().AddComponent<ScoreManager>();

        mockScoreText = new GameObject().AddComponent<Text>();
        scoreManager.scoreText = mockScoreText;

        scoreManager.scoreText.text = "Score: 0";
    }

    [Test]
    public void AddPoints_ScoreIncreases()
    {
        // Act:
        scoreManager.UpdateScore(50);

        // Assert:
        Assert.AreEqual("Score: 50", mockScoreText.text);
    }

    [Test]
    public void AddZeroPoints_ScoreRemainsSame()
    {
        // Act:
        scoreManager.UpdateScore(0);

        // Assert:
        Assert.AreEqual("Score: 0", mockScoreText.text);
    }

    [Test]
    public void SubtractPoints_MoreThanEnoughPointsAlready()
    {
        // Arrange:
        scoreManager.score = 60;

        // Act:
        scoreManager.UpdateScore(-50);

        // Assert:
        Assert.AreEqual("Score: 10", mockScoreText.text);
    }

    [Test]
    public void SubtractPoints_ExactlyEnoughPoints()
    {
        // Arrange:
        scoreManager.score = 50;

        // Act:
        scoreManager.UpdateScore(-50);

        // Assert:
        Assert.AreEqual("Score: 0", mockScoreText.text);
    }

    [Test]
    public void SubtractPoints_NotEnoughPointsResultsInZero()
    {
        // Arrange:
        scoreManager.score = 20;

        // Act:
        scoreManager.UpdateScore(-50);

        // Assert:
        Assert.AreEqual("Score: 0", mockScoreText.text);
    }

    [Test]
    public void ScoreUpdatesWithSequentialCalls()
    {
        // Act:
        scoreManager.UpdateScore(-50);
        scoreManager.UpdateScore(30);
        scoreManager.UpdateScore(60);

        // Assert:
        Assert.AreEqual("Score: 90", mockScoreText.text);
    }

}
