----UserController.cs----
// [OutputCache(Duration = 600)]
//[ResponseCache(Duration =100)]
-----------------------------------


---Program.cs-------
 // builder.Services.AddMemoryCache();
// builder.Services.AddResponseCaching();
// builder.Services.AddOutputCache();
//app.UseOutputCache();
------------------------



----UserMapProfile.cs------------------
//.ForMember(dest => dest.RolesIds, opt => opt.MapFrom<RolesToRolesIdsResolver>());

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
---------------------------------