﻿using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class BrandRepository:GenericRepository<Brand>,IBrandRepository
	{
		public BrandRepository(RRContext _context) : base(_context)
		{
		}

		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
		}
	}
}
