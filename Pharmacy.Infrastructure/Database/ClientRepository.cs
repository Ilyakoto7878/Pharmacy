using Pharmacy.Infrastructure.Mappers;
using Pharmacy.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using Pharmacy.Infrastructure.Database;

namespace Pharmacy.Infrastructure.Database
{
    public class ClientRepository
    {
        public List<ClientViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.client.ToList();
                return ClientMapper.Map(items);
            }
        }

        public ClientViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.client.FirstOrDefault(x => x.id == id);
                return ClientMapper.Map(item);
            }
        }

        public ClientViewModel Update(ClientViewModel entity) // метод редактирования существующей записи клиента в бд
        {
            entity.fio = entity.fio.Trim();
            if (string.IsNullOrEmpty(entity.fio))
                MessageBox.Show("Имя Пользователя не может быть пустым");

            using (var context = new Context())
            {
                var item = context.client.FirstOrDefault(x => x.id == entity.id);
                if (item != null)
                {
                    item.fio = entity.fio;
                    item.dataRozd = entity.dataRozd;
                    context.SaveChanges();
                }
                else
                {
                    System.Windows.MessageBox.Show("");
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ClientMapper.Map(item);
            }
        }

        public ClientViewModel Add(ClientViewModel entity) // метод добавления клиента в бд
        {
            entity.fio = entity.fio.Trim();
            entity.dataRozd = entity.dataRozd.Trim();
            if(string.IsNullOrEmpty(entity.fio) || string.IsNullOrEmpty(entity.dataRozd))
            {
                throw new Exception("Имя Пользователя не может быть пустым");
            }
            using (var context = new Context())
            {
                var item = ClientMapper.Map(entity);
                context.client.Add(item);
                if (item != null)
                {
                    item.fio = entity.fio;
                    item.dataRozd = entity.dataRozd;
                    context.client.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное Сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ClientMapper.Map(item);
            }
        }

        public void Delete(long id) // метод удаления существующей записи клиента в бд
        {
            // удаляем клиента
            using (var context = new Context())
            {
                var user = context.client.FirstOrDefault(x => x.id == id);
                if (user != null)
                {
                    context.client.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public List<ClientViewModel> Search(string search) // метод поиска существующей записи клиента в грид
        {
            search = search.Trim();
           using (var context = new Context())
           {
               var result = context.client.Where(x => x.fio.Contains(search) && x.fio.StartsWith(search) || x.dataRozd.ToString().Contains(search)).ToList();
               return ClientMapper.Map(result);
           }
        } 
    }
}
