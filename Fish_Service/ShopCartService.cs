using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using IBaseService;
using Fish_IRepository;
namespace Fish_Service
{
    public class ShopCartService:BaseService<ShoppongCart>,IShopCartService
    {
        public ShopCartService(IBaseRepository<ShoppongCart> baseRepository) : base(baseRepository)
        {

        }
    }
}
