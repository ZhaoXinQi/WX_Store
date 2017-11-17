using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using Fish_IRepository;
namespace Fish_Repository
{
    //继承idal层
    public class AddressRepository:BaseRepository<Address>,IAddressRepository
    {
    }
}
