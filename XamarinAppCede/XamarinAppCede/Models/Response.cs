using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppCede.Models
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
    }
}
