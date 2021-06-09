﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.View.Manager.Help
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        ManagerView prozor;
        public JavaScriptControlHelper(ManagerView w)
        {
            prozor = w;
        }
    }
}
