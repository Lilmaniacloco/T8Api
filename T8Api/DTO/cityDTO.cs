using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T8Api.DTO
{
    public class CityDTO
    {
       
        public int Id { get; set; }

     
        public int Countryid { get; set; }

        public string Name { get; set; } = null!;

        
        public double Lat { get; set; }

    
        public double Lng { get; set; }

        public int Population { get; set; }

        public required string CounrtyName { get; set; }

    }
}
