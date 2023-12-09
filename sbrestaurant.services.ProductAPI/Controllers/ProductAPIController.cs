using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sbrestaurant.services.ProductAPI.Data;
using sbrestaurant.services.ProductAPI.Models;
using sbrestaurant.services.ProductAPI.Models.Dto;
using sbrestaurant.services.ProductAPI.Models.Dto.newRest;

namespace sbrestaurant.services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
  //  [Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
     
        private readonly ResponseDtouu _response;
        private readonly IMapper _mapper;

        public ProductAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDtouu();
        }

        [HttpGet]
       
        public ResponseDtouu Get()
        {
            try
            {
                IEnumerable<Product> objList = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
              
            }
            catch (Exception ex)
            {
               // _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
             return _response;
           
        }


        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Product obj = _db.Products.First(u => u.ProductId == id);
              
                  _response.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }


   

        [HttpPost]
       // [Authorize(Roles ="ADMIN")]
        public ResponseDtouu Post([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);
                _db.Products.Add(obj);   
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductDto>(ProductDto); 
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
     //   [Authorize(Roles = "ADMIN")]
        public ResponseDtouu put([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);
                _db.Products.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductDto>(ProductDto);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
      //  [Authorize(Roles = "ADMIN")]
        public ResponseDtouu Delete(int id)
        {
            try
            {
                Product obj = _db.Products.First(u=> u.ProductId== id);    
                _db.Products.Remove(obj);
                _db.SaveChanges();

               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
