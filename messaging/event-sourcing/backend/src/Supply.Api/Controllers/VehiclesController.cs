using Microsoft.AspNetCore.Mvc;
using Supply.Application.DTOs.VehicleDTOs;
using Supply.Application.Interfaces;
using Supply.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supply.Api.Controllers
{
    public class VehiclesController : ApiController
    {
        private readonly IVehicleAppService _vehicleAppService;

        public VehiclesController(IVehicleAppService vehicleAppService)
        {
            _vehicleAppService = vehicleAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleDTO>> Get()
        {
            return await _vehicleAppService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<VehicleDTO> Get(Guid id)
        {
            return await _vehicleAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddVehicleDTO addVehicleDTO)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _vehicleAppService.Add(addVehicleDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleDTO updateVehicleDTO)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _vehicleAppService.Update(updateVehicleDTO));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _vehicleAppService.Remove(id));
        }

        [HttpGet("history/{id:guid}")]
        public async Task<IEnumerable<StoredEvent>> GetHistory(Guid id)
        {
            return await _vehicleAppService.GetHistory(id);
        }
    }
}
