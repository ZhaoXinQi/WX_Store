using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBaseService;
using WxShop_Model;
using Fish_IRepository;
namespace Fish_Service
{
    public class BannerService:BaseService<Banner>,IBannerService
    {
        public BannerService(IBaseRepository<Banner> baseReposity) : base(baseReposity)
        {

        }
    }
}
