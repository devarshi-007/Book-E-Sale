using BookStoreModels.NewFolder;
using BookStoreModels.ViewModels;
using BookStoreRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        RoleRepository _roleRepository = new RoleRepository();
        [Route("~/api/User/Roles")]
        [HttpGet]
        public IActionResult Roles()
        {
            var roles = _roleRepository.Roles();
            ListResponse<RoleModel> listResponse = new()
            {
                Results = roles.Results.Select(c => new RoleModel(c)),
                TotalRecords = roles.TotalRecords,
            };
            return Ok(listResponse);
        }

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(ListResponse<RoleModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetRoles(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var roles = _roleRepository.GetRoles(pageIndex, pageSize, keyword);
            ListResponse<RoleModel> listResponse = new ListResponse<RoleModel>()
            {
                Results = roles.Results.Select(c => new RoleModel(c)),
                TotalRecords = roles.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(RoleModel), (int)HttpStatusCode.OK)]
        public IActionResult GetPublisher(int id)
        {
            var role = _roleRepository.GetRole(id);
            RoleModel roleModel = new RoleModel(role);

            return Ok(roleModel);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(RoleModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddRole(RoleModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _roleRepository.AddRole(role);
            RoleModel roleModel = new RoleModel(response);

            return Ok(roleModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(RoleModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateRole(RoleModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name
            };

            var response = _roleRepository.UpdateRole(role);
            RoleModel roleModel = new RoleModel(response);

            return Ok(roleModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteRole(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _roleRepository.DeleteRole(id);
            return Ok(response);
        }

    }
}
