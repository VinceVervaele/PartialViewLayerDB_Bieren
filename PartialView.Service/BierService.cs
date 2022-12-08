using PartialView.Models.Entities;
using PartialView.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Service
{
    public class BierService
    {
        private BierDAO bierDAO;

        public BierService()
        {
            bierDAO = new BierDAO();
        }

        public async Task<IEnumerable<Beer>?> GetAll()
        {
            return await bierDAO.GetAll();
        }


        public async Task<IEnumerable<Beer>?> GetAlcohol(decimal? percentage)
        {
            return await bierDAO.GetAlcohol(percentage);
        }

        public async Task<IEnumerable<Beer>?> GetBeerWithBrewer(string? brewer)
        {
            return await bierDAO.GetBeersWithBrewer(brewer);
        }
    }
}
