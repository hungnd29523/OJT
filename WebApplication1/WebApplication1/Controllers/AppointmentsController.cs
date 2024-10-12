using HealthcareAppointment.Business;
using HealthcareAppointment.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Appointment>> GetAppointments()
    {
        var appointments = _appointmentService.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public ActionResult<Appointment> GetAppointment(int id)
    {
        var appointment = _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    [HttpPost]
    public ActionResult<Appointment> CreateAppointment([FromBody] Appointment appointmentDto)
    {
        var appointment = _appointmentService.ScheduleAppointmentAsync(appointmentDto);
        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }
    [HttpPut("{id}")]
    public ActionResult<Appointment> UpdateAppointment(int id, [FromBody] Appointment updateDto)
    {
        var appointment = _appointmentService.UpdateAppointmentAsync(updateDto);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAppointment(int id)
    {
        var result = _appointmentService.CancelAppointmentAsync(id);

        return NoContent();
    }

    [HttpPatch("{id}/cancel")]
    public ActionResult CancelAppointment(int id)
    {
        var appointment = _appointmentService.CancelAppointmentAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    [HttpGet("doctors/{doctorId}/search")]
    public ActionResult<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var appointments = _appointmentService.GetAppointmentsForDoctorAsync(doctorId);
        return Ok(appointments);
    }
}