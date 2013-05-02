using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Medical.Framework.Base.Impl;


namespace Entity
{
    [Serializable]
    [ActiveRecord("user_if_t")]
    public class SampleEntity:BaseEntity 
    {
        private string _id;

        private string _name;

        private string _password;

        private string _shihaidv;
        
        private string _tourokusya;

        private DateTime _tourokudate;

        private string _koushinsya;

        private DateTime _koushindate;

        private int _guid;
        [PrimaryKey(PrimaryKeyType.Identity,"guid")]
        public int Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        [Property("user_id")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }        
        }

        [Property("user_nm")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Property("password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [Property("shihai_dv")]
        public string Shihaidv
        {
            get { return _shihaidv; }
            set { _shihaidv = value; }
        }
        [Property("tourokusya")]
        public string Tourokusya
        {
            get { return _tourokusya; }
            set { _tourokusya = value; }
        }
        [Property("koushinsya")]
        public string Koushinsya
        {
            get { return _koushinsya; }
            set { _koushinsya = value; }
        }
        [Property("touroku_date")]
        public DateTime Tourokudate
        {
            get { return _tourokudate; }
            set { _tourokudate = value; }
        }
        [Property("koushin_date")]
        public DateTime Koushindate
        {
            get { return _koushindate; }
            set { _koushindate = value; }
        }
    }
    }

