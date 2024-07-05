using Task.Domain.Enums;

namespace Task.Domain.Entities;

public class Assignment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AssignmentStatus Status { get; set; }
}