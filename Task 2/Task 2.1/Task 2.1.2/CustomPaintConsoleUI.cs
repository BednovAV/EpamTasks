using System;
using System.Collections.Generic;
using System.Linq;
using Task_2._1._2.Polygons;
using Task_2._1._2.RoundShapes;
using Task_2._1._2.Exceptions;

namespace Task_2._1._2
{
    public class CustomPaintConsoleUI
    {
        private Dictionary<int, User> _usersBD;
        private int _currentUser;

        public CustomPaintConsoleUI()
        {
            _usersBD = new Dictionary<int, User>();
            _currentUser = -1;
        } 
        public void StartMenu()
        {
            SwitchUserMenu();

            string textStartMenu = "{0}, выберите действие:" + Environment.NewLine +
                                        "\t1. Добавить фигуру" + Environment.NewLine +
                                        "\t2. Вывести фигуры" + Environment.NewLine +
                                        "\t3. Очистить холст" + Environment.NewLine +
                                        "\t4. Сменить пользователя" + Environment.NewLine +
                                        "\t5. Выйти";

            string select = "";
            while(select != "5")
            {
                //Console.Clear();
                Console.WriteLine(textStartMenu, _usersBD[_currentUser].Name);

                Console.Write("Ввод: ");
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        AddFigureMenu();
                        break;
                    case "2":
                        ShowFigures();
                        break;
                    case "3":
                        ClearFigures();
                        break;
                    case "4":
                        SwitchUserMenu();
                        break;
                }

            }
        }

        private void SwitchUserMenu()
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

            string select = "";
            do
            {
                Console.Write("Выберите действие: ");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        if(_usersBD.Count > 0)
                            SwitchUser();
                        break;
                    default:
                        Console.WriteLine("Такого действия нет");
                        break;
                }
            } while (!(select == "1" || (select == "2" && _usersBD.Count > 0)));

            Console.Clear();
        }

        private void AddFigureMenu()
        {
            string textAddFigureMenu = "Выберите тип фигуры:" + Environment.NewLine +
                                            "\t1. Окружность" + Environment.NewLine +
                                            "\t2. Круг" + Environment.NewLine +
                                            "\t3. Кольцо" + Environment.NewLine +
                                            "\t4. Линия" + Environment.NewLine +
                                            "\t5. Треугольник" + Environment.NewLine +
                                            "\t6. Четырехугольник";

            Console.WriteLine(textAddFigureMenu);

            int selectedFigure;
            bool retry = false;
            do
            {
                Console.Write("Выберите фигуру: ");
                retry = !(int.TryParse(Console.ReadLine(), out selectedFigure));
                if (retry)
                {
                    Console.WriteLine("Такой фигуры нет");
                }
            } while (retry || selectedFigure < 1 || selectedFigure > 6);

            try
            {
                Figure newFigure = selectedFigure switch
                {
                    1 => new Circle(InputPoint("Центр"), InputPositiveValue("Радиус: ")),
                    2 => new Round(InputPoint("Центр"), InputPositiveValue("Радиус: ")),
                    3 => new Ring(InputPoint("Центр"), InputPositiveValue("Внутренний радиус: "), InputPositiveValue("Внешний радиус: ")),
                    4 => new Line(InputPoint("Точка А"), InputPoint("Точка B")),
                    5 => new Triangle(InputPoint("Точка А"), InputPoint("Точка B"), InputPoint("Точка C")),
                    6 => new Quadrangle(InputPoint("Точка А"), InputPoint("Точка B"), InputPoint("Точка C"), InputPoint("Точка D"))
                };

                _usersBD[_currentUser].AddFigure(newFigure);
                Console.WriteLine("Фигура успешно добавлена");
            }
            catch (IdenticalPointsExeption) 
            {
                Console.WriteLine("Ошибка. Фигура не была добавлена," +
                    " так как она не может содержать одинаковые точки");
            }
            catch (IncorrectRadiusExeption)
            {
                Console.WriteLine("Ошибка. Фигура не была добавлена," +
                    " так как внешний радиус кольца должен быть строго больше внутреннего");
            }
        }

        private void SwitchUser()
        {
            int userId;
            do
            {
                Console.Write("ID пользователя: ");
            } while (!(int.TryParse(Console.ReadLine(), out userId)) ||
                     !(_usersBD.ContainsKey(userId)));

            _currentUser = userId;
        }

        private void AddUser()
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

            _usersBD.Add(newID, new User(newUserName));
            _currentUser = newID;
        }

        private void ClearFigures() => _usersBD[_currentUser].RemoveAll();

        private Point InputPoint(string name)
        {
            Console.WriteLine(name);

            int x = InputValue("\tX: ");
            int y = InputValue("\tY: ");

            return new Point(x, y);
        }

        private int InputPositiveValue(string text)
        {
            int value;

            do
            {
                Console.Write(text);
            } while (!(int.TryParse(Console.ReadLine(), out value)) || value <= 0);

            return value;
        }

        private int InputValue(string text)
        {
            int value;

            do
            {
                Console.Write(text);
            } while (!(int.TryParse(Console.ReadLine(), out value)));

            return value;
        }

        private void ShowFigures()
        {
            foreach (var item in _usersBD[_currentUser].Figures)
            {
                Console.WriteLine($"{item}; Периметр = {item.Length():F3}; Площадь = {item.Area():F3}");
            }
        }
    }
}
