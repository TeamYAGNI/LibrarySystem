﻿using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class LendingRepository : Repository<Lending>, ILendingRepository
    {
        public LendingRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public IEnumerable<Lending> GetLendingsOlderThanAMonth()
        {
            return this.Find(l => l.BorrоwDate.AddMonths(1) < DateTime.Today);
        }

        public IEnumerable<Lending> GetLendingsByClientPIN(string PIN)
        {
            return this.LibraryDbContext.Lendings.Where(l => l.Client.PIN == PIN);
        }

        public IEnumerable<Lending> GetLendingsByBookISBN(string ISBN)
        {
            return this.LibraryDbContext.Lendings.Where(l => l.Book.ISBN == ISBN);
        }

        public IEnumerable<Lending> GetAllLendingsWithRemarks()
        {
            return this.Find(l => l.Remarks != null);
        }

        public IEnumerable<string> GetAllLendingsRemarksByClientPIN(string PIN)
        {
            return this.LibraryDbContext.Lendings.Where(l => l.Client.PIN == PIN)
                .Select(l => l.Remarks).ToList();
        }
    }
}
