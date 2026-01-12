using DoIt.Domain.Activities.ValueObjects;
using DoIt.Domain.Unit.Tests.Utilities.Activities;

namespace DoIt.Domain.Unit.Tests.Activities;

public class ActivityCreationTests
{
    [Fact]
    public void Create_WithValidTitle_ShouldCreateActivity()
    {
        // Act
        var activity = ActivityBuilder
            .Default()
            .Build();
        
        // Assert
        Assert.NotNull(activity);
    }

    [Fact]
    public void Create_WithValidTitle_ShouldGenerateNewActivityId()
    {
        // Act
        var activity = ActivityBuilder
            .Default()
            .WithTitle(ActivityTestData.ValidTitle("Some different title"))
            .Build();
        
        // Assert
        Assert.NotNull(activity);
        Assert.NotEqual(default, activity.Id);
        Assert.NotEqual(Guid.Empty, activity.Id.Value);
    }

    [Fact]
    public void Create_WithNullDescription_ShouldSetDescriptionToNull()
    {
        // Act
        var activity = ActivityBuilder
            .Default()
            .WithDescription(null)
            .Build();
        
        // Assert
        Assert.NotNull(activity);
        Assert.Null(activity.Description);
    }

    [Fact]
    public void Create_WithoutImportance_ShouldSetImportanceToNotImportant()
    {
        // Act
        var activity = ActivityBuilder
            .Default()
            .WithoutImportance()
            .Build();
        
        // Assert
        Assert.Equal(Importance.NotImportant, activity.Importance);
    }

    [Fact]
    public void Create_WithoutStatus_ShouldSetStatusToNotDone()
    {
        // Act
        var activity = ActivityBuilder
            .Default()
            .WithoutStatus()
            .Build();
        
        // Assert
        Assert.Equal(Status.NotDone, activity.Status);
    }

    [Theory]
    [MemberData(nameof(ImportanceValues))]
    public void Create_WithExplicitImportance_ShouldUseProvidedImportance(Importance importance)
    {
        // Act
        var activity = ActivityBuilder
            .Default()
            .WithImportance(importance)
            .Build();
        
        // Assert
        Assert.Equal(importance, activity.Importance);
    }

    public static IEnumerable<object[]> ImportanceValues = [[Importance.Important], [Importance.NotImportant]];
    
    [Theory]
    [MemberData(nameof(StatusValues))]
    public void Create_WithExplicitStatus_ShouldUseProvidedStatus(Status status)
    {
        // Act
        var activity = ActivityBuilder
            .Default()
            .WithStatus(status)
            .Build();
        
        // Assert
        Assert.Equal(status, activity.Status);
    }

    public static IEnumerable<object[]> StatusValues = [[Status.NotDone], [Status.Done]];

    [Fact]
    public void Create_WithNullTitle_ShouldThrowArgumentNullException()
    {
        // Arrange
        var builder = ActivityBuilder
            .Default()
            .WithTitle(null!);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.Build());
    }
}