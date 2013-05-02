using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Framework.Base.Entity;


namespace MedicalSystem.pf.Common.Event
{
    public class ScreenEventArgs : MedicalSystemEventArgs
    {






        private TransferScreenType transferType;

        public TransferScreenType TransferType
        {
            get { return transferType; }
            set { transferType = value; }
        }




        private MenuEntity menuEntity;

        public MenuEntity MenuEntity
        {
            get { return menuEntity; }
            set { menuEntity = value; }

        }

        private Object[] param;

        public Object[] Param
        {
            get { return param; }
            set { param = value; }
        }


        private MedicalSystemMessage message;

        public MedicalSystemMessage Message
        {
            get { return message; }
            set { message = value; }
        }



        public ScreenEventArgs(MedicalSystemMessage message,TransferScreenType transferType)
            : base(MedicalSystemEventArgs.MedicalSystemEventType.Screen)
        {
           this.message=message;
           this.transferType = transferType;
        }


        public ScreenEventArgs(MenuEntity menuEntity, Object[] param,TransferScreenType transferType)
            : base(MedicalSystemEventArgs.MedicalSystemEventType.Screen)
        {
            this.menuEntity = menuEntity;
            this.param = param;
            this.transferType = transferType;
        }




        public enum TransferScreenType
        {

            PopUp,
            Content,
            Message
 
        }




    }
}
