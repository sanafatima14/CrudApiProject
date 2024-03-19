//using Azure;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using System.Data;
//using CrudApiProject.Data;



//namespace CrudApiProject.Controllers
//{
//    [Route("api/demo")]
//    [ApiController]
//    [Authorize]
//    public class api_controller : ControllerBase
//    {
//        private readonly api_demo_db_class _apiDemoDbClass;
//        public readonly IConfiguration _configuration;


//        public api_controller(api_demo_db_class apiDemoDbClass, IConfiguration configuration)
//        {
//            _apiDemoDbClass = apiDemoDbClass;
//            _configuration = configuration;
//        }
//        [HttpGet]

//        [Route("get-users-list")]
//        public async Task<IActionResult> GetAllUsers()
//        {
//            var users = await _apiDemoDbClass.users.ToListAsync();
//            return Ok(users);
//        }
//        [HttpGet]

//        [Route("get-users-by-id/{UserId}")]
//        public async Task<IActionResult> GetUserById(int UserId)
//        {
//            var user = await _apiDemoDbClass.users.FindAsync(UserId);
//            return Ok(user);
//        }


//        [HttpPost]

//        [Route("create-user")]
//        [Authorize(Roles = "Admin")]
//        public users CreateUser(users user)
//        {
//            var u = _apiDemoDbClass.users.Add(user);
//            _apiDemoDbClass.SaveChanges();
//            return u.Entity;

//        }
//        [HttpPut]

//        [Route("update-user")]
//        [Authorize(Roles = "Admin")]
//        public async Task<IActionResult> UpdateUser(users userToUpdate)
//        {
//            _apiDemoDbClass.users.Update(userToUpdate);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return NoContent();
//        }
//        [HttpDelete]
//        [Route("delete-user")]
//        public async Task<IActionResult> DeleteUser(int UserId)
//        {
//            var userToDelete = await _apiDemoDbClass.users.FindAsync(UserId);
//            if (userToDelete == null) { return NotFound(); }
//            _apiDemoDbClass.Remove(userToDelete);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return NoContent();

//        }
//        //[HttpGet]
//        //[Route("get-products-list")]
//        //public async Task<IActionResult> GetProductsAsync()
//        //{
//        //    var product = await _apiDemoDbClass.products.ToListAsync();
//        //    return Ok(product);
//        //}

//        //[HttpGet]
//        //[Route("get-product-by-id/{ProductId}")]
//        //public async Task<IActionResult> GetProductsByIdAsync(int ProductId)
//        //{
//        //    var product = await _apiDemoDbClass.products.FindAsync(ProductId);
//        //    return Ok(product);

//        //}
//        //[HttpPost]
//        //[Authorize(Roles = "Admin")]
//        //[Route("create-product")]
//        //public async Task<IActionResult> PostProductAsync(products product)
//        //{
//        //    _apiDemoDbClass.products.Add(product);
//        //    await _apiDemoDbClass.SaveChangesAsync();
//        //    return Created($"/get-product-by-id/{product.id}", product);
//        //}

//        //[HttpPut]
//        //[Authorize(Roles = "Admin")]
//        //[Route("update-product")]
//        //public async Task<IActionResult> PutProductAsync(products productToUpdate)
//        //{
//        //    _apiDemoDbClass.products.Update(productToUpdate);
//        //    await _apiDemoDbClass.SaveChangesAsync();
//        //    return NoContent();
//        //}
//        //[HttpDelete]
//        //[Route("delete-product")]
//        //public async Task<IActionResult> DeleteProductAsync(int ProductId)
//        //{
//        //    var productToDelete = await _apiDemoDbClass.products.FindAsync(ProductId);
//        //    if (productToDelete == null) { return NotFound(); }
//        //    _apiDemoDbClass.Remove(productToDelete);
//        //    await _apiDemoDbClass.SaveChangesAsync();
//        //    return NoContent();

//        //}


//        [HttpGet]
//        [Route("get-orders-list")]
//        public async Task<IActionResult> GetOrdersAsync()
//        {
//            var orders = await _apiDemoDbClass.orders.ToListAsync();
//            return Ok(orders);
//        }

//        [HttpGet]
//        [Route("get-order-by-id/{OrderId}")]
//        public async Task<IActionResult> GetOrdersByIdAsync(int OrderId)
//        {
//            var order = await _apiDemoDbClass.products.FindAsync(OrderId);
//            return Ok(order);

//        }
//        /// validate 
//        [HttpPost]
//        [Authorize(Roles = "Admin")]
//        [Route("create-order")]
//        public async Task<IActionResult> PostOrderAsync(orders order)

//        {

//            var blog1 = _apiDemoDbClass.users
//                            .Where(b => b.id == order.user_id)

//                            .FirstOrDefault();

