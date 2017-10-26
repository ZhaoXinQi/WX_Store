using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using Fish_IRepository;
namespace IBaseService
{
    public interface IProService : IBaseService<ProductInfo>
    {
        //*object GetEntityPages(int v1, int v2, bool v3, object p1, Func<object, bool> p2);
    }
}
