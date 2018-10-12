using System;

using MyQuiver.Contracts;
using MyQuiver.Model;

using AutoMapper;
namespace MyQuiver.Model
{
    public class MongoDbMap:Profile
    {
        public MongoDbMap()
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<LimbModel, Limb>().ReverseMap();
            CreateMap<ArcheryEventModel, ArcheryEvent>().ReverseMap();

        }
    }
}
