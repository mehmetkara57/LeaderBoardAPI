using AutoMapper;
using LeaderBoard.Core.DTOs.LeagueDTOs;
using LeaderBoard.Core.DTOs.UserDTOs;
using LeaderBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile() {

            CreateMap<User, GetUserDTO>();
            CreateMap<SetUserDTO, User>();
            CreateMap<League, SetLeagueDTO>().ReverseMap();
            CreateMap<UpdateUserDTO, User>();
        }

    }
}
