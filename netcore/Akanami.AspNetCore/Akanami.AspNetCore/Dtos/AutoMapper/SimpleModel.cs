using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Akanami.AspNetCore.Dtos.AutoMapper
{
    public class SimpleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public DateTime BirthDay { get; set; }
    }


    public class SimpleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public DateTime? BIRTHDAY { get; set; }

        //[JsonProperty("birthday1")]
        //[DataMember(Name = "birthday1")]
        //public DateTime BirthDay { get; set; }
    }
}
