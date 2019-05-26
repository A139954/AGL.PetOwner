using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.PetOwner.Common
{
    public class Result<TData>
    {
        private Result(TData data)
        {
            Data = data;
        } 
        public TData Data { get; }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>(data);
        }
    }
}
