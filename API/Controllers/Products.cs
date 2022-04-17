using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class Products : ControllerBase
{
    private readonly StoreContext _context;


    public Products(StoreContext context )
    {
        _context = context;
    }

    [HttpGet]
    // [Route("getproducts")]
    public async Task<IActionResult> GetProducts()
    {
        return  Ok(await _context.Products.ToListAsync());
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        return Ok(await _context.Products.FindAsync(id) );
    }
}