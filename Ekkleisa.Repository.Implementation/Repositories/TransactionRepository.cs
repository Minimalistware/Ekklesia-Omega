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
                if (filter.DiscountBiggerThan != 0)
                {
                    query = query.Where(p => filter.DiscountBiggerThan > p.Amount);
                }

                if (filter.DiscountLessThan != 0)
                {
                    query = query.Where(p => filter.DiscountLessThan < p.Amount);
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
