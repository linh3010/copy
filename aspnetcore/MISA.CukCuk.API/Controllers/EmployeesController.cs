using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using MISA.CukCuk.API.Model;
using MySqlX.XDevAPI.Relational;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Khai báo thông tin database
                var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
                //Khởi tạo kết nối với MySqlDB
                var sqlConnection = new MySqlConnection(connectionString);
                //Lấy dữ liệu
                var sqlCommand = "SELECT * FROM employee";
                var employees = sqlConnection.Query<Employee>(sql: sqlCommand);
                //Trả kết quả cho Client
                return Ok(employees);
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = Resources.ResourceVN.Error_Exception;
                error.Data = ex.Data;
                return StatusCode(500, error);
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{employeeId}")]
        public IActionResult Get(string employeeId)
        {
            try
            {
                //Khai báo thông tin database
                var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
                //Khởi tạo kết nối với MySqlDB
                var sqlConnection = new MySqlConnection(connectionString);
                //Lấy dữ liệu
                var sqlCommand = $"SELECT * FROM employee WHERE EmployeeId = @EmployeeId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                var employee = sqlConnection.QueryFirstOrDefault<Employee>(sql: sqlCommand, param: parameters);
                //Trả kết quả cho Client
                return Ok(employee);
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = Resources.ResourceVN.Error_Exception;
                error.Data = ex.Data;
                return StatusCode(500, error);
            }
        }

        [HttpGet("search/{fullName}")]
        public IActionResult Search(string fullName)
        {
            try
            {
                //Khai báo thông tin database
                var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
                //Khởi tạo kết nối với MySqlDB
                var sqlConnection = new MySqlConnection(connectionString);
                //Lấy dữ liệu
                var sqlCommand = "SELECT * FROM employee WHERE FullName = @FullName";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FullName", fullName);
                var employee = sqlConnection.Query<Employee>(sql: sqlCommand, param: parameters);
                Console.WriteLine(parameters);
                //Trả kết quả cho Client
                return Ok(employee);
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = Resources.ResourceVN.Error_Exception;
                error.Data = ex.Data;
                return StatusCode(500, error);
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeId()
        {
            try
            {
                //Khởi tạo mã id mới
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                int length = random.Next(15);
                string NewEmployeeCode = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
                //Trả kết quả cho Client
                return Ok(NewEmployeeCode);
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = Resources.ResourceVN.Error_Exception;
                error.Data = ex.Data;
                return StatusCode(500, error);
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            //Validate dữ liệu
            if (DataValidate(employee) != null)
            {
                return BadRequest(DataValidate(employee));
            }
            if (!CheckEmployeeCode(employee.EmployeeCode))
            {
                return BadRequest(Resources.ResourceVN.Error_UniqueEmployeeCode);
            }
            try
            {
                //Khai báo thông tin database
                var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
                //Khởi tạo kết nối với MySqlDB
                var sqlConnection = new MySqlConnection(connectionString);
                //Lưu dữ liệu
                var sqlCommand = "INSERT INTO employee (EmployeeId, EmployeeCode, FullName, DateOfBirth, Gender, IdentityNumber, IdentityDate, IdentityPlace, Email, PhoneNumber, PersonalTaxCode, Salary, JoinDate, WorkStatus, PositionId, DepartmentId, CreatedDate, CreatedBy, ModifileDate, ModifileBy)" +
                    "VALUES (UUID(), @EmployeeCode, @FullName, @DateOfBirth, @Gender, @IdentityNumber, @IdentityDate, @IdentityPlace, @Email, @PhoneNumber, @PersonalTaxCode, @Salary, @JoinDate, @WorkStatus, @PositionId, DepartmentId, NOW(), 'me', NOW(), 'me');";
                var res = sqlConnection.Execute(sql: sqlCommand, param: employee);
                if (res > 0)
                {
                    return StatusCode(201,res);
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = Resources.ResourceVN.Error_Exception;
                error.Data = ex.Data;
                return StatusCode(500, error);
            }
            
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{employeeId}")]
        public IActionResult Put(Employee employee, string employeeId)
        {
            if (DataValidate(employee) != null)
            {
                return BadRequest(DataValidate(employee));
            }
            try
            {
                //Validate dữ liệu
                //Khai báo thông tin database
                var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
                //Khởi tạo kết nối với MySqlDB
                var sqlConnection = new MySqlConnection(connectionString);
                //Lưu dữ liệu
                var sqlCommand = "UPDATE employee e\r\n" +
                                 "SET\r\n" +
                                 "e.EmployeeCode = @EmployeeCode,\r\n" +
                                 "e.FullName = @FullName,\r\n" +
                                 "e.DateOfBirth = @DateOfBirth,\r\n" +
                                 "e.Gender = @Gender,\r\n" +
                                 "e.IdentityNumber = @IdentityNumber,\r\n" +
                                 "e.IdentityDate = @IdentityDate,\r\n" +
                                 "e.IdentityPlace = @IdentityPlace,\r\n" +
                                 "e.Email = @Email,\r\n" +
                                 "e.PhoneNumber = @PhoneNumber,\r\n" +
                                 "e.PersonalTaxCode = @PersonalTaxCode,\r\n" +
                                 "e.Salary = @Salary,\r\n" +
                                 "e.JoinDate = @JoinDate,\r\n" +
                                 "e.WorkStatus = @WorkStatus,\r\n" +
                                 "e.PositionId = @PositionId,\r\n" +
                                 "e.DepartmentId = @DepartmentId\r\n" +
                                 "WHERE EmployeeId = @EmployeeId;";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                parameters.Add("@EmployeeCode", employee.EmployeeCode);
                parameters.Add("@FullName", employee.FullName);
                parameters.Add("@DateOfBirth", employee.DateOfBirth);
                parameters.Add("@Gender", employee.Gender);
                parameters.Add("@IdentityNumber", employee.IdentityNumber);
                parameters.Add("@IdentityDate", employee.IdentityDate);
                parameters.Add("@IdentityPlace", employee.IdentityPlace);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@PersonalTaxCode", employee.PersonalTaxCode);
                parameters.Add("@Salary", employee.Salary);
                parameters.Add("@JoinDate", employee.JoinDate);
                parameters.Add("@WorkStatus", employee.WorkStatus);
                parameters.Add("@PositionId", employee.PositionId);
                parameters.Add("@DepartmentId", employee.DepartmentId);
                var res = sqlConnection.Execute(sql: sqlCommand, param: parameters);
                
                if (res > 0)
                {
                    return StatusCode(201, res);
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = Resources.ResourceVN.Error_Exception;
                error.Data = ex.Data;
                return StatusCode(500, error);
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(string employeeId)
        {
            try
            {
                //Khai báo thông tin database
                var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
                //Khởi tạo kết nối với MySqlDB
                var sqlConnection = new MySqlConnection(connectionString);
                //Lưu dữ liệu
                var sqlCommand = "DELETE FROM employee WHERE EmployeeId = @EmployeeId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                var res = sqlConnection.Execute(sql: sqlCommand, param: parameters);

                if (res > 0)
                {
                    return StatusCode(201, res);
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = Resources.ResourceVN.Error_Exception;
                error.Data = ex.Data;
                return StatusCode(500, error);
            }
        }
        /// <summary>
        /// Kiểm tra dữ liệu đầu vào
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private ErrorService DataValidate(Employee employee)
        {
            //Validate dữ liệu
            var error = new ErrorService();
            var errorData = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                errorData.Add("EmployeeCode", Resources.ResourceVN.Error_ValidateDataEmployeeCode);
            }
            if (string.IsNullOrEmpty(employee.FullName))
            {
                errorData.Add("FullName", Resources.ResourceVN.Error_ValidateDataFullName);
            }
            if (employee.Email != null && !IsValidEmail(email: employee.Email))
            {
                errorData.Add("Email", Resources.ResourceVN.Error_ValidateDataEmail);
            }
            if (string.IsNullOrEmpty(employee.PhoneNumber))
            {
                errorData.Add("PhoneNumber", Resources.ResourceVN.Error_ValidateDataPhoneNumber);
            }
            if (string.IsNullOrEmpty(employee.IdentityNumber))
            {
                errorData.Add("IdentityNumber", Resources.ResourceVN.Error_ValidateDataIdentityNumber);
            }
            if (employee.DateOfBirth != null && employee.DateOfBirth > DateTime.Now)
            {
                errorData.Add("DateOfBirth", Resources.ResourceVN.Error_ValidateDataDateOfBirth);
            }
            if (employee.IdentityDate != null && employee.IdentityDate > DateTime.Now)
            {
                errorData.Add("IdentityDate", Resources.ResourceVN.Error_ValidateDataIdentityDate);
            }
            if (employee.JoinDate != null && employee.JoinDate > DateTime.Now)
            {
                errorData.Add("JoinDate", Resources.ResourceVN.Error_ValidateDataJoinDate);
            }
            if (errorData.Count > 0)
            {
                error.userMsg = Resources.ResourceVN.Error_ValidateData;
                error.Data = errorData;
                return error;
            }
            return null;
        }

        /// <summary>
        /// Kiểm tra mã nhân viên có bị trùng hay ko
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        private bool CheckEmployeeCode(string employeeCode)
        {
            //Khai báo thông tin database
            var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
            //Khởi tạo kết nối với MySqlDB
            var sqlConnection = new MySqlConnection(connectionString);
            var sqlCheck = "SELECT EmployeeCode FROM employee WHERE EmployeeCode = @EmployeeCode";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("@EmployeeCode", employeeCode);
            var res = sqlConnection.QueryFirstOrDefault<string>(sqlCheck, param: dynamicParams);
            if(res == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra email có bị sai định dạng hay không
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
