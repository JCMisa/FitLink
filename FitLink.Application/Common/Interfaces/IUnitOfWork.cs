using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ICoachRepository Coach { get; }
        ICoachNumberRepository CoachNumber { get; }
        IFitProgramRepository FitProgram { get; }
        void Save();
    }
}
