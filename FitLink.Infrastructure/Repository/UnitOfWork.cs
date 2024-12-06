using FitLink.Application.Common.Interfaces;
using FitLink.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public ICoachRepository Coach { get; private set; }
        public ICoachNumberRepository CoachNumber { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            Coach = new CoachRepository(this.db);
            CoachNumber = new CoachNumberRepository(this.db);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
