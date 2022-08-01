﻿using MovieApp.Core.Contracts.Repository;
using MovieApp.Core.Entities;
using MovieApp.Infrastructure.Data;
using MovieApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Repository
{
    public class PurchaseRepository : BaseRepositoryAsync<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(CustomerCrmDbContext _context) : base(_context)
        {
        }
    }
}
