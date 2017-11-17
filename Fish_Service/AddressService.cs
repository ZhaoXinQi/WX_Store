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
    //地址的bll层
    public  class AddressService:BaseService<Address>,IAddressService
    {
        public  AddressService (IBaseRepository<Address> baseRepository) : base(baseRepository)
        {

        }
    }
}
