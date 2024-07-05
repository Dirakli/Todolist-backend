using Microsoft.AspNetCore.Mvc;
using Task.Domain.Abstract.Services;
using Task.Domain.Entities;
using Task.Domain.Enums;
using Task.Domain.Models;

namespace Task.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController(IAssignmentService assignmentService) : ControllerBase
{
    private readonly IAssignmentService _assignmentService = assignmentService;

    [HttpGet]
    public ActionResult<IEnumerable<Assignment>> GetAll([FromQuery] AssignmentStatus status)
    {
        var assignments = _assignmentService.GetAll(status);
        return Ok(assignments);
    }

    [HttpPost]
    public ActionResult Add([FromBody] AssignmentAddModel model)
    {
        _assignmentService.AddAssignment(model);
        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] AssignmentUpdateModel model)
    {
        _assignmentService.UpdateAssignment(id, model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _assignmentService.DeleteAssignment(id);
        return Ok();
    }
}