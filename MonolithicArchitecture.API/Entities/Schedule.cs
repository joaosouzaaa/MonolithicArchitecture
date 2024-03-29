﻿namespace MonolithicArchitecture.API.Entities;
public sealed class Schedule
{
    public int Id { get; set; }
    public required DateTime Time { get; set; }

    public required int DoctorAttendantId { get; set; }
    public DoctorAttendant Doctor { get; set; }
}
