using System;
using System.Threading.Tasks;
using DistCalc.DomainModel.Managers;
using DistCalc.WebApp.Models.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;

namespace DistCalc.WebApp.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(DistanceCalculationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ResponseCache(Duration = 10)] // two more ways to reduce loading: 1. Use in memory caching. 2. Use history storage (for example DB)
        public async Task<IActionResult> GetDistance(
            [FromServices] ICalculationManager manager, 
            [FromQuery] string iata1,
            [FromQuery] string iata2)
        {
            if (string.IsNullOrEmpty(iata1))
            {
                return BadRequest(new ErrorModel($"Missing value of parameter iata1"));
            }

            if (string.IsNullOrEmpty(iata1))
            {
                return BadRequest(new ErrorModel($"Missing value of parameter iata2"));
            }

            ICalculationResult result;
            try
            {
                result = await manager.GetDistance(iata1, iata2);
            }
            catch (BrokenCircuitException)
            {
                // log
                // handle broken circuit

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel($@"Remote service unavailable. Please check state by url:{Request.Scheme}://{Request.Host}/hc"));
            }
            catch (Exception)
            {
                // log

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel($@"Please check state by url:{Request.Scheme}://{Request.Host}/hc"));
            }

            if (result.AirportDetails1 == null)
            {
                return NotFound(new ErrorModel(
                    $"Airport by IATA code {result.RequestedIATA1} not found"));
            }

            if (result.AirportDetails2 == null)
            {
                return NotFound(new ErrorModel(
                    $"Airport by IATA code {result.RequestedIATA2} not found"));
            }
            
            var response = new DistanceCalculationModel(result, HttpContext.Request.GetDisplayUrl());

            return Ok(response);
        }
    }
}