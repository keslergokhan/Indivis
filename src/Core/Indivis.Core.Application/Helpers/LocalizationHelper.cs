using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Writes;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Features.Systems.Commands.Localizations;
using Indivis.Core.Application.Features.Systems.Queries.Localizations;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Helpers
{
    public static class LocalizationHelper
    {
        private static IServiceProvider _serviceProvider;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            LocalizationHelper._serviceProvider = serviceProvider;
        }

        private static T GetService<T>()
        {
            return LocalizationHelper._serviceProvider.GetService<T>();
        }

        private static Task<IResultDataControl<ReadLocalizationDto>> AddPageLocalizationAsync(string key, string defaultValue, ICurrentResponse currentResponse)
        {
            return LocalizationHelper.AddLocalizationAsync(key, new WriteLocalizationDto()
            {
                DefaultValue = defaultValue,
                IsBackendLocalization = false,
                IsPageLocalization = true,
                Key = key,
                State = (int)StateEnum.Online,
                PageId = currentResponse.CurrentPage.Id
            }, currentResponse);
        }

        private static Task<IResultDataControl<ReadLocalizationDto>> AddLocalizationAsync(string key, WriteLocalizationDto localizaton, ICurrentResponse currentResponse)
        {
            IMediator mediator = LocalizationHelper._serviceProvider.GetService<IMediator>();

            return mediator.Send(new AddLocalizationSystemCommand()
            {
                Localization = localizaton
            });
        }

        public static async Task<ReadLocalizationDto> GetLocalizationAsync(string key, ICurrentResponse currentResponse, string defaultValue)
        {
            ReadLocalizationDto localization = currentResponse.CurrentPage.Localization.FirstOrDefault(x => x.Key == key);

            if (localization != null)
            {
                return localization;
            }


            IMediator mediator = LocalizationHelper._serviceProvider.GetService<IMediator>();

            IResultDataControl<ReadLocalizationDto> localizationResult = await mediator.Send(new GetByKeyLocalizationSystemQuery()
            {
                Key = key,
            });


            if (localizationResult.IsSuccess)
            {
                localization = localizationResult.Data;
            }
            else
            {
                IResultDataControl<ReadLocalizationDto> addLocalizationResult = await LocalizationHelper.AddPageLocalizationAsync(key, defaultValue, currentResponse);

                if (addLocalizationResult.IsSuccess)
                {
                    localization = addLocalizationResult.Data;
                    currentResponse.CurrentPage.Localization.Add(addLocalizationResult.Data);
                }
            }

          
            return localization;
        }


    }
}
