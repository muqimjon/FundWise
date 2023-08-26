using FundWise.Service.DTOs;
using FundWise.Service.Interfaces.Commons;

namespace FundWise.Service.Interfaces;

public interface IAssetService : IServiceInterface<AssetCreationDto, AssetUpdateDto, AssetResultDto>
{
}