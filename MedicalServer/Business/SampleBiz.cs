using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Impl;
using Medical.Framework.Util;
using Dao;
using Medical.Framework.Base.Entity;
using System.Collections;
using Entity;

namespace Business
{
    public class SampleBiz : AbsBizBase
    {
        //AOP功能
        public AppParam GetUserByGuid(AppParam appParam)
        {
            int guid = Convert.ToInt32(appParam.Get("guid"));
            SampleDao sampleDao = CreateDaoInstance(typeof(SampleDao)) as SampleDao;
            SampleEntity[] sampleEntity = sampleDao.GetUserByGuid(guid);
            AppParam retParam = new AppParam();
            retParam.Add("sampleEntity", sampleEntity);
            return retParam;
        }

        //ORM功能
        public AppParam GetAll()
        {
            SampleDao sampleDao = CreateDaoInstance(typeof(SampleDao)) as SampleDao;
            IList list = sampleDao.FindAllEntity();
            AppParam retParam = new AppParam();
            retParam.Add("list", list);
            return retParam;
        }

        //数据库回滚
        public AppParam ShowRollBack(AppParam appParam)
        {
            SampleDao sampleDao = CreateDaoInstance(typeof(SampleDao)) as SampleDao;
            SampleEntity sampleEntity = (SampleEntity)appParam.Get("sampleEntity");
            int guid = sampleEntity.Guid;
            sampleDao.DeleteEntity(sampleEntity);   //这个语句可以执行删除
            sampleDao.DeleteUserByGuid(guid);     //这个语句是错误的，无法执行
            return new AppParam();
        }

        public AppParam GetAllName(AppParam appParam)
        {
            SampleDao sampleDao = CreateDaoInstance(typeof(SampleDao)) as SampleDao;
            IList nameList = sampleDao.GetAllName();
            AppParam retParam = new AppParam();
            retParam.Add("nameList", nameList);
            return retParam;
        }
    }
}
