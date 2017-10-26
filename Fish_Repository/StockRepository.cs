using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using Fish_IRepository;
namespace Fish_Repository
{
    /// <summary>
    /// dal层继承本类基类和idal层接口
    /// </summary>
    public class StockRepository:BaseRepository<Stock>,IStockRepository
    {
    }
}
