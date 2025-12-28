using System;
using ADOwebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using ADOwebAPI.Models;

namespace ADOwebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:ControllerBase
    {
        public readonly EmployeeRepository obj;

        public EmployeeController(EmployeeRepository _obj)
        {
            obj = _obj;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> lists = obj.GetEmps();
            if (lists == null) return NotFound();
            return Ok(lists);

        }
    }
}
