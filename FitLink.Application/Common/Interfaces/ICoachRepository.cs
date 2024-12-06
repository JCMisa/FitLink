using FitLink.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Application.Common.Interfaces
{
    public interface ICoachRepository : IRepository<Coach>
    {
        void Update(Coach entity);
    }
}
