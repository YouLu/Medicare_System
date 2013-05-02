using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using System.Collections;
using NHibernate;
using NHibernate.Expression;
using Medical.Framework.AOP.Attrs;

namespace Medical.Framework.Base.Impl
{
    
    public abstract class BaseDao
    {
        private BaseEntity entity;

        public BaseDao()
        {
            BeanAttribute ba = Attribute.GetCustomAttribute(this.GetType(), typeof(BeanAttribute)) as BeanAttribute;
            Type EntityType = ba.BeanType;
            this.entity  = (BaseEntity )Activator.CreateInstance(EntityType);
        }

        public void DeleteAllEntity()
        {
            entity.DeleteAllEntity();      
        }

        public void DeleteEntity(BaseEntity baseentity)
        {
            entity.DeleteEntity(baseentity);
        }

        public IList FindAllEntity()
        {
            return (IList)entity.FindAllEntity();
        }

        public BaseEntity FindEntityByKey(Object key)
        {
            return entity.FindEntityByKey(key);
        }

        public BaseEntity FindOneEntity(params ICriterion[] criteria)
        {
            return entity.FindOneEntity(criteria);
        }

        public void InsertEntity(BaseEntity baseentity)
        {
            entity.InsertEntity(baseentity);
        }


    }
}
