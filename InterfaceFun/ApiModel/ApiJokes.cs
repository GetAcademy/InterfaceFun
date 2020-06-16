using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace InterfaceFun.ApiModel
{
    public class ApiJokes
    {
        public int total { get; set; }
        public List<ApiJoke> result { get; set; }
    }
}
