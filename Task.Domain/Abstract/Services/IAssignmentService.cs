using Task.Domain.Entities;
using Task.Domain.Enums;
using Task.Domain.Models;

namespace Task.Domain.Abstract.Services;

public interface IAssignmentService
{
    IEnumerable<Assignment> GetAll(AssignmentStatus status);
    void AddAssignment(AssignmentAddModel model);
    void UpdateAssignment(int id, AssignmentUpdateModel model);
    void DeleteAssignment(int id);
}