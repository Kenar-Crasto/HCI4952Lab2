using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityApp.Models
{
    public class Province
    {
        [Key]
        public string? ProvinceCode {get;set;}
        public string? ProvinceName{get;set;}
        [InverseProperty("Province")]
        public List<City>? Cities{get;set;}

        
    }
}