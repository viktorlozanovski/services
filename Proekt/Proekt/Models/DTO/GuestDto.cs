﻿using System.ComponentModel.DataAnnotations;

namespace Proekt.Models.DTO
{
    public class GuestDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
       
        public int DOB { get; set; }
        
        public string Address { get; set; }
      
        public string Nationality { get; set; }
        
        public DateTime CheckInDate { get; set; }
        
        public DateTime CheckOutDate { get; set; }
    }
}
