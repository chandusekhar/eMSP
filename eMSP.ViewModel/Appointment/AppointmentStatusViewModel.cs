using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Appointment
{
   public partial class AppointmentStatusViewModel:BaseModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
