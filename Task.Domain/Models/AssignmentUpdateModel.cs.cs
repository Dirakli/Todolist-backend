using Task.Domain.Enums;

namespace Task.Domain.Models;

public class AssignmentUpdateModel
{
    public string Name { get; set; }
    public AssignmentStatus Status { get; set; }
}