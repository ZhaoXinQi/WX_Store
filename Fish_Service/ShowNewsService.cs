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
    public class ShowNewsService:BaseService<ShowNews>,IShowNewsService
    {
        /// <summary>
        /// 因为继承了baseService类,那里面又一个构造函数,所以必须实现
        /// </summary>
        /// <param name="ibaseRepository"></param>
        public ShowNewsService(IBaseRepository<ShowNews> ibaseRepository) : base(ibaseRepository)
        {

        }
    }
}
