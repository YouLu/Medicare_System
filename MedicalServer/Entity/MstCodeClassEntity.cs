// 
// Generated by 卓;
// GenerateDate  5/8/2009 11:22:18 AM;
//
using System;
using System.Collections.Generic;
using Castle.ActiveRecord;
using System.Collections;
using Medical.Framework.Base.Impl;

namespace Entity
{
    [Serializable]
	[ActiveRecord("MstCodeClass")]
	public class MstCodeClassEntity : BaseEntity 
	{
		
		#region プライベート
		
		private String _codeClass;

        private String _codeClassName;

        private System.DateTime? _updateTime;

        		
		#endregion

		#region 属性
		
		[PrimaryKey(PrimaryKeyType.Assigned, Column="CodeClass")]
		public String CodeClass
		{
			get
			{
			return this._codeClass;
			}
			set
			{
			this._codeClass = value;
			}
		}

  		[Property(Column="CodeClassName")]
		public String CodeClassName
		{
			get
			{
			return this._codeClassName;
			}
			set
			{
			this._codeClassName = value;
			}
		}

  		[Version(Type="timestamp")]
		public System.DateTime? UpdateTime
		{
			get
			{
			return this._updateTime;
			}
			set
			{
			this._updateTime = value;
			}
		}

  
		#endregion


	}
}
