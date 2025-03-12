// Steffia George
/*
I included various tests to ensure that the timer would be able to subscribe and unsubscribe the observers properly. Additionally, it checks for edge cases such as when the timeRemaining variable becomes negative.
I thought that these test cases were able to encapsulate the overall functionality of the timer.
The cases weren’t brittle as they weren’t focused on the actual GameOverManager observer. Instead, I used a mock of the GameOverManager through the ITimerObserver interface.
*/
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;


[TestFixture]
public class TimerTests
{
   private Timer timer;
   private ITimerObserver mockGameOverManager;
   private Text mockTimerText;


  [SetUp]
  public void SetUp()
  {
      timer = new GameObject().AddComponent<Timer>();

      mockTimerText = new GameObject().AddComponent<Text>();
      mockTimerText.text = "00:00";
      timer.timerText = mockTimerText;

      mockGameOverManager = Substitute.For<ITimerObserver>();
      timer.Subscribe(mockGameOverManager);
  }

  [Test]
  public void UpdateTime_TimerEventWhenTimeEqualsZero()
  {
      // Arrange
      timer.timeRemaining = 0f;

      // Act
      timer.UpdateTime();

      // Assert
      mockGameOverManager.Received().TimerEvent();
  }

  [Test]
  public void UpdateTime_TimeDoesNotGoBelowZero()
  {
      // Arrange
      timer.timeRemaining = -1f;

      // Act
      timer.UpdateTime();

      // Assert
      Assert.AreEqual(0f, timer.timeRemaining);
  }

  [Test]
  public void UpdateTime_UpdatesAndDisplaysTimeCorrectly()
  {
      // Arrange
      timer.timeRemaining = 30f;

      // Act
      timer.UpdateTime();

      // Assert
      Assert.AreEqual("00:29", mockTimerText.text);
  }

  [Test]
  public void Subscribe_SubscribesObserverProperly()
  {
      // Arrange
      var newGameOverManager = Substitute.For<ITimerObserver>();

      // Act
      timer.Subscribe(newGameOverManager);
      timer.timeRemaining = 0f;
      timer.UpdateTime();

      // Assert
      newGameOverManager.Received().TimerEvent();
  }

  [Test]
  public void Unsubscribe_UnsubscribesObserverProperly()
  {
      // Arrange

      // Act
      timer.Unsubscribe(mockGameOverManager);
      timer.timeRemaining = 0f;
      timer.UpdateTime();

      // Assert
      mockGameOverManager.DidNotReceive().TimerEvent();
  }
}
