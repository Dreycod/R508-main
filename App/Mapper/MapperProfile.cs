using AutoMapper;
using App.Models;
namespace App.Mapper;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<Produit, DTO.ProduitDto>().ReverseMap();
        CreateMap<Produit, DTO.ProduitDetailDto>().ReverseMap();
        CreateMap<Marque, DTO.MarqueDto>().ReverseMap();
        CreateMap<TypeProduit, DTO.TypeProduitDto>().ReverseMap();
    }
}
