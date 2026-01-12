using DoIt.Domain.Activities.ValueObjects;
using DoIt.Domain.Unit.Tests.Utilities.Activities;

namespace DoIt.Domain.Unit.Tests.Activities;

public class ActivityBehaviorTests
{
    [Fact]
    public void Rename_WithValidTitle_ShouldUpdateTitle()
    {
        // Arrange
        var title = Title.Create("New title").Value!;
        
        var activity = ActivityBuilder
            .Default()
            .Build();
        
        // Act
        activity.Rename(title);
        
        // Assert
        Assert.Equal(title, activity.Title);
    }

    [Fact]
    public void Rename_WithNullTitle_ShouldThrowArgumentNullException()
    {
        // Arrange
        var title = Title.Create("New title").Value!;
        
        var activity = ActivityBuilder
            .Default()
            .WithTitle(title)
            .Build();

        // Act
        Assert.Throws<ArgumentNullException>(() => activity.Rename(null!));
    }

    [Fact]
    public void ChangeDescription_WithValidDescription_ShouldUpdateDescription()
    {
        // Arrange
        var description = Description.Create("New description").Value!;

        var activity = ActivityBuilder
            .Default()
            .Build();
        
        // Act
        activity.ChangeDescription(description);
        
        // Assert
        Assert.Equal(description, activity.Description);
    }

    [Fact]
    public void ChangeDescription_WithNullDescription_ShouldClearDescription()
    {
        // Arrange
        var description = Description.Create("New description").Value!;

        var activity = ActivityBuilder
            .Default()
            .WithDescription(description)
            .Build();
        
        // Act
        activity.ChangeDescription(null);
        
        // Assert
        Assert.Null(activity.Description);
    }

    [Fact]
    public void MarkAsImportant_WhenNotImportant_ShouldSetImportanceToImportant()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithImportance(Importance.NotImportant)
            .Build();
        
        // Act
        activity.MarkAsImportant();
        
        // Assert
        Assert.Equal(Importance.Important, activity.Importance);
    }

    [Fact]
    public void MarkAsImportant_WhenAlreadyImportant_ShouldBeIdempotent()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithImportance(Importance.Important)
            .Build();
        
        var originalImportance = activity.Importance;
        
        // Act
        activity.MarkAsImportant();
        
        // Assert
        Assert.Equal(originalImportance, activity.Importance);
    }

    [Fact]
    public void MarkAsNotImportant_WhenImportant_ShouldSetImportanceToNotImportant()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithImportance(Importance.Important)
            .Build();
        
        // Act
        activity.MarkAsNotImportant();
        
        // Assert
        Assert.Equal(Importance.NotImportant, activity.Importance);
    }

    [Fact]
    public void MarkAsNotImportant_WhenAlreadyNotImportant_ShouldBeIdempotent()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithImportance(Importance.NotImportant)
            .Build();
        
        var originalImportance = activity.Importance;
        
        // Act
        activity.MarkAsNotImportant();
        
        // Assert
        Assert.Equal(originalImportance, activity.Importance);
    }

    [Fact]
    public void Do_WhenNotDone_ShouldSetStatusToDone()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithStatus(Status.NotDone)
            .Build();
        
        // Act
        activity.Do();
        
        // Assert
        Assert.Equal(Status.Done, activity.Status);
    }

    [Fact]
    public void Do_WhenAlreadyDone_ShouldBeIdempotent()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithStatus(Status.Done)
            .Build();
        
        var originalStatus = activity.Status;
        
        // Act
        activity.Do();
        
        // Assert
        Assert.Equal(originalStatus, activity.Status);
    }

    [Fact]
    public void Undo_WhenDone_ShouldSetStatusToNotDone()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithStatus(Status.Done)
            .Build();
        
        // Act
        activity.Undo();
        
        // Assert
        Assert.Equal(Status.NotDone, activity.Status);
    }

    [Fact]
    public void Undo_WhenNotDone_ShouldBeIdempotent()
    {
        // Arrange
        var activity = ActivityBuilder
            .Default()
            .WithStatus(Status.NotDone)
            .Build();
        
        var originalStatus = activity.Status;
        
        // Act
        activity.Undo();
        
        // Assert
        Assert.Equal(originalStatus, activity.Status);
    }
}