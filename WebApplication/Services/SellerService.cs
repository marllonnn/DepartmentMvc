using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.ViewModels;
using WebApplication.Services.Exceptions;

namespace WebApplication.Services
{
    public class SellerService
    {
        private readonly WebApplicationContext _context;
       

        public SellerService(WebApplicationContext context)
        {
            _context = context;
            
        }

        public ICollection<Seller> FindAll()
        {
           

            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            

            _context.Add(obj);
            _context.SaveChanges();
        }

       public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.Id == id);
            
            

        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);

            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            
            if(!_context.Seller.Any(x => x.Id == obj.Id )) { throw new NotFoundException("Id not found"); }


            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException e) { throw new DbConcurrencyException(e.Message); }
           

        }


    }
}
