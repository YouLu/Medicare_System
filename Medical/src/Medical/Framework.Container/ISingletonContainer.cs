using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Framework.Container
{
    public interface ISingletonContainer
    {
        //void AddComponent(string NameSpace, string key, string classname);

        Object GetComponent(string key);

        void AddComponent(string code, string message);

        string GetMessage(string key);

        void AddComponent(string key, Object obj);

        Object GetObject(string key);

    }
}
