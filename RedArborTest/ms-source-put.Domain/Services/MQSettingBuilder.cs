using ms_source_put.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_source_put.Domain.Services
{
    public class MQSettingBuilder
    {
        public static MQSettings Build()
        {
            return new MQSettings
            {
                Host = "localhost",
                Port = 5672,
                Password = "guest",
                UserName = "guest"
            };
        }
    }
}