//            //_apiDemoDbClass.Orders.Include( h => h.user);
//            //var b = _apiDemoDbClass.Orders.Include( a => a.user ).FirstOrDefault( a => a.user_id == order.user_id );
//            order.user = blog1; // Access the related book

//            _apiDemoDbClass.orders.Add(order);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return Created($"/order/{order.id}", order);


//        }

//        [HttpPut]
//        [Route("update-order")]
//        public async Task<IActionResult> PutOrderAsync(orders orderToUpdate)
//        {
//            _apiDemoDbClass.orders.Update(orderToUpdate);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return NoContent();
//        }

//        /// <summary>
//        [HttpPut]
//        [Authorize(Roles = "Admin")]
//        [Route("update-order/{orderid}/{status}")]
//        public async Task<IActionResult> PutOrderstatusAsync(int orderid, int status_id)
//        {
//            orders order = await _apiDemoDbClass.orders.FindAsync(orderid);

//           // order.status_id = status_id;

//            _apiDemoDbClass.orders.Update(order);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return Ok(order);
//        }


//        [HttpDelete]
//        [Route("delete-order")]
//        public async Task<IActionResult> DeleteOrderAsync(int OrderId)
//        {
//            var orderToDelete = await _apiDemoDbClass.orders.FindAsync(OrderId);
//            if (orderToDelete == null) { return NotFound(); }
//            _apiDemoDbClass.Remove(orderToDelete);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return NoContent();

//        }


//        /// <summary>
//        /// ///////////////////////
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("get-order_products-list")]
//        public async Task<IActionResult> GetOrderProductsAsync()
//        {
//            var orderproducts = await _apiDemoDbClass.order_products.ToListAsync();
//            return Ok(orderproducts);
//        }

//        [HttpGet]
//        [Route("get-order_products-by-id/{Order_id}/{Product_id}")]
//        public async Task<IActionResult> GetOrderProductsByIdAsync(int Order_id, int Product_id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var orderproducts = await _apiDemoDbClass.order_products.FindAsync(Order_id, Product_id);
//            return Ok(orderproducts);

//        }
//        [HttpPost]
//        [Route("create-order_products")]
//        [Authorize(Roles = "User")]
//        public async Task<IActionResult> PostOrderProductsAsync(order_products orderproducts)

//        {


//            var ord = _apiDemoDbClass.orders
//                            .Where(b => b.id == orderproducts.order_id)

//                            .FirstOrDefault();
//            var pro = _apiDemoDbClass.products
//                            .Where(b => b.id == orderproducts.product_id)

//                            .FirstOrDefault();

//            //_apiDemoDbClass.Orders.Include( h => h.user);
//            //var b = _apiDemoDbClass.Orders.Include( a => a.user ).FirstOrDefault( a => a.user_id == order.user_id );
//            orderproducts.order = ord;
//            orderproducts.product = pro;

//            _apiDemoDbClass.order_products.Add(orderproducts);

//            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
//            SqlDataAdapter adapter = new SqlDataAdapter("select available_quantity from products where products.id=" + orderproducts.product_id, con);
//            DataTable dt = new DataTable();
//            adapter.Fill(dt);
//            responses response = new Data.responses();
//            if (dt.Rows.Count > 0)


//            {
//                var x = dt.Rows[0].Field<int>("available_quantity");


//                if (dt.Rows[0].Field<int>("available_quantity") > orderproducts.product_quantity)
//                {
//                    _apiDemoDbClass.order_products.Add(orderproducts);
//                    await _apiDemoDbClass.SaveChangesAsync();
//                    return Created($"/orderProduct-by-id/{orderproducts.order_id}", orderproducts);
//                }
//            }
//            else
//            {
//                response.status_code = 100;
//                response.error_message = "No data found";

//            }
//            return BadRequest(response);








//            //_apiDemoDbClass.orderProducts.Add( order_products );
//            //await _apiDemoDbClass.SaveChangesAsync();
//            //return Created( $"/get-order_products-by-id/{order_products.Order_id} {order_products.Product_id}", order_products );
//        }

//        [HttpPut]
//        [Route("update-order_products")]
//        public async Task<IActionResult> PutOrderProductsAsync(order_products orderProductsToUpdate)
//        {
//            _apiDemoDbClass.order_products.Update(orderProductsToUpdate);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return NoContent();
//        }
//        [HttpDelete]
//        [Route("delete-order_products/{Order_id}/{Product_id}")]
//        public async Task<IActionResult> DeleteOrderProductsAsync(int Order_id, int Product_id)
//        {
//            var orderProductsToDelete = await _apiDemoDbClass.order_products.FindAsync(Order_id, Product_id);
//            if (orderProductsToDelete == null) { return NotFound(); }
//            _apiDemoDbClass.Remove(orderProductsToDelete);
//            await _apiDemoDbClass.SaveChangesAsync();
//            return NoContent();

//        }
//    }
//}
