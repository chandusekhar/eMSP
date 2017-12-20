using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{
    public class VacancyModel
    {
        public VacancyModel() { }
        public long id { get; set; }
        public long customerId { get; set; }
        public string customerName { get; set; }
    }

    public class VacancyCreateModel : VacancyModel
    {
        public VacancyCreateModel() { }
        public short vacancyType { get; set; }
        public string vacancyTypeName { get; set; }
        public System.DateTime startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<System.DateTime> submissionDueDate { get; set; }
        public string hiringManager { get; set; }
        public string reportingManager { get; set; }
        public string positionTitle { get; set; }
        public string vacancyDescription { get; set; }
        public decimal yearOfExperience { get; set; }
        public Nullable<bool> showCustomerDetailsToSupplier { get; set; }
        public decimal minPayRate { get; set; }
        public decimal maxPayRate { get; set; }
        public decimal targetPayRate { get; set; }
        public decimal payRateMarkUp { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public System.DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<System.DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
