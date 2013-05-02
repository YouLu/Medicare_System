//----------------------------------------------------------- 
// 
// 系统名  : MedicalSystem 
// 作者    :  王梓烨
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using MedicalSystem.Pf.Common.Context;
using Medical.Framework.Base.Entity;


namespace MedicalSystem.Pf.Common.Context
{
    //上下文类
    public class MedicalSystemContext
    {
        //单例
        private MedicalSystemContext()
        {
             
        
        }
        private static  MedicalSystemContext instance;

     
        public static MedicalSystemContext GetInstance()
        {       
            if (MedicalSystemContext.instance == null)
            {
                
                instance = new MedicalSystemContext();
            }
        
            return instance;
          
        }


        //登录用户信息
        private UserEntity logonUser;

        public UserEntity LogonUser
        {
            get { return logonUser; }
            set { logonUser = value; }
        }

        //menu信息
        private List<MenuEntity> menuList ;

        public List<MenuEntity> MenuList
        {
            get { return menuList; }
            set { menuList = value; }
        }

        //子menu与子画面的对应关系  
        private Dictionary<string, SubScreenEntity> menuScreenMap ;

        public Dictionary<string, SubScreenEntity> MenuScreenMap
        {
            get { return menuScreenMap; }
            set { menuScreenMap = value; }
        }


        //系统所有的message信息


        private Dictionary<string, MedicalSystemMessage> messageMap;

        public Dictionary<string, MedicalSystemMessage> MessageMap
        {
            get { return messageMap; }
            set { messageMap = value; }
        }
        private Dictionary<string, string> mstCodeMap;

        public Dictionary<string, string> MstCodeMap
        {
            get { return mstCodeMap; }
            set { mstCodeMap = value; }
        }




        private Dictionary<string, string> mstContainerMap;

        public Dictionary<string, string> MstContainerMap
        {
            get { return mstContainerMap; }
            set { mstContainerMap = value; }
        }


        private Dictionary<string, string> mstDiagnosisDeptMap;

        public Dictionary<string, string> MstDiagnosisDeptMap
        {
            get { return mstDiagnosisDeptMap; }
            set { mstDiagnosisDeptMap = value; }
        }


        private Dictionary<string, string> mstDiseaseMap;

        public Dictionary<string, string> MstDiseaseMap
        {
            get { return mstDiseaseMap; }
            set { mstDiseaseMap = value; }
        }


        private Dictionary<string, string> mstDoctorMap;

        public Dictionary<string, string> MstDoctorMap
        {
            get { return mstDoctorMap; }
            set { mstDoctorMap = value; }
        }

        


        private Dictionary<string, string> mstDrugProductMap;

        public Dictionary<string, string> MstDrugProductMap
        {
            get { return mstDrugProductMap; }
            set { mstDrugProductMap = value; }
        }


        private Dictionary<string, string> mstWardMap;

        public Dictionary<string, string> MstWardMap
        {
            get { return mstWardMap; }
            set { mstWardMap = value; }
        }




        //清空
        public void Clear()
        {

            logonUser= null;   
            menuList.Clear(); 
            menuScreenMap.Clear();
            messageMap.Clear();

        }

     
     
    }
 }











