using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBaseService;
using WxShop_Model;
namespace IBaseService
{
    public interface IBannerService:IBaseService<Banner>//这里需要填写哪个实体类了,不能在使用泛型Tentity 
    {
    }
}
