using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data.DbModels;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UsersController : ControllerBase
    {
        private VegaVestaNewContext _context;
        public UsersController(VegaVestaNewContext context)
        {
            _context = context;
        }


        [HttpGet("GetVegaBrandById")]
        public async Task<VegaBrand> GetVegaBrandById(int id)
        {
            var item = await _context.VegaBrands.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }

        [HttpGet("GetAllData")]
        public int GetAll()
        {
            return 333;
        }


        [HttpPost("PostAllData")]
        public ResponseModel PostAll(TestModel testModel)
        {
            ResponseModel responseModel = new ResponseModel();
            responseModel.Id = testModel.Name1 + 100;
            responseModel.Name = testModel.Name2 + "testing";
            responseModel.Description = testModel.Name2 + "testing description";
            return responseModel;
        }

        [HttpDelete("DeleteData")]
        public ResponseDeleteModel DeleteData(int deleteValue)
        {
            ResponseDeleteModel responseDeleteModel = new ResponseDeleteModel();
            responseDeleteModel.Delete(deleteValue);
            return responseDeleteModel;
        }

    }
}
