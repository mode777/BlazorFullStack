using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorFullStack.Shared.Framework
{
    public class HasIdentity<TEntity>
    {
        public Guid Id { get; set; }
    }
}
