using HealthcareAppointment.Data;
using HealthcareAppointment.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        Test1Context _context;
        public UserRepository(Test1Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetDoctorsAsync()
        {
            return await _context.Users.Where(u => u.Role == "Doctor").ToListAsync();
        }

        public async Task<IEnumerable<User>> GetPatientsAsync()
        {
            return await _context.Users.Where(u => u.Role == "Patient").ToListAsync();
        }
    }
}
