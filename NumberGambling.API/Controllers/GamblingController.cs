using Microsoft.AspNetCore.Mvc;
using NumberGambling.Application.Interfaces;
using NumberGambling.Application.ResultModels;
using NumberGambling.Application.ViewModels.Gambling;
using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NumberGambling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamblingController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGamblingService _gamblingService;
        public GamblingController(IUserService userService, IGamblingService gamblingService)
        {
            _userService = userService;
            _gamblingService = gamblingService;
        }
        // GET: api/<GamblingController>
        [HttpPost]
        public async Task <IActionResult> POST([FromBody]GamblingRequest model)
        {
            var user = await _userService.GetUserAsync(model.UserId);
            if(user == null) 
            {
                user = new User();
                await _userService.AddUserAsync(user);
            }

            GamblingResult result  = await _gamblingService.PerformGambling(user, model.Points, model.Number);
            if (result.Success) 
            {
                GamblingResponse gamblingResponse = new GamblingResponse();
                gamblingResponse.Account = result.TotalPoints;
                gamblingResponse.Status = result.Status;
                gamblingResponse.Points = result.PointChange;
                gamblingResponse.UserId = user.Id;
                return Ok(gamblingResponse);
            }
            GamblingResponseError gamblingResponseError = new GamblingResponseError();
            gamblingResponseError.Error = result.ErrorMessage;
            return Ok(gamblingResponseError);
        }

  
    }
}
