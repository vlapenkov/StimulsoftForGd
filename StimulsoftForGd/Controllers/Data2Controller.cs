using Microsoft.AspNetCore.Mvc;
using Stimulsoft.System.Windows;
using StimulsoftForGd.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StimulsoftForGd.Controllers
{
    public class Data2Controller : Controller
    {

        public async Task<IEnumerable<PointDto>> Index()
        {

            return new[] { new PointDto {Value1=1500,Value2=2000, Value3 = 2500,SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture) },
            new PointDto {Value1=2500,Value2=2300, Value3 = 1500,SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture) },
            new PointDto {Value1=3500,Value2=2400, Value3 = 3500,SDate=DateTime.ParseExact("2020-03-01","yyyy-MM-dd",CultureInfo.InvariantCulture) },
            new PointDto {Value1=4500,Value2=2700, Value3 = 1800,SDate=DateTime.ParseExact("2020-04-01","yyyy-MM-dd",CultureInfo.InvariantCulture) },
            new PointDto {Value1=5000,Value2=1100, Value3 = 4200,SDate=DateTime.ParseExact("2020-05-01","yyyy-MM-dd",CultureInfo.InvariantCulture) }
            };
        }

        public async Task<PointsWithRegions> Index2()
        {

          //  var contractTypes = new[] { new ContractType { Id=1,Name="Купля-продажа"},
          //new ContractType { Id=2,Name="Компенсация потерь"},
          //new ContractType { Id=3,Name="Оказание услуг по передаче"},
          //new ContractType { Id=4,Name="Энергоснабжение"},
          //};

            var regions = new[] { new Region { Id=1,Name="Архангельская область"},
          new Region { Id=2,Name="Московская область"},
          new Region { Id=3,Name="Омская область"},
          new Region { Id=4,Name="Ярославская область"},
          };

          var points = new[] { 
            new PointExtended {
                Value1=1500,
                Value2=2000, 
                Value3 = 2500,
                RegionId =1,
               // ContractType = contractTypes[0],// Region = regions[0],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture) 
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 2500,
                RegionId =2,
             //   ContractType = contractTypes[0],// Region = regions[1],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 1500,
                RegionId =3,
              //  ContractType = contractTypes[0], //Region = regions[2],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=3000,
                Value2=2000,
                Value3 = 1500,
                RegionId =4,
              //  ContractType = contractTypes[0],// Region = regions[3],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            // 2020-02-01
            new PointExtended {
                Value1=1500,
                Value2=2000,
                Value3 = 2500,
                RegionId =1,
             //   ContractType = contractTypes[0],// Region = regions[0],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 2500,
                RegionId =2,
              //  ContractType = contractTypes[0],// Region = regions[1],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 1500,
                RegionId =3,
              //  ContractType = contractTypes[0],// Region = regions[2],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=3000,
                Value2=2000,
                Value3 = 1500,
                RegionId =4,
              //  ContractType = contractTypes[0],// Region = regions[3],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            // 2020-03-01
            new PointExtended {
                Value1=1500,
                Value2=2000,
                Value3 = 2500,
                RegionId =1,
             //   ContractType = contractTypes[0],// Region = regions[0],
                SDate=DateTime.ParseExact("2020-03-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 2500,
                RegionId =2,
              //  ContractType = contractTypes[0], //Region = regions[1],
                SDate=DateTime.ParseExact("2020-03-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 1500,
                RegionId =3,
              //  ContractType = contractTypes[0],// Region = regions[2],
                SDate=DateTime.ParseExact("2020-03-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=3000,
                Value2=2000,
                Value3 = 1500,
                RegionId =4,
              //  ContractType = contractTypes[0],// Region = regions[3],
                SDate=DateTime.ParseExact("2020-03-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            // 2020-04-01
            new PointExtended {
                Value1=1500,
                Value2=2000,
                Value3 = 2500,
                RegionId =1,
            //    ContractType = contractTypes[0],// Region = regions[0],
                SDate=DateTime.ParseExact("2020-04-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 2500,
                RegionId =2,
             //   ContractType = contractTypes[0],// Region = regions[1],
                SDate=DateTime.ParseExact("2020-04-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=1000,
                Value2=2000,
                Value3 = 1500,
                RegionId =3,
             //   ContractType = contractTypes[0],// Region = regions[2],
                SDate=DateTime.ParseExact("2020-04-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointExtended {
                Value1=3000,
                Value2=2000,
                Value3 = 1500,
                RegionId =4,
             //   ContractType = contractTypes[0],// Region = regions[3],
                SDate=DateTime.ParseExact("2020-04-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
           
            };

            return new PointsWithRegions { 
            Points = points,
            Regions = regions
            };

        }

        public async Task<IEnumerable<PointAndRegion>> Index3()
        {

            var regions = new[] { new Region { Id=1,Name="Архангельская область"},
          new Region { Id=2,Name="Московская область"},
          new Region { Id=3,Name="Омская область"},
          new Region { Id=4,Name="Ярославская область"},
          };

            var points = new[] {
            new PointAndRegion {
                Value1=1500,
                Value2=2000,
                Value3 = 2500,
                Region =regions[0],
               // ContractType = contractTypes[0],// Region = regions[0],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointAndRegion {
                Value1=1000,
                Value2=2000,
                Value3 = 2500,
                Region =regions[0],
             //   ContractType = contractTypes[0],// Region = regions[1],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointAndRegion {
                Value1=1000,
                Value2=2000,
                Value3 = 1500,
                 Region =regions[0],
              //  ContractType = contractTypes[0], //Region = regions[2],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointAndRegion {
                Value1=3000,
                Value2=2000,
                Value3 = 1500,
                Region =regions[0],
              //  ContractType = contractTypes[0],// Region = regions[3],
                SDate=DateTime.ParseExact("2020-01-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            // 2020-02-01
            new PointAndRegion {
                Value1=1500,
                Value2=2000,
                Value3 = 2500,
               Region =regions[1],
             //   ContractType = contractTypes[0],// Region = regions[0],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointAndRegion {
                Value1=1000,
                Value2=2000,
                Value3 = 2500,
                 Region =regions[1],
              //  ContractType = contractTypes[0],// Region = regions[1],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointAndRegion {
                Value1=1000,
                Value2=2000,
                Value3 = 1500,
               Region =regions[1],
              //  ContractType = contractTypes[0],// Region = regions[2],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            },
            new PointAndRegion {
                Value1=3000,
                Value2=2000,
                Value3 = 1500,
                Region =regions[1],
              //  ContractType = contractTypes[0],// Region = regions[3],
                SDate=DateTime.ParseExact("2020-02-01","yyyy-MM-dd",CultureInfo.InvariantCulture)
            } };

            return points;
            

        }
    }
}
