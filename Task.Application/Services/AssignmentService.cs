using Task.Domain.Abstract.Repositories;
using Task.Domain.Abstract.Services;
using Task.Domain.Entities;
using Task.Domain.Enums;
using Task.Domain.Models;

namespace Task.Application.Services;

public class AssignmentService(IAssignmentRepository assignmentRepository) : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository = assignmentRepository ?? throw new ArgumentNullException();

    public IEnumerable<Assignment> GetAll(AssignmentStatus status)
    {
        return _assignmentRepository.GetAll(status);
    }

    public void AddAssignment(AssignmentAddModel model)
    {
        if (string.IsNullOrEmpty(model.Name))
        {
            throw new ArgumentException(nameof(model.Name));
        }

        Assignment assignment = new Assignment()
        {
            Name = model.Name,
            Status = model.Status,
        };

        _assignmentRepository.AddAssignment(assignment);
    }

    public void UpdateAssignment(int id, AssignmentUpdateModel model)
    {
        if (string.IsNullOrEmpty(model.Name))
        {
            throw new ArgumentException(nameof(model.Name));
        }

        Assignment assignment = new Assignment()
        {
            Id = id,
            Name = model.Name,
            Status = model.Status,
        };

        _assignmentRepository.UpdateAssignment(assignment);
    }

    public void DeleteAssignment(int id)
    {
        assignmentRepository.DeleteAssignment(id);
    }
}