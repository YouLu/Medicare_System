using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using System.Collections;
using NHibernate.Expression;
using System.Reflection;
using Medical.Framework.Exception;
using Castle.ActiveRecord.Framework;

namespace Medical.Framework.Base.Impl
{
    [Serializable]
    public class BaseEntity : ActiveRecordBase
    {
        public BaseEntity() 
        {
           
        }

        public IList<BaseEntity>  FindAllEntity()
        {
            try
            {
                IList<BaseEntity> list = (IList<BaseEntity>)ActiveRecordBase.FindAll(this.GetType());
                return list;
            }
            catch (NotFoundException ne)
            {
                throw new OrmException("没有找到信息"+ne.Message);
            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            } 
            catch(System.Exception e)
            {
                throw new OrmException("其它异常"+e.Message );
            }
        }

        public BaseEntity FindEntityByKey(object key)
        {
            try
            {
                return (BaseEntity)FindByPrimaryKey(this.GetType(), key);
            }
            catch (NotFoundException ne)
            {
                throw new OrmException("没有找到信息" + ne.Message);
            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            }
            catch (System.Exception e)
            {
                throw new OrmException("其它异常" + e.Message);
            }
        }

        public BaseEntity FindOneEntity(params ICriterion[] criteria)
        {
            try
            {
                return (BaseEntity)FindOne(this.GetType(), criteria);
            }
            catch (OrmException ne)
            {
                throw new OrmException("没有找到信息" + ne.Message);
            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            }
            catch (System.Exception e)
            {
                throw new OrmException("其它异常" + e.Message);
            }
        }

        public void DeleteAllEntity()
        {
            try
            {
                DeleteAll(this.GetType());
            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            }
            catch (System.Exception e)
            {
                throw new OrmException("其它异常" + e.Message);
            }
        }

        public void DeleteEntity(BaseEntity be)
        {
            try
            {
                Delete(be);
            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            }
            catch (System.Exception e)
            {
                throw new OrmException("其它异常" + e.Message);
            }
        }

        public void InsertEntity(BaseEntity be)
        {
            try
            {
                Create(be);
            }
            catch (ActiveRecordException are)
            {
                throw new OrmException("ActiveRecordException" + are.Message);
            }
            catch (System.Exception e)
            {
                throw new OrmException("其它异常" + e.Message);
            }
        }
    }
}
