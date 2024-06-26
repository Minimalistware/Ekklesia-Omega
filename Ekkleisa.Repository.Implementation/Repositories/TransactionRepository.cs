﻿using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationContext context) 
            : base(context)
        {

        }

        public IEnumerable<Transaction> Browse(TransactionFilter filter)
        {
            IQueryable<Transaction> query = GetQueryable();

            if (filter != null)
            {
                if (filter.BiggerThan != 0)
                {
                    query = query.Where(p => filter.BiggerThan > p.Amount);
                }

                if (filter.LessThan != 0)
                {
                    query = query.Where(p => filter.LessThan < p.Amount);
                }

                if (filter.Before != null)
                {
                    query = query.Where(o => filter.Before > o.Date);
                }

                if (filter.After != null)
                {
                    query = query.Where(o => o.Date > filter.After);
                }

            }
            query = query.OrderByDescending(x => x.Amount);
            return query.ToList();
        }
    }
}
