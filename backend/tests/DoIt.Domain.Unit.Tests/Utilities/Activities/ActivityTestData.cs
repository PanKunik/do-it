using DoIt.Domain.Activities.ValueObjects;

namespace DoIt.Domain.Unit.Tests.Utilities.Activities;

public static class ActivityTestData
{
    public static Title ValidTitle(string value = "Valid activity title")
        => Title.Create(value).Value!;
}