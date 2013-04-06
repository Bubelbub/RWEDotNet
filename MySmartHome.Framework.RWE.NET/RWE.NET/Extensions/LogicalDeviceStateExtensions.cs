using RWE.NET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RWE.NET.Extensions
{
    public static class LogicalDeviceStateExtensions
    {
        public static void ApplyPropertyChanges(this LogicalDeviceState objDest, LogicalDeviceState  objToCopyFrom)
        {
            if (objDest == null)
                throw new ArgumentNullException();
            if (objToCopyFrom == null)
                throw new ArgumentNullException("objToCopyFrom");
            if (objDest.GetType() != objToCopyFrom.GetType())
                throw new System.Exception("Der Type der Objekte passt nicht überein.");

            foreach (System.Reflection.FieldInfo piOrig in objDest.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!piOrig.GetCustomAttributes(typeof(XmlIgnoreAttribute),true).Any() &&
                    !(objDest.ChangeTracker != null && objDest.ChangeTracker.Keys.Contains(piOrig.Name)))
                {
                    object editedVal = objToCopyFrom.GetType()
                        .GetField(piOrig.Name, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(objToCopyFrom);
                    piOrig.SetValue(objDest, editedVal);
                }
            }
        }
    }
}
