using System;
using System.Collections.Generic;
using System.Linq;
using Task_2._1._2.CustomPaintConsoleUI.Entities;

namespace Task_2._1._2.CustomPaintConsoleUI
{
    public class AccountsManager
    {
        private static AccountsManager _accounts;
        public static AccountsManager Accounts
        {
            get
            {
                if (_accounts is null)
                {
                    _accounts = new AccountsManager();
                }
                return _accounts;
            }
        }

        private Dictionary<int, User> _usersBD;
        private AccountsManager() => _usersBD = new Dictionary<int, User>();

        public User GetUserMenu()
        {
            string textSwitchUser = "Выберите действие:" + Environment.NewLine +
                                        "\t1. Добавить нового пользователя" + Environment.NewLine +
                                        "\t2. Выбрать пользователя";

            Console.Clear();

            Console.WriteLine("Cписок пользователей:");
            if (_usersBD.Count > 0)
            {
                foreach (var item in _usersBD)
                {
                    Console.WriteLine("{0, 5}{1, 10}", item.Key, item.Value.Name);
                }
            }
            else
            {
                Console.WriteLine("\tТут пока что пусто.");
            }

            Console.WriteLine(textSwitchUser);

            User user = null;
            string select = "";
            do
            {
                Console.Write("Выберите действие: ");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        user = AddUser();
                        break;
                    case "2":
                        if (_usersBD.Count > 0)
                            user = SwitchUser();
                        break;
                    default:
                        Console.WriteLine("Такого действия нет");
                        break;
                }
            } while (!(select == "1" || (select == "2" && _usersBD.Count > 0)));

            Console.Clear();
            return user;
        }

        private User SwitchUser()
        {
            int userId;
            do
            {
                Console.Write("ID пользователя: ");
            } while (!(int.TryParse(Console.ReadLine(), out userId)) ||
                     !(_usersBD.ContainsKey(userId)));

            return _usersBD[userId];
        }

        private User AddUser()
        {
            int newID;
            if (_usersBD.Count == 0)
            {
                newID = 0;
            }
            else
            {
                newID = _usersBD.Keys.Max() + 1;
            }

            string newUserName;
            do
            {
                Console.Write("Введите имя нового пользователя: ");
                newUserName = Console.ReadLine();
            } while (newUserName == string.Empty);

            User newUser = new User(newUserName);
            _usersBD.Add(newID, newUser);
            return newUser;
        }
    }
}
