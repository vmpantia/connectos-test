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

            CreateMap<Subscription, SubscriptionSummaryDetailDto>()
                .ForMember(dst => dst.CustomerId, opt => opt.MapFrom(src => src.Customer.Id.ToString()))
                .ForMember(dst => dst.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName} ({src.Customer.Email})"))
                .ForMember(dst => dst.CustomerAddressId, opt => opt.MapFrom(src => src.Address.Id.ToString()))
                .ForMember(dst => dst.CustomerAddress, opt => opt.MapFrom(src => $"{src.Address.AddressLine1}, {src.Address.AddressLine2}, {src.Address.City}, {src.Address.ZipCode}, {src.Address.State}"))
                .ForMember(dst => dst.SubscriptionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.MagazineId, opt => opt.MapFrom(src => src.Magazine.Id))
                .ForMember(dst => dst.MagazineName, opt => opt.MapFrom(src => $"{src.Magazine.Name} ({src.Magazine.Code})"))
                .ForMember(dst => dst.CountryId, opt => opt.MapFrom(src => src.Address.Country.Id))
                .ForMember(dst => dst.CountryName, opt => opt.MapFrom(src => $"{src.Address.Country.Name} ({src.Address.Country.Code})"));

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
