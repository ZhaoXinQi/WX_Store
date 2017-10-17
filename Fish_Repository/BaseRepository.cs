using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Fish_IRepository;
using WxShop_Model;
using System.Data.Entity;//需要引用上面几个命名空间

namespace Fish_Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        //上下文对象 new 用工厂模式来代替
        private readonly Fish_Model dbcontext = DbContextFactory.CreateDbContext();
        //设置实体集Dbset
        public DbSet<TEntity> dbset;
        /// <summary>
        /// 构造一个实体集
        /// </summary>
        public BaseRepository()
        {
            dbset = dbcontext.Set<TEntity>();//构造一个实体集
        }
        public void Delete(TEntity entity)
        {
            dbset.Attach(entity);//将给定的实体附加到集的基础上下文中
            dbset.Remove(entity);//利用remove删除
        }

        public void Insert(TEntity entity)
        {
            dbset.Add(entity);//实体集添加一个实体
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            //更新:先找到实体集,然后覆盖原有的
            dbset.Attach(entity);
            //修改状态,把上下文Entry(entity).State 修改为modified;
            dbcontext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// 保存上下文
        /// </summary>
        /// <returns></returns>
        public bool savaChange()
        {
            //保存上下文对象,如果大于0,保存成功
           return  dbcontext.SaveChanges() > 0;
        }
        /// <summary>
        /// 查询多个实体集
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> SelectEntities(Func<TEntity, bool> whereLambda)
        {
            //利用where查询出多个实体,不能用first因为他们两个的返回值不一样,返回的结果也不一样
            return dbset.Where(whereLambda);
        }

        public IEnumerable<TEntity> SelectEntitiesByPage<Ttype>(int pageindex, int pagesize, bool isAsc, Expression<Func<TEntity, Ttype>> orderlambda, Expression<Func<TEntity, bool>> wherelambda)
        {
            //查询出来多个实体
            var result = dbset.Where(wherelambda);
            //判断按那种排序方式排序
            result = isAsc ? result.OrderBy(orderlambda) : result.OrderByDescending(orderlambda);
            //每页显示个数
            result = result.Skip((pageindex - 1) * pagesize).Take(pagesize);
            //返回实体集
            return result.ToList();
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public TEntity SelectEntity(Func<TEntity, bool> whereLambda)
        {
            //利用FirstOrDefault查询出多个实体,不能用where因为他们两个的返回值不一样,返回的结果也不一样
            return dbset.FirstOrDefault(whereLambda);
        }

      
    }
}
