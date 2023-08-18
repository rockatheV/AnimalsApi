using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Order
{
    public class OrderResult
    {
        public Guid Id { get; set; }
        public double MontoTotal { get; set; }
    }
}
