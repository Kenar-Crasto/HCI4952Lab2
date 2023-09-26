using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityApp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CommunityApp.Data
{
    public static class SeedData {
    // this is an extension method to the ModelBuilder class
    public static void Seed(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<Province>().HasData(
            GetProvinces()
        );
        modelBuilder.Entity<City>().HasData(
            GetCities()
        );
    }
    public static List<Province> GetProvinces(){
        List<Province> provinces = new List<Province>(){
        new Province(){ // 1
            ProvinceCode="BC",
            ProvinceName="British Columbia"
        },
        new Province(){ // 2
            ProvinceCode="AB",
            ProvinceName="Alberta"
        },
        new Province(){ // 3
            ProvinceCode="ON",
            ProvinceName="Ontario"
        },

    };
    return provinces;
    }
    public static List<City> GetCities(){
        List<City> cities = new List<City>(){
            new City(){
                CityId=1,
                CityName="Victoria",
                Population=7,
                ProvinceCode="BC"
            },
            new City(){
                CityId=2,
                CityName="Surrey",
                Population=10000000,
                ProvinceCode="BC"
            },
            new City(){
                CityId=3,
                CityName="Toronto",
                Population=99999999,
                ProvinceCode="ON"
            },
            new City(){
                CityId=4,
                CityName="Calgary",
                Population=4,
                ProvinceCode="AB"
            },
        };
        return cities;
    }
}
}