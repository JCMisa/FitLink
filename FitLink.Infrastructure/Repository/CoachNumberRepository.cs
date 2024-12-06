using FitLink.Application.Common.Interfaces;
using FitLink.Domain.Entities;
using FitLink.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Infrastructure.Repository
{
    public class CoachNumberRepository : Repository<CoachNumber>, ICoachNumberRepository
    {
        private readonly ApplicationDbContext db;
        public CoachNumberRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }




        public void Update(CoachNumber entity)
        {
            db.CoachNumbers.Update(entity);
        }
    }
}
