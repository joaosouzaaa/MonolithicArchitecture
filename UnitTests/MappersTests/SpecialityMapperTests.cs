﻿using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Mappers;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests;
public sealed class SpecialityMapperTests
{
    private readonly SpecialityMapper _specialityMapper;

    public SpecialityMapperTests()
    {
        _specialityMapper = new SpecialityMapper();
    }

    [Fact]
    public void SaveToDomain_SuccessfulScenario()
    {
        // A
        var specialitySave = SpecialityBuilder.NewObject().SaveBuild();

        // A
        var specialityResult = _specialityMapper.SaveToDomain(specialitySave);

        // A
        Assert.Equal(specialityResult.Name, specialitySave.Name);
    }

    [Fact]
    public void DomainListToResponseList_SuccessfulScenario()
    {
        // A
        var specialityList = new List<Speciality>()
        {
            SpecialityBuilder.NewObject().DomainBuild(),
            SpecialityBuilder.NewObject().DomainBuild(),
            SpecialityBuilder.NewObject().DomainBuild()
        };

        // A
        var specialityResponseListResult = _specialityMapper.DomainLisToResponseList(specialityList);

        // A
        Assert.Equal(specialityResponseListResult.Count, specialityList.Count);
    }
}
