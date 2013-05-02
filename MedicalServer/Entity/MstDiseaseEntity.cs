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
	[ActiveRecord("MstDisease")]
	public class MstDiseaseEntity : BaseEntity 
	{
		
		#region プライベート
		
		private String _diseaseCD;

        private String _diseaseName;

        private Int32 _dispOrder;

        private System.DateTime? _updateTime;

        		
		#endregion

		#region 属性
		
		[PrimaryKey(PrimaryKeyType.Assigned, Column="DiseaseCD")]
		public String DiseaseCD
		{
			get
			{
			return this._diseaseCD;
			}
			set
			{
			this._diseaseCD = value;
			}
		}

  		[Property(Column="DiseaseName")]
		public String DiseaseName
		{
			get
			{
			return this._diseaseName;
			}
			set
			{
			this._diseaseName = value;
			}
		}

  		[Property(Column="DispOrder")]
		public Int32 DispOrder
		{
			get
			{
			return this._dispOrder;
			}
			set
			{
			this._dispOrder = value;
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
