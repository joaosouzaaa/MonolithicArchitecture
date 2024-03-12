using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Mappers;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests;
public sealed class ScheduleMapperTests
{
    private readonly ScheduleMapper _scheduleMapper;

    public ScheduleMapperTests()
    {
        _scheduleMapper = new ScheduleMapper();
    }

    [Fact]
    public void DomainListToResponseList_SuccessfulScenario()
    {
        // A
        var scheduleList = new List<Schedule>()
        {
            ScheduleBuilder.NewObject().DomainBuild()
        };

        // A
        var scheduleResponseListResult = _scheduleMapper.DomainListToResponseList(scheduleList);

        // A
        Assert.Equal(scheduleResponseListResult.Count, scheduleList.Count);
    }
}
