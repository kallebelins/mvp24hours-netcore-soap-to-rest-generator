using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using System;
using Samples.WebAPI.WebService;

namespace Samples.WebAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelWithFieldDto : IMapFrom<ModelWithFieldDto>
    {
        

        /// <summary>
/// 
/// </summary>
public Int32 Field1 { get; set; }
/// <summary>
/// 
/// </summary>
public Int32 Field2 { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ModelWithFieldDto, ModelWithField>().ReverseMap();
        }
    }
}
