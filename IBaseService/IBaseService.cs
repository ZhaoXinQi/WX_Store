using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBaseService
{
    /// <summary>
    /// IBLL层接口,参数类型有限制,必须是引用类型 也必须要有构造函数
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    public interface IBaseService<TEntity> where TEntity:class ,new()
    {
        //接口里面只有有方法体,不能有方法体的实现
        /// <summary>
        /// 添加实体    这是IBLL层接口的方法
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Add(TEntity entity);
        /// <summary>
        /// 删除实体    这是IBLL层接口的方法
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Remove(TEntity entity);
        /// <summary>
        /// 修改实体    这是IBLL层接口的方法
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Modify(TEntity entity);
        /// <summary>
        /// 查询单个实体  这是IBLL层接口的方法
        /// </summary>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <returns></returns>
        TEntity GetEntity(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 查询出来多个实体    这是IBLL层接口的方法
        /// </summary>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 实体分页    这是IBLL层接口的方法
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页个数</param>
        /// <param name="OrderByLambda">排序的Lambda</param>
        /// <param name="whereLambda">查询实体的Lambdda</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntityPages<type>(int pageIndex, int pageSize, bool isAsc,Expression<Func<TEntity, bool>> OrderByLambda, Expression<Func<TEntity, bool>> whereLambda);
    }
}
