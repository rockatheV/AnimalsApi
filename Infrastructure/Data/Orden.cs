using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Orden
    {
        public double Total { get; set; }
        public Guid Id { get; set; }
    }
}
