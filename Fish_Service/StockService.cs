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
    /// <summary>
    /// bll继承基类和ibll层的stock接口
    /// </summary>
    public  class StockService:BaseService<Stock>,IStockService
    {
        public StockService(IBaseRepository<Stock> baseRepository) : base(baseRepository)
        {

        }
    }
}
