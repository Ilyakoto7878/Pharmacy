using Pharmacy.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Mappers
{
    public static class ClientMapper
    {
        public static ClientViewModel Map(ClientEntity entity)
        {
            var viewModel = new ClientViewModel
            {
                id = entity.id,
                fio = entity.fio,
                dataRozd = entity.dataRozd,
                
            };
            return viewModel;
        }

        public static List<ClientViewModel> Map(List<ClientEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static ClientEntity Map(ClientViewModel viewModel)
        {
            var entity = new ClientEntity
            {
                id = viewModel.id,
                fio = viewModel.fio,
                dataRozd = viewModel.dataRozd,
            };
            return entity;
        }

    }
}
