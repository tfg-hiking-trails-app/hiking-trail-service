﻿using Common.Application.Interfaces;
using HikingTrailService.Application.DTOs;
using HikingTrailService.Application.DTOs.Create;
using HikingTrailService.Application.DTOs.Update;

namespace HikingTrailService.Application.Interfaces;

public interface ITrailTypeService : IService<TrailTypeEntityDto, CreateTrailTypeEntityDto, UpdateTrailTypeEntityDto>
{
}