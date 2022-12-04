using Microsoft.EntityFrameworkCore;
using PartialView.Models.Data;
using PartialView.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories
{
    public class BierDAO
    {
        private readonly BierDBcontext _dbContext;

        public BierDAO()
        {
            _dbContext = new BierDBcontext();
        }

        public IEnumerable<Models.Entities.Beer>? GetAll()
        {
            //SQL "select * from Adult"

            try
            {
                return _dbContext.Beers.Include(b => b.BrouwernrNavigation).Include(b => b.SoortnrNavigation).ToList();
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
