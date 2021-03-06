// 
// Generated by 卓;
// GenerateDate  5/8/2009 11:01:50 AM;
//
using System;
using System.Collections.Generic;
using Castle.ActiveRecord;
using System.Collections;
using Medical.Framework.Base.Impl;

namespace Entity
{	
	
	[Serializable]
	public class SpecimenEntityKey
	{
		private String _receptionID;

        private String _specimenID;
	
		[KeyProperty(Column="ReceptionID")]
		public String ReceptionID
		{
			get
			{
			return this._receptionID;
			}
			set
			{
			this._receptionID = value;
			}
		}

  		[KeyProperty(Column="SpecimenID")]
		public String SpecimenID
		{
			get
			{
			return this._specimenID;
			}
			set
			{
			this._specimenID = value;
			}
		}

  
		
		public override int GetHashCode()
		{
			return _receptionID.GetHashCode()^_specimenID.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			SpecimenEntityKey key = obj as SpecimenEntityKey;
			if (key == null)
			{
				return false;
			}
			if (_receptionID != key._receptionID||_specimenID != key._specimenID)
			{
				return false;
			}
			return true;
		}
	}

	[Serializable]
	[ActiveRecord("Specimen")]
	public class SpecimenEntity : BaseEntity 
	{
		
		#region プライベート
		
		private SpecimenEntityKey _key;

        private Int32 _capacity;

        private String _comment;

        private String _containerCD;

        private String _coctorCD;

        private String _crugProductCD;

        private System.DateTime? _harvestDate;

        private String _harvestLocation;

        private Int32 _harvestNum;

        private System.DateTime? _harvestScheduleDate;

        private System.DateTime? _updateTime;

        		
		#endregion

		#region 属性
		
		[CompositeKey]
		public SpecimenEntityKey Key
		{
			get { return _key; }
			set { _key = value; }
		}

  		[Property(Column="Capacity")]
		public Int32 Capacity
		{
			get
			{
			return this._capacity;
			}
			set
			{
			this._capacity = value;
			}
		}

  		[Property(Column="Comment")]
		public String Comment
		{
			get
			{
			return this._comment;
			}
			set
			{
			this._comment = value;
			}
		}

  		[Property(Column="ContainerCD")]
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

  		[Property(Column="DoctorCD")]
		public String CoctorCD
		{
			get
			{
			return this._coctorCD;
			}
			set
			{
			this._coctorCD = value;
			}
		}

  		[Property(Column="DrugProductCD")]
		public String CrugProductCD
		{
			get
			{
			return this._crugProductCD;
			}
			set
			{
			this._crugProductCD = value;
			}
		}

  		[Property(Column="HarvestDate")]
		public System.DateTime? HarvestDate
		{
			get
			{
			return this._harvestDate;
			}
			set
			{
			this._harvestDate = value;
			}
		}

  		[Property(Column="HarvestLocation")]
		public String HarvestLocation
		{
			get
			{
			return this._harvestLocation;
			}
			set
			{
			this._harvestLocation = value;
			}
		}

  		[Property(Column="HarvestNum")]
		public Int32 HarvestNum
		{
			get
			{
			return this._harvestNum;
			}
			set
			{
			this._harvestNum = value;
			}
		}

  		[Property(Column="HarvestScheduleDate")]
		public System.DateTime? HarvestScheduleDate
		{
			get
			{
			return this._harvestScheduleDate;
			}
			set
			{
			this._harvestScheduleDate = value;
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
