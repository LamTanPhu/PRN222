using ModelViews.Entity;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CenterRepository
    {
        private readonly ApplicationDbContext _context;


        public async Task CreateCenter(VaccineCenter vaccineCenter)
        {
             await _context.VaccineCenters.AddAsync(vaccineCenter);
        }
    }
}
