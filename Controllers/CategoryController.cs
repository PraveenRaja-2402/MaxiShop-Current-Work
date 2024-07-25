
using Maxishop.Infrastructure.DbContexts;
using Maxishop1.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaxiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private object dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public object Create([FromBody]Category category)
        {
           _dbContext.Category.Add(category);
           _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("Details")]
        public ActionResult Get(int id)
        {
            var category = _dbContext.Category.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        [HttpGet]
        public ActionResult Get()
        {
            var categories = _dbContext.Category.ToList();
            return Ok(categories);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Category category)
        {
            _dbContext.Category.Update(category);
            _dbContext.SaveChanges();
            return Ok();
        }

       

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var category = _dbContext.Category.FirstOrDefault(x => x.Id ==id);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Category.Remove(category);
            _dbContext.SaveChanges();
            return NoContent();
        }
        


    }
}
