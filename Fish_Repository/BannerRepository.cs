using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using Fish_IRepository;
namespace Fish_Repository
{
    public class BannerRepository:BaseRepository<Banner>, IBannerRepository  //继承BaseRepository<Banner>,IBannerRepository,不需要写方法,接口已实现
    {
    }
}
