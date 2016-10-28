﻿using Greatbone.Core;

namespace Greatbone.Sample
{
    public class IfAdminAttribute : IfAttribute
    {
        public override bool Test(WebContext wc)
        {
            Token tok = (Token)wc.Principal;
            return false;
        }
    }
}