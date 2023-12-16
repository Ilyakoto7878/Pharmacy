using Pharmacy.Infrastructure.Mappers;
using Pharmacy.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pharmacy.Infrastructure.Database
{
    public class ProductRepository
    {
        public List<ProductViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.uslugi.ToList();
                return ProductMapper.Map(items);
            }
        }

        public ProductViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.uslugi.FirstOrDefault(x => x.id == id);
                return ProductMapper.Map(item);
            }
        }
        public ProductViewModel Update(ProductViewModel entity) // метод редактирования существующей записи клиента в бд
        {
            entity.name = entity.name.Trim();
            if (string.IsNullOrEmpty(entity.name))
                MessageBox.Show("Имя Пользователя не может быть пустым");

            using (var context = new Context())
            {
                var item = context.uslugi.FirstOrDefault(x => x.id == entity.id);
                if (item != null)
                {
                    item.name = entity.name;
                    item.cost = entity.cost;
                    context.SaveChanges();
                }
                else
                {
                    System.Windows.MessageBox.Show("");
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ProductMapper.Map(item);
            }
        }
        public ProductViewModel Add(ProductViewModel entity) // метод добавления клиента в бд
        {
            entity.name = entity.name.Trim();
            entity.cost = entity.cost;
            if (string.IsNullOrEmpty(entity.name) || entity.cost == null)
            {
                throw new Exception("Название Услуги не может быть пустым");
            }
            using (var context = new Context())
            {
                var item = ProductMapper.Map(entity);
                context.uslugi.Add(item);
                if (item != null)
                {
                    item.name = entity.name;
                    item.cost = entity.cost;
                    context.uslugi.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное Сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ProductMapper.Map(item);
            }
        }

        public void Delete(long id) // метод удаления существующей записи клиента в бд
        {
            // удаляем клиента
            using (var context = new Context())
            {
                var user = context.uslugi.FirstOrDefault(x => x.id == id);
                if (user != null)
                {
                    context.uslugi.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public List<ProductViewModel> Search(string search) // метод поиска существующей записи клиента в грид
        {
            search = search.Trim();
            using (var context = new Context())
            {
                var result = context.uslugi.Where(x => x.name.Contains(search) && x.name.StartsWith(search) || x.cost.ToString().StartsWith(search)).ToList();
                return ProductMapper.Map(result);
            }
        }
    }
}
