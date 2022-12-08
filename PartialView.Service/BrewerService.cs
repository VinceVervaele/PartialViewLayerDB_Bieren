using PartialView.Models.Entities;
using PartialView.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Service
{
    public class BrewerService
    {
        private BrewerDAO brewerDAO;

        public BrewerService()
        {
            brewerDAO = new BrewerDAO();
        }

        public async Task<IEnumerable<Brewery>?> GetAll()
        {
            return await brewerDAO.GetAll();
        }
    }
}
