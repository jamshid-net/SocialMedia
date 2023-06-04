namespace SocialMedia.Application.Common.Mappings;
public class UserMapProfile:Profile
{
    public  UserMapProfile()
    {
        CreateMap<UserGetDto, User>();
        CreateMap<User, UserGetDto>();
            //.ForMember(dest => dest.RolesIds, opt => opt.MapFrom<RolesToRolesIdsResolver>());
    }

}

///// <summary>
/////     (UserGetDto => RolesIds, Resolver => User => Roles) 
/////     The UserGetDto => RolesIds is Guid[] array
/////     The User=> Roles is List item.
///// </summary>

//public class RolesToRolesIdsResolver : IValueResolver<User, UserGetDto, Guid[]>
//{
//    public Guid[] Resolve(User source, UserGetDto destination, Guid[] destMember, ResolutionContext context)
//    {

//       var roleIds = new List<Guid>();
//       if(source.Roles != null)
//        {
//            foreach (var item in source.Roles)
//            {
//               roleIds.Add(item.Id);
//            }
//        }

//       return roleIds.ToArray();
//    }
//}
