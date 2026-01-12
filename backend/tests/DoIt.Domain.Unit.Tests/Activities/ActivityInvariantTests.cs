using DoIt.Domain.Activities;
using DoIt.Domain.Unit.Tests.Utilities.Activities;

namespace DoIt.Domain.Unit.Tests.Activities;

public class ActivityInvariantTests
{
    [Fact]
    public void Activity_ShouldNeverHaveNullTitle()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Activity.Create(null!));
    }

    [Fact]
    public void Aggregate_ShouldNeverHaveNullImportance()
    {
        // Act
        var activity = Activity.Create(
            ActivityTestData.ValidTitle(),
            importance: null
        );
        
        // Assert
        Assert.NotNull(activity.Importance);
    }

    [Fact]
    public void Aggregate_ShouldNeverHaveNullStatus()
    {
        // Act
        var activity = Activity.Create(
            ActivityTestData.ValidTitle(),
            status: null
        );
        
        // Assert
        Assert.NotNull(activity.Status);
    }
}