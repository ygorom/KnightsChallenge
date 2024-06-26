using Infra;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KnightsController(IKnightsService knightsService) : ControllerBase
    {
        private readonly IKnightsService _service = knightsService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromQuery] string filter = "")
        {
            try
            {
                var knights = await _service.GetAll(filter) ?? [];

                if (!knights.Any())
                    return NoContent();

                return Ok(knights);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var knight = await _service.GetById(id) ?? null;

                if (knight is null)
                    return NoContent();

                return Ok(knight);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateKnightRequest request)
        {
            try
            {
                if (ModelState.IsValid is false)
                    return BadRequest(ModelState);

                await _service.Create(request);

                return Created(string.Empty, request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] UpdateKnightRequest request)
        {
            try
            {
                if (ModelState.IsValid is false)
                    return BadRequest(ModelState);

                await _service.Update(id, request);
                return Ok("Nickname atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var result = await _service.Inactivate(id);

                if (result is false)
                    return BadRequest();

                return Ok("Knight has been deactivated.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}