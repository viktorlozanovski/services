using System.ComponentModel.DataAnnotations;

namespace Proekt.Models.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
    
        public int Number { get; set; }
    
        public int Floor { get; set; }
       
        public string Type { get; set; }
    }
}
