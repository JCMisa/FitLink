using FitLink.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Application.Common.Interfaces
{
    public interface IFitProgramRepository : IRepository<FitProgram>
    {
        void Update(FitProgram entity);
    }
}
