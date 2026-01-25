using DoIt.Application.Activities.CreateActivity;
using DoIt.Domain.Activities;
using DoIt.Domain.Activities.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DoIt.Application.Integration.Tests.Activities;

public class CreateActivityCommandHandlerTests
    : ApplicationIntegrationTestBase
{
    [Fact]
    public async Task Handle_WhenCalled_ShouldCreateAndPersistActivity()
    {
        // Arrange
        using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var cancellationToken = cancellationTokenSource.Token;
        var repository = ServiceProvider.GetRequiredService<IActivityRepository>();
        var command = new CreateActivityCommand("Title 1", "Description 1");
        var handler = new CreateActivityCommandHandler(repository);
        
        // Act
        var activityResult = await handler.Handle(command, cancellationToken);
        
        // Assert
        Assert.True(activityResult.IsSuccess);
        Assert.NotNull(activityResult.Value);
        
        var saved = await repository.GetById(activityResult.Value.Id, cancellationToken);
        
        Assert.NotNull(saved);
        Assert.Equal("Title 1", saved.Title.Value);
    }

    [Fact]
    public async Task Handle_WhenDescriptionIsNull_ShouldCreateAndPersistActivityWithNullDescription()
    {
        // Arrange
        using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var cancellationToken =  cancellationTokenSource.Token;
        var repository = ServiceProvider.GetRequiredService<IActivityRepository>();
        var command = new CreateActivityCommand("Title 2", null);
        var handler = new CreateActivityCommandHandler(repository);
        
        // Act
        var activityResult = await handler.Handle(command, cancellationToken);
        
        // Assert
        Assert.True(activityResult.IsSuccess);
        Assert.NotNull(activityResult.Value);
        
        var saved = await repository.GetById(activityResult.Value.Id, cancellationToken);
        
        Assert.NotNull(saved);
        Assert.Equal("Title 2", saved.Title.Value);
        Assert.Null(saved.Description);
    }

    [Fact]
    public async Task Handle_WhenTitleIsEmpty_ShouldReturnFailure()
    {
        // Arrange
        using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var cancellationToken =  cancellationTokenSource.Token;
        var repository = ServiceProvider.GetRequiredService<IActivityRepository>();
        var command = new CreateActivityCommand(string.Empty, "Description 1", false);
        var handler = new CreateActivityCommandHandler(repository);
        
        // Act
        var activityResult = await handler.Handle(command, cancellationToken);
        
        // Assert
        Assert.True(activityResult.IsFailure);
        Assert.NotNull(activityResult.Error);
        Assert.Equal(Errors.Titles.Empty.Code, activityResult.Error.Code);
    }
}