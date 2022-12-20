using System;
using Fwk.Bases;
using System.Collections.Generic;

namespace Fwk.Bases
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Response<T> : ServiceContractBase<T> where T : IBaseEntity, new()
    {

    }

}
