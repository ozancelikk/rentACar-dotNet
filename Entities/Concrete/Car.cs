using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete {
    public class Car : IEntity {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public string ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
            
    }
}
