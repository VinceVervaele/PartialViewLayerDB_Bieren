using Microsoft.EntityFrameworkCore;
using PartialView.Models.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories
{
    public class BrewerDAO
    {
        private readonly BierDBcontext _dbContext;

        public BrewerDAO()
        {
            _dbContext = new BierDBcontext();
        }

        public async Task<IEnumerable<Models.Entities.Brewery>?> GetAll()
        {
            //SQL "select * from Adult"

            try
            {
                return await _dbContext.Breweries.ToListAsync();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                Debug.WriteLine("Didn't found db", ex.ToString());
                return null;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
