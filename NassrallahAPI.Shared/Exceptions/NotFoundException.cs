using NassrallahAPI.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Shared.Exceptions
{
    public class NotFoundException : NassrallahAPIException
    {
        public NotFoundException(int id) : base("No Id with value "+id+" was found.") { }
    }
}
