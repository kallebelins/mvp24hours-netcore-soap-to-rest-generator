using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using System;
using Samples.WebAPI.WebService;

namespace Samples.WebAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelWithPropertyDto : IMapFrom<ModelWithPropertyDto>
    {
        

        /// <summary>
/// 
/// </summary>
public Int32 Property1 { get; set; }
/// <summary>
/// 
/// </summary>
public Int32 Property2 { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ModelWithPropertyDto, ModelWithProperty>().ReverseMap();
        }
    }
}
