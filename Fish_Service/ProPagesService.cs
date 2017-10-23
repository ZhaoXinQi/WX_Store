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
    public  class ProPagesService:BaseService<ProductInfo>,IProPagesService
    {
        public ProPagesService(IBaseRepository<ProductInfo> baseRepository) : base(baseRepository)
        {

        }
    }
}
