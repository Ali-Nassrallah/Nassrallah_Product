using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Shared.Common
{
    public abstract class NassrallahAPIException : Exception
    {
        public NassrallahAPIException(string message) : base(message) { }
    }
}
