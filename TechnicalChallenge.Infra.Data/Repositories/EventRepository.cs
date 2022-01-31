﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Entities;
using TechnicalChallenge.Domain.Interfaces.Repositories;
using TechnicalChallenge.Infra.Data.Context;

namespace TechnicalChallenge.Infra.Data.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        protected readonly TechnicalChallengeContext _context;

        public EventRepository(TechnicalChallengeContext context)
            : base(context)
        {
            _context = context;
        }


        public IList<Event> GetAll(int take,int skip,Guid UserId)
        {
            return _context.Events.Where(x => x.CreatedBy == UserId).Skip(skip).Take(take).ToList();
        }

        public IList<Event> GetAllResume(int take, int skip, Guid UserId)
        {
            return _context.Events.Where(x => x.CreatedBy == UserId).Skip(skip).Take(take)
                .Include(x => x.EventUsers).ToList();
        }

    }
}
