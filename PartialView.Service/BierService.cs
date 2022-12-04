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

        public IEnumerable<Beer>? GetAll()
        {
            return bierDAO.GetAll();
        }
    }
}
