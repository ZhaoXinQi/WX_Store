using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;//引用命名空间  表达式树用
using System.Text;
using System.Threading.Tasks;

namespace Fish_IRepository
{
    /// <summary>
    /// 通用类中的每一个功能都是可以别人和的实体使用,如果参数类型不一致,可以用泛型解决
    /// 如果有一定的约束条件:where t :class 表示必须是引用类型,new() 表示要有一个无参数的构造函数
    /// </summary>
    /// <typeparam name="TEntity">参数类型 </typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        //接口是用来定义功能的
        /// <summary>
        /// 插入信息
        /// </summary>
        /// <param name="entity">参数是一个实体</param>
        void Insert(TEntity entity);
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="entity">参数是一个实体</param>
        void Delete(TEntity entity);
        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="entity">参数是一个实体</param>
        void Update(TEntity entity);
        /// <summary>
        ///  保存信息
        /// </summary>
        /// <returns></returns>
        bool savaChange();
        /// <summary>
        ///  单个查询
        /// </summary>
        /// <param name="whereLambda">lambda表达式</param>
        /// <returns></returns>
        /// 单个实体查询 Func<T,Tresult> f 就是一个内置的委托，而lambda表达式也是一个委托（匿名委托）
        //单个肯定带有条件 where 
        TEntity SelectEntity(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 查询多个
        /// </summary>
        /// <param name="whereLambda">lambda表达式</param>
        /// <returns></returns>
        IEnumerable<TEntity> SelectEntities(Func<TEntity, bool> whereLambda);
        //分页 pageindex,pagesize,
        //Expression <Func<TEntity, Ttype>> 和Func<TEntity,bool> wherelambda
        /// <summary>
        /// 带有分页查询的集合
        /// Expression 表达式树 优化查询性能
        /// </summary>
        /// <typeparam name="Ttype"></typeparam>
        /// <param name="pageindex">页数</param>
        /// <param name="pagesize">一页个数</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="orderlambda"></param>
        /// <param name="wherelambda">lambda表达式</param>
        /// <returns></returns>
        IEnumerable<TEntity> SelectEntitiesByPage<Ttype>(int pageindex, int pagesize, bool isAsc,
           Expression<Func<TEntity, Ttype>> orderlambda, Expression<Func<TEntity, bool>> wherelambda);
    }
}
