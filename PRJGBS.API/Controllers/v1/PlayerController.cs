using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRJGBS.Data.Repository.IRepository;
using PRJGBS.Models;
using PRJGBS.Models.Dto;
using PRJGBS.Utility;
using System.Data;
using System.Net;

namespace PRJGBS.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/PlayerAPI")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PlayerController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IPlayerRepository _dbPlayer;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerRepository dbPlayer, IMapper mapper)
        {
            _response = new();
            _dbPlayer = dbPlayer;
            _mapper = mapper;
        }

        [HttpGet]
        // [ResponseCache(CacheProfileName = SD.Caching30Sec)] // to be added in prod
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetPlayer()
        {
            try
            {
                var player = await _dbPlayer.GetAsync(tracked: false);

                if (player == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<PlayerDTO>(player);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreatePlayer([FromBody] PlayerCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Not valid");

                    return BadRequest(createDTO);
                }

                Player player = _mapper.Map<Player>(createDTO);

                await _dbPlayer.CreateAsync(player);

                _response.Result = _mapper.Map<PlayerDTO>(player);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
            }

            return _response;
        }

    }
}
