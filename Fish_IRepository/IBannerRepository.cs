



















using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using Fish_IRepository;
namespace Fish_IRepository
{
    public interface IBannerRepository:IBaseRepository<Banner>//这里需要填写哪个实体类了,不能在使用泛型Tentity
    {
    }
}
