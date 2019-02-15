using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Reflection
    {
        public string workingDir { get; set; }
        public string dllFileName { get; set; }
        public string extClass { get; set; }
        public string extMethod { get; set; }
        public void _Reflection(Object[] _parameters)
        {
            //First load the external_ assembly
            Assembly _Assembly = Assembly.LoadFile(workingDir + dllFileName);

            //Get th type of the desired class (including the namespace)
            Type _Type = _Assembly.GetType(extClass);

            //Get the supporting method info so we can execute a method.
            MethodInfo _MethodInfo = _Type.GetMethod(extMethod);

            //Create an instance of the desired object
            object _Object = Activator.CreateInstance(_Type);

            //And invoke the method
            // In the null section, these are the parameters, make sure to include them in order.
            _MethodInfo.Invoke(_Object, _parameters);
        }
    }
}
