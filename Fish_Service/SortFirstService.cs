using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using Fish_IRepository;
using IBaseService;
namespace Fish_Service
{
    //引用bll里面的基类,并且以来IBLL里面的接口
    public class SortFirstService:BaseService<ProductSort>,ISortFirstService
    {
        //这个构造函数是基类用来依赖注入的
        public SortFirstService(IBaseRepository<ProductSort> baseRepository) : base(baseRepository)
        {

        }
    }
}
