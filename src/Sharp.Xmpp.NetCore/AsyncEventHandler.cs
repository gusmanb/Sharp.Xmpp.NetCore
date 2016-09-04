using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharp.Xmpp
{
    public delegate Task AsyncEventHandler(object sender, EventArgs e);
    public delegate Task AsyncEventHandler<T>(object sender, T e) where T : EventArgs;
}
