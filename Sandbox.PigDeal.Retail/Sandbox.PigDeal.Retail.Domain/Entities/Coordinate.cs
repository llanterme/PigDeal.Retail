using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox.PigDeal.Domain.Entities
{
    public class Coordinate
    {
        public Coordinate()
        {
            Latitude = 0;
            Longitude = 0;
        }

        public float Longitude { get; set; }

        public float Latitude { get; set; }
    }
}
