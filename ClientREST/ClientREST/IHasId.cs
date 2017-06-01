using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientREST
{
    public interface IHasId<T>
    {
        Int32 getId();
        void setId(Int32 id);
    }
}
