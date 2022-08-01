using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Core.Entities;

namespace MovieApp.Core.Contracts.Repository
{
    public interface IReportRepository:IRepositoryAsync<Review>
    {
    }
}
