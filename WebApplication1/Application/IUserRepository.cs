using HealthcareAppointment.Data;
using HealthcareAppointment.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetDoctorsAsync();
        Task<IEnumerable<User>> GetPatientsAsync();
    }
}
