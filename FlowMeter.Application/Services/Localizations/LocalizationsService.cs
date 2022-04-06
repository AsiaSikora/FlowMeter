﻿using AutoMapper;
using FlowMeter.Application.DTOs.Localization;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Domain;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Localizations
{
    public class LocalizationsService : ILocalizationsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LocalizationsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public List<LocalizationDto> GetLocalizations(int userId)
        {
            var localizations = _uow.Localizations.GetLocalizationsForUser(userId);
            var localizationsDto = _mapper.Map<List<LocalizationDto>>(localizations);

            return localizationsDto;
        }

        public LocalizationDto CreateLocalization(CreateLocalizationDto createLocalization, int userId)
        {
            var localizationDto = new LocalizationDto()
            {
                Name = createLocalization.Name,
                GpsCoordinate1 = createLocalization.GpsCoordinate1,
                GpsCoordinate2 = createLocalization.GpsCoordinate2,
                CanalRadius = createLocalization.CanalRadius,
                UserId = userId
            };

            var localization = _mapper.Map<Localization>(localizationDto);

            _uow.Localizations.Add(localization);
            _uow.Save();

            return localizationDto;
        }
    }
}
