using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStack.Shared.Framework
{
    public abstract class Query<TEntity, TParameters>
    {
        public abstract Task<TEntity> ExecuteAsync(TParameters parameters)
        {

        }
    }
}
