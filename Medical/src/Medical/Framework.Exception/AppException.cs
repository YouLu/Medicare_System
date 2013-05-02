/*
 * 作用：自定义应用异常基类 
 * 日期：2009-3-30
 * 作者：吕游
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Framework.Exception
{
    //系统应用异常基类
    public class AppException : System.ApplicationException
    {
        #region 属性以及访问器方法

        private readonly string _messageCode;
        private readonly Object[] _args;
        private readonly string _simpleMessage;
        private readonly string _fullMessage;

        public string MessageCode
        {
            get { return _messageCode; }
        }

        public Object[] Args
        {
            get { return _args; }
        }

        public string SimpleMessage
        {
            get { return _simpleMessage; }
        }

        public string FullMessage
        {
            get { return _fullMessage; }
        }

        #endregion

        #region 构造方法

        public AppException(string messageCode, Object[] args)
            : this(messageCode, args, null)
        { 
        }

        public AppException(string messageCode, Object[] args, System.Exception cause)
            : base(messageCode, cause)
        {
            _messageCode = messageCode;
            _args = args;
            _simpleMessage = MessageFormatter.GetSampleMessage(messageCode,_args);
            _fullMessage = "[" + _messageCode + "]" + _simpleMessage;
        }

        #endregion
    }
}
