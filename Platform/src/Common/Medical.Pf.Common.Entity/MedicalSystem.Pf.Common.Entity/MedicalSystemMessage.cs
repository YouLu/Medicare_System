using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Pf.Common.Entity
{
    public class MedicalSystemMessage
    {


        private string messageCode;

        public string MessageCode
        {
            get { return messageCode; }
            set { messageCode = value; }
        }
     
        private string messageLevel;

       
        public string MessageLevel
        {
            get { return messageLevel; }
            set { messageLevel = value; }
        }

      
        private string briefMessage;

      
        public string BriefMessage
        {
            get { return briefMessage; }
            set { briefMessage = value; }
        }

        private string detailMessage;

      
        public string DetailMessage
        {
            get { return detailMessage; }
            set { detailMessage = value; }
        }

      
        public MedicalSystemMessage()
        {
        
        }

      
        public MedicalSystemMessage(string messageCode, string messageLevel, string briefMessage, string detailMessage)
        {
            this.messageCode = messageCode;
            this.messageLevel = messageLevel;
            this.briefMessage = briefMessage;
            this.detailMessage = detailMessage;
        }
        

 

    }
}
