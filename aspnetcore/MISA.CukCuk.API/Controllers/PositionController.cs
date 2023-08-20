using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.API.Model;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        // GET: api/<PositionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PositionController>/5
        [HttpGet("{positionId}")]
        public IActionResult Get(string positionId)
        {
            try
            {
                //Khai báo thông tin database
                var connectionString = "Host=localhost; Port=3306; Database=misa.cukcuk.demo; User Id=root; Password=1234";
                //Khởi tạo kết nối với MySqlDB
                var sqlConnection = new MySqlConnection(connectionString);
                //Lấy dữ liệu
                var sqlCommand = $"SELECT * FROM position WHERE PositionId = @PositionId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PositionId", positionId);
                var position = sqlConnection.QueryFirstOrDefault<object>(sql: sqlCommand, param: parameters);
                //Trả kết quả cho Client
                return Ok(position);
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

        // POST api/<PositionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
