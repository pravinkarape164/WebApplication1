using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.DataAccess.Repository.IRepository
{
    public  interface IProductRepository :IRepository<Product>
    {
        void Update(Product db);
       
    }
}
