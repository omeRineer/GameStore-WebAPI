﻿using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _gameService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{gameId}")]
        public IActionResult GetById(int gameId)
        {
            var result = _gameService.GetByIdDto(gameId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Game game)
        {
            var result = _gameService.Add(game);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete/{gameId}")]
        public IActionResult Delete(int gameId)
        {
            var result = _gameService.Delete(gameId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Game game)
        {
            var result = _gameService.Update(game);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("fileupload")]
        public IActionResult FileUpload([FromForm] GameImageUploadDto gameImageDto)
        {
            var result = _gameService.ImageUpload(gameImageDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
