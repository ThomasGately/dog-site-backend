using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Accounts;
using WebApi.Models.Dogs;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, WebApi.Models.Accounts.AccountResponse>();

            CreateMap<Account, WebApi.Models.Accounts.AuthenticateResponse>();

            CreateMap<WebApi.Models.Accounts.RegisterRequest, Account>();

            CreateMap<WebApi.Models.Accounts.CreateRequest, Account>();

            CreateMap<WebApi.Models.Accounts.UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

            /*
            CreateMap<Dog, WebApi.Models.Dogs.DogResponse>().AfterMap(src, opt => {});
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {

                    }
                ));
            */
        }
    }
}