using System;
using Task_2._1._2.Figures.Polygons;
using Task_2._1._2.Figures.RoundShapes;
using Task_2._1._2.Figures.Exceptions;
using Task_2._1._2.Figures;
using Task_2._1._2.CustomPaintConsoleUI.Entities;
using Task_2._1._2.CustomPaintConsoleUI.Helpers;

namespace Task_2._1._2.CustomPaintConsoleUI
{
    public class DrawingArea
    {
        private User _user;

        public DrawingArea(User user) => _user = user;

        /// <summary>
        /// Method returns true, if user wants to switch user
        /// </summary>
        public bool StartMenu() 
        {
            Console.Clear();

            string textStartMenu = "{0}, выберите действие:" + Environment.NewLine +
                                        "\t1. Добавить фигуру" + Environment.NewLine +
                                        "\t2. Вывести фигуры" + Environment.NewLine +
                                        "\t3. Очистить холст" + Environment.NewLine +
                                        "\t4. Сменить пользователя" + Environment.NewLine +
                                        "\t5. Выйти";

            string select = "";
            while(true)
            {
                Console.WriteLine(textStartMenu, _user.Name);

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
                        Console.Clear();
                        return true;
                    case "5":
                        Console.Clear();
                        return false;
                }

            }
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
                    1 => new Circle(InputHelpers.InputPoint("Центр"),
                                    InputHelpers.InputPositiveValue("Радиус: ")),

                    2 => new Round(InputHelpers.InputPoint("Центр"),
                                   InputHelpers.InputPositiveValue("Радиус: ")),

                    3 => new Ring(InputHelpers.InputPoint("Центр"),
                                  InputHelpers.InputPositiveValue("Внутренний радиус: "),
                                  InputHelpers.InputPositiveValue("Внешний радиус: ")),

                    4 => new Line(InputHelpers.InputPoint("Точка А"),
                                  InputHelpers.InputPoint("Точка B")),

                    5 => new Triangle(InputHelpers.InputPoint("Точка А"),
                                      InputHelpers.InputPoint("Точка B"),
                                      InputHelpers.InputPoint("Точка C")),

                    6 => new Quadrangle(InputHelpers.InputPoint("Точка А"),
                                        InputHelpers.InputPoint("Точка B"),
                                        InputHelpers.InputPoint("Точка C"),
                                        InputHelpers.InputPoint("Точка D"))
                };

                _user.AddFigure(newFigure);
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

        private void ClearFigures() => _user.RemoveAll();

        private void ShowFigures()
        {
            foreach (var item in _user.Figures)
            {
                Console.WriteLine($"{item}; Периметр = {item.Length():F3}; Площадь = {item.Area():F3}");
            }
        }
    }
}
