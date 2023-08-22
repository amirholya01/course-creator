using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Utils
{
    public class Util
    {
        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
