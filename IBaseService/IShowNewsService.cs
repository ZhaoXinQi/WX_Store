using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
namespace IBaseService
{
    /// <summary>
    /// IBLL层的ShowNews需要继承IBLL层里面的基类接口
    /// </summary>
    public interface IShowNewsService:IBaseService<ShowNews>
    {
    }
}
