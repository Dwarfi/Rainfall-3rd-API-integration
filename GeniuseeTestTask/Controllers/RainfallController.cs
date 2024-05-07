using System.ComponentModel.DataAnnotations;
using GeniuseeTestTask.Interfaces;
using GeniuseeTestTask.Models.Rainfall;
using Microsoft.AspNetCore.Mvc;

namespace GeniuseeTestTask.Controllers;

[ApiController]
[Route("/rainfall")]
[Produces("application/json")]
public class RainfallController(IRainfallService rainfallService) : ControllerBase
{
    /// <summary>
    /// Get rainfall readings by station Id
    /// </summary>
    /// <param name="stationId">Id of station</param>
    /// <param name="count">Count of latest readings returned</param>
    /// <response code="200">A list of rainfall readings successfully retrieved</response>
    /// <response code="400">Invalid request</response>
    /// <response code="404">No readings found for the specified stationId</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("id/{stationId}/readings")]
    public async Task<IActionResult> GetReadings([FromRoute] [MinLength(5)] string stationId,
        [FromQuery] [Range(1, 100)] int count = 10)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest("One or more parameters validation failed");

            var readings = await rainfallService.GetStationReadings(stationId, count);

            return readings.Any() ? Ok(readings) : NotFound("No readings found for the specified stationId");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}