﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dto
{
    public class SpaceShipDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        public DateTime? BuiltDate { get; set; }
        public int? Crew { get; set; }
        public int? EnginePower { get; set; }
        public int? Passengers { get; set; }
        public int? InnerVolume { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public SpaceShipDto() 
        {
            Id = Guid.NewGuid();
        }
    }
}
