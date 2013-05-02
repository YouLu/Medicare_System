using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Medical.Framework.Base.Impl;
using Medical.Framework.AOP.Attrs;
using Medical.Framework.Base.Entity;
using System.Collections;

namespace Dao
{
    [Bean(typeof(SampleEntity))]
    public abstract class SampleDao : BaseDao
    {
        [Sql("select * from user_if_t where guid=@guid")]
        public abstract SampleEntity[] GetUserByGuid(int guid);

        //为演示回滚效果，sql语言是错误的
        [Sql("delete user_if_t")]
        public abstract void DeleteUserByGuid(int guid);

        //方法 不好用
        [Sql("select user_nm from user_if_t")]
        public abstract IList GetAllName();
    }
}
