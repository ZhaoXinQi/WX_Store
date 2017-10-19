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
    /// DAL需要继承本层的一个基类操作,还需要继承IDAL层的IShwoNewsRepository接口
    /// </summary>
    public class ShowNewsRepository:BaseRepository<ShowNews>,IShwoNewsRepository
    {
    }
}
