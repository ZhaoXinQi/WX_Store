using IBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Fish_IRepository;
namespace Fish_Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        //声明一个DAL对象   需要使用dal里面的方法
        private IBaseRepository<TEntity> baseRepository;//baseRepository 就像dal中的对象
        //利用构造函数传参数,依赖注入
        public BaseService(IBaseRepository<TEntity> ibaseRepository)
        {
            this.baseRepository = ibaseRepository;
        }
        /// <summary>
        /// 添加      这个是BLL层
        /// </summary>
        /// <param name="entity">添加的实体</param>
        /// <returns></returns>
        public bool Add(TEntity entity)
        {
            baseRepository.Insert(entity);
            return baseRepository.savaChange();
        }

        public object ExecuteCommand(string order, params object[] param)
        {
            return baseRepository.ExecuteCommand(order, param);
             
        }

        /// <summary>
        /// 查询多个实体      这个是BLL层
        /// </summary>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return baseRepository.SelectEntities(whereLambda);
        }
        /// <summary>
        /// 查询单个        这个是BLL层
        /// </summary>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <returns></returns>
        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
            return baseRepository.SelectEntity(whereLambda);
        }
        /// <summary>
        /// 分页      这是BLL层
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页个数</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="OrderByLambda">排序Lambda表达式</param>
        /// <param name="whereLambda">查询Lambda表达式</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntityPages<type>(int pageIndex, int pageSize, bool isAsc, Expression<Func<TEntity, bool>> OrderByLambda, Expression<Func<TEntity, bool>> whereLambda)
        {
            Expression<Func<TEntity, object>> Orderlambda = null;
            return baseRepository.SelectEntitiesByPage(pageIndex, pageSize, isAsc, Orderlambda, whereLambda);

        }
        /// <summary>
        /// 修改      这是BLL层
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Modify(TEntity entity)
        {
            baseRepository.Update(entity);
            return baseRepository.savaChange();
        }
        /// <summary>
        /// 删除      这是BLL层
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Remove(TEntity entity)
        {
            baseRepository.Delete(entity);
            return baseRepository.savaChange();
        }
    }
}
