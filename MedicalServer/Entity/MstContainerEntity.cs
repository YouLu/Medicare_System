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
	[ActiveRecord("MstContainer")]
	public class MstContainerEntity : BaseEntity 
	{
		
		#region プライベート
		
		private String _containerCD;

        private String _containerName;

        private System.DateTime? _updateTime;

        		
		#endregion

		#region 属性
		
		[PrimaryKey(PrimaryKeyType.Assigned, Column="ContainerCD")]
		public String ContainerCD
		{
			get
			{
			return this._containerCD;
			}
			set
			{
			this._containerCD = value;
			}
		}

  		[Property(Column="ContainerName")]
		public String ContainerName
		{
			get
			{
			return this._containerName;
			}
			set
			{
			this._containerName = value;
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
