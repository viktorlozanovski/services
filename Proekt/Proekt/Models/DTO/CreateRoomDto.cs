using System.ComponentModel.DataAnnotations;

namespace Proekt.Models.DTO
{
    public class CreateRoomDto
    {
    
        public int Number { get; set; }
    
        public int Floor { get; set; }
       
        public string Type { get; set; }
    }
}
