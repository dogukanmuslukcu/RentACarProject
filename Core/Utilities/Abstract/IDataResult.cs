using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Abstract
{
   public interface IDataResult<T>:IResult
    {
        T Data  { get; } 
    }
}
