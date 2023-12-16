using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using Pharmacy.Infrastructure.Consts;
using Pharmacy.Infrastructure.Database;
namespace Pharmacy.Infrastructure.Database
{
    public class UserRepository
    {
        public UserEntity Login(string login, string password)
        {
            using (var context = new Context())
            {
                var item = context.user.Include(x => x.role).FirstOrDefault(x => x.login == login && x.password == password);
                if (item != null)
                {
                    Application.Current.Resources[UserInfoConsts.UserId] = item.id;
                    Application.Current.Resources[UserInfoConsts.RoleId] = item.idrole;
                    Application.Current.Resources[UserInfoConsts.UserName] = item.login;
                    Application.Current.Resources[UserInfoConsts.RoleName] = item.role.name;
                    return item;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
