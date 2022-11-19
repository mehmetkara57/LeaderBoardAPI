using AutoMapper;
using LeaderBoard.Core.DTOs;
using LeaderBoard.Core.DTOs.UserDTOs;
using LeaderBoard.Core.Entities;
using LeaderBoard.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBoard.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IService<User> _service;
        private readonly IMapper _mapper;
        public static UserController instance;
        public UserController( IService<User> userService,IMapper mapper)
        {
            _service = userService;
            _mapper = mapper;
           
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> Add(SetUserDTO userDto)
        {
            // var user = _mapper.Map<SetUserDTO, User>(userDto);

            int leagueId = 0;
            if (userDto.Score >= 0 && userDto.Score <= 25000)
            {
                leagueId = 3;
            }
            else if (userDto.Score > 25000 && userDto.Score <= 75000)
            {
                leagueId = 2;
            }
            else
            {
                leagueId = 1;
            }
            var user = new User() {
            UserName= userDto.UserName,
            Score= userDto.Score,
            CreatedOn= DateTime.Now,
            UpdatedOn= null,
            LeagueId= leagueId

            };
            await _service.AddAsync(user);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
        

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _service.GetAllAsync();
            var userDtos = _mapper.Map<List<User>, List<GetUserDTO>>(users.ToList());
            return Ok(CustomResponseDto<List<GetUserDTO>>.Success(userDtos));
        }

        [HttpGet("GetAllByLeague")]
        public async Task<IActionResult> GetAllByLeague(int leagueId)
        {
            var users= await _service.GetAllByLeagueAsync(leagueId);
            var userDtos = _mapper.Map<List<User>, List<GetUserDTO>>(users.ToList());
            return Ok(CustomResponseDto<List<GetUserDTO>>.Success(userDtos));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(user);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDTO userDto)
        {
            var user = _mapper.Map<UpdateUserDTO, User>(userDto);
            int leagueId = 0;
            if (user.Score >= 0 && user.Score <= 25000)
            {
                leagueId = 3;
            }
            else if (user.Score > 25000 && user.Score <= 75000)
            {
                leagueId = 2;
            }
            else
            {
                leagueId = 1;
            }
            user.LeagueId= leagueId;
            user.UpdatedOn = DateTime.Now;
            await _service.UpdateAsync(user);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
    }
}
