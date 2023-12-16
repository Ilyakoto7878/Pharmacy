using Pharmacy.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel Map(ProductEntity entity)
        {
            var viewModel = new ProductViewModel
            {
                id = entity.id,
                name = entity.name,
                cost = entity.cost,

            };
            return viewModel;
        }

        public static List<ProductViewModel> Map(List<ProductEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static ProductEntity Map(ProductViewModel viewModel)
        {
            var entity = new ProductEntity
            {
                id = viewModel.id,
                name = viewModel.name,
                cost = viewModel.cost,
            };
            return entity;
        }
    }
}
