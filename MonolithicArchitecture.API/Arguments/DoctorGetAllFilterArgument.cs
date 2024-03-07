using MonolithicArchitecture.API.Settings.PaginationSettings;

namespace MonolithicArchitecture.API.Arguments;
public sealed class DoctorGetAllFilterArgument : PageParameters
{
    public List<int> SpecialityIds { get; set; }
    public DateTime? InitialTime { get; set; }
    public DateTime? FinalTime { get; set; }
}
