﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Infra
{
    public class Validator
    {
        public static void Validate(IObjectValidation obj)
        {
            obj.Validate();
        }

   
}
}
