using Task.Domain.Enums;

namespace Task.Domain.Models;

public class AssignmentAddModel
{
    public string Name { get; set; }
    public AssignmentStatus Status { get; set; }
}