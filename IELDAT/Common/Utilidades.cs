using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IELDAT.Common
{
    public class Utilidades<TSource, TTarget> where TTarget : class, new()
    {
        public static List<TTarget> Transformar(ISingleResult<TSource> lSource)
        {
            List<TTarget> lTarget = new List<TTarget>();


            foreach (TSource a in lSource)
            {
                TTarget b = new TTarget();

                Type typeB = b.GetType();
                foreach (PropertyInfo property in a.GetType().GetProperties())
                {
                    if (!property.CanRead || (property.GetIndexParameters().Length > 0))
                        continue;

                    PropertyInfo other = typeB.GetProperty(property.Name);
                    if ((other != null) && (other.CanWrite))
                        other.SetValue(b, property.GetValue(a, null), null);
                }

                lTarget.Add(b);
            }

            

            return lTarget;
        }
    }
}
