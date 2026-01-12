using DoIt.Domain.Activities;
using DoIt.Domain.Activities.ValueObjects;
using DoIt.Domain.Unit.Tests.Utilities;

namespace DoIt.Domain.Unit.Tests.Activities.ValueObjects;

public class DescriptionTests
{
    private static readonly string RandomString1 = RandomHelper.String(1);
    private static readonly string RandomString100 = RandomHelper.String(100);
    private static readonly string RandomString250 = RandomHelper.String(250);

    [Theory, MemberData(nameof(DescriptionTooLongValueTests))]
    public void Create_WhenValueIsTooLong_ShouldReturnErrorResult(string? value)
    {
        // Act
        var result = Description.Create(value);
        
        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorCodes.Descriptions.TooLong, result.Error!.Code);
    }

    public static IEnumerable<object[]> DescriptionTooLongValueTests =
    [
        [RandomHelper.String(251)],
        [RandomHelper.String(400)]
    ];

    [Theory, MemberData(nameof(DescriptionValidValueTests))]
    public void Create_WhenValueIsValid_ShouldReturnSuccessResultWithDescription(string? value)
    {
        // Act
        var result = Description.Create(value);
        
        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        var description = result.Value!;
        Assert.Equal(value, description.Value);
    }

    public static IEnumerable<object?[]> DescriptionValidValueTests =
    [
        [null],
        [""],
        [RandomString1],
        [RandomString250]
    ];

    [Theory, MemberData(nameof(DescriptionValidValueToTrimTests))]
    public void Create_WhenValueIsValid_ShouldReturnSuccessResultWithTrimmedDescription(string? value, string? expectedValue)
    {
        // Act
        var result = Description.Create(value);
        
        // Assert
        Assert.NotNull(result);
        var description = result.Value!;
        Assert.Equal(expectedValue, description.Value);
    }

    public static IEnumerable<object?[]> DescriptionValidValueToTrimTests =
    [
        [null, null],
        ["", ""],
        ["   ", ""],
        [$"  {RandomString1}  ", RandomString1],
        [$"  {RandomString100}", RandomString100],
        [$" {RandomString250}  ", RandomString250],
    ];
}