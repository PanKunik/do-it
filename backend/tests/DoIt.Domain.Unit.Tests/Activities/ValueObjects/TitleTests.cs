using DoIt.Domain.Activities;
using DoIt.Domain.Activities.ValueObjects;
using DoIt.Domain.Unit.Tests.Utilities;

namespace DoIt.Domain.Unit.Tests.Activities.ValueObjects;

public class TitleTests
{
    private static readonly string RandomString1 = RandomHelper.String(1);
    private static readonly string RandomString3 = RandomHelper.String(3);
    private static readonly string RandomString50 = RandomHelper.String(50);
    
    [Theory, MemberData(nameof(TitleEmptyOrWhiteSpaceValueTests))]
    public void Create_WhenValueIsNullOrWhiteSpace_ShouldReturnErrorResult(string value)
    {
        // Act
        var result = Title.Create(value);
        
        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorCodes.Titles.Empty, result.Error!.Code);
    }

    public static IEnumerable<object[]> TitleEmptyOrWhiteSpaceValueTests =
    [
        [null!],
        [""],
        ["   "]
    ];
    
    [Theory, MemberData(nameof(TitleTooLongValueTests))]
    public void Create_WhenValueIsTooLong_ShouldReturnErrorResult(string value)
    {
        // Act
        var result = Title.Create(value);
        
        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorCodes.Titles.TooLong, result.Error!.Code);
    }

    public static IEnumerable<object[]> TitleTooLongValueTests =
    [
        [RandomHelper.String(51)],
        [RandomHelper.String(100)]
    ];

    [Theory, MemberData(nameof(TitleValidValueTests))]
    public void Create_WhenValueIsValid_ShouldReturnSuccessResultWithTitle(string value)
    {
        // Act
        var result = Title.Create(value);
        
        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        var title = result.Value!;
        Assert.Equal(value, title.Value);
    }

    public static IEnumerable<object[]> TitleValidValueTests =
    [
        [RandomString1],
        [RandomString3],
        [RandomString50]
    ];

    [Theory, MemberData(nameof(TitleValidValuesToTrimTests))]
    public void Create_WhenValueStartsOrEndsWithWhiteSpace_ShouldReturnSuccessResultWithTrimmedTitle(string value, string expectedValue)
    {
        // Act
        var result = Title.Create(value);
        
        // Assert
        Assert.NotNull(result);
        var title = result.Value!;
        Assert.Equal(expectedValue, title.Value);
    }

    public static IEnumerable<object[]> TitleValidValuesToTrimTests =
    [
        [$"    { RandomString1 }", RandomString1],
        [$"{ RandomString1 }    ", RandomString1],
        [$"  { RandomString50 }  ", RandomString50]
    ];
}