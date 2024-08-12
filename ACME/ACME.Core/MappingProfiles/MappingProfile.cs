using ACME.Domain.Models.Dtos;
using ACME.Domain.Models.Entities;
using ACME.Domain.Models.Enums;
using AutoMapper;

namespace ACME.Core.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dst => dst.NoOfActiveSubscriptions, opt => opt.MapFrom(src => src.Subscriptions.Count(data => data.Status == Status.Enabled)))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.LastModifiedAtUtcNow, opt => opt.MapFrom(src => src.UpdatedAtUtcNow ?? src.CreatedAtUtcNow))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy ?? src.UpdatedBy));

            CreateMap<Address, AddressDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.LastModifiedAtUtcNow, opt => opt.MapFrom(src => src.UpdatedAtUtcNow ?? src.CreatedAtUtcNow))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy ?? src.UpdatedBy));

            CreateMap<Subscription, SubscriptionDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.LastModifiedAtUtcNow, opt => opt.MapFrom(src => src.UpdatedAtUtcNow ?? src.CreatedAtUtcNow))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy ?? src.UpdatedBy));

            CreateMap<Magazine, MagazineDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.LastModifiedAtUtcNow, opt => opt.MapFrom(src => src.UpdatedAtUtcNow ?? src.CreatedAtUtcNow))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy ?? src.UpdatedBy));
            
            CreateMap<Country, CountryDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.LastModifiedAtUtcNow, opt => opt.MapFrom(src => src.UpdatedAtUtcNow ?? src.CreatedAtUtcNow))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy ?? src.UpdatedBy));
            
            CreateMap<Publication, PublicationDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.LastModifiedAtUtcNow, opt => opt.MapFrom(src => src.UpdatedAtUtcNow ?? src.CreatedAtUtcNow))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy ?? src.UpdatedBy));

            CreateMap<PrintDistributor, PrintDistributorDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.LastModifiedAtUtcNow, opt => opt.MapFrom(src => src.UpdatedAtUtcNow ?? src.CreatedAtUtcNow))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy ?? src.UpdatedBy));
        }
    }
}
