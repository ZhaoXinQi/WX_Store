using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
namespace Fish_IRepository
{

    /// <summary>
    /// 定义istock接口
    /// </summary>
    public  interface IStockRepository:IBaseRepository<Stock>
    {
    }
}
