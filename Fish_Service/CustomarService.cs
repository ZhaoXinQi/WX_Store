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
    /// 用户表 BLL层
    /// </summary>
    public class CustomarService:BaseService<Customar>,ICustomarService
    {
        public CustomarService(IBaseRepository<Customar> baseRepository):base(baseRepository)
        {

        }
    }
}
