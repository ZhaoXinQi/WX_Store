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
	public	class OrederChirldService:BaseService<OrderChild>,IOrderChirldService
	{
		public OrederChirldService(IBaseRepository<OrderChild> baseRepository):base(baseRepository){

		}
	}
}
