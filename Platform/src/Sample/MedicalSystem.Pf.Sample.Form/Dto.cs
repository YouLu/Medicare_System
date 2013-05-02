using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using Entity;

namespace MedicalSystem.Pf.Sample.Form
{
    public class Dto : ObservableCollection<MstDoctorEntity>
    {
        public Dto()
        { 
            
        }
        public Dto(IList doctorList)
        {
            foreach (MstDoctorEntity doctor in doctorList)
            {
                Add(doctor);
            }
        }
    }
}
