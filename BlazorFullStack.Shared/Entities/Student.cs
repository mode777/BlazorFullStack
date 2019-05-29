using System;
using System.Collections.Generic;
using System.Text;
using BlazorFullStack.Shared.Framework;

namespace BlazorFullStack.Shared.Entities
{
    public class Student : HasIdentity<Student>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
}
