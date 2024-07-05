using Task.Domain.Entities;
using Task.Domain.Enums;

namespace Task.Domain.Abstract.Repositories;

public interface IAssignmentRepository
{
    IEnumerable<Assignment> GetAll(AssignmentStatus status);
    void AddAssignment(Assignment model);
    void UpdateAssignment(Assignment model);
    void DeleteAssignment(int Id);
}