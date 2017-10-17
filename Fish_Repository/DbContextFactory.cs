using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;//用此命名空间
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
namespace Fish_Repository
{
    /// <summary>
    /// 用来实力上下文
    /// </summary>
    public class DbContextFactory
    {
        public static Fish_Model CreateDbContext()
        {
            //在Fish_Model 里面寻找DbContext属性, 并且强制转换为Fish_Model    需要引用命名空间
            Fish_Model W_Store = CallContext.GetData("DbContext") as Fish_Model;
            //判断DbcContext 属性是否存在
            if (W_Store == null)
            {
                W_Store = new Fish_Model();//如果没有实例化一个
                CallContext.SetData("DbContext", W_Store);//如果通道中没有该参数，则向通道中添加该参数
                return W_Store;
            }
            return W_Store;
        }
    }
}
