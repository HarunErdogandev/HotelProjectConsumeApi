using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WepApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Room, AddRoomDto>();
            CreateMap<AddRoomDto, Room>();

            CreateMap<UpdateRoomDtom,Room>().ReverseMap();
        }
    }
}
