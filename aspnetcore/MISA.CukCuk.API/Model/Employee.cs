namespace MISA.CukCuk.API.Model
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? FullName { get; set; }
        public int? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? IdentityNumber { get; set; }
        public string? IdentityPlace { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PersonalTaxCode { get; set; }
        public Guid? PositionId { get; set; }
        public DateTime? JoinDate { get; set; }
        public Guid? DepartmentId { get; set; }
        public int? WorkStatus { get; set; }
        public decimal? Salary { get; set; }
        public string? GenderName 
        {
            get
            {
                switch(Gender)
                {
                    case 0: return "Nữ";
                    case 1: return "Nam";
                    default: return "Không xác định";
                }
            }
        }
        public string? WorkStatusName
        {
            get
            {
                switch (WorkStatus)
                {
                    case 0: return "đang nghỉ việc";
                    case 1: return "đang làm việc";
                    case 2: return "đang thử việc";
                    default: return "Không xác định";
                }
            }
        }

    }
}
