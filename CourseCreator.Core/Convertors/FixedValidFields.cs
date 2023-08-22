using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Convertors
{
    public class FixedValidFields
    {
        public static string ValidEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
