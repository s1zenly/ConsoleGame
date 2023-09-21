using System;


namespace Game
{
    class Program
    {
        //Метод отвечает за передвижение игрока
        static void DVigroka(int xix, int yix, int xi, int yi)
        {
            //Удаляем предыдущую позицию игрока
            Console.SetCursorPosition(xix, yix);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine('*');

            //Перемещаем в новую позицию игрока
            Console.SetCursorPosition(xi, yi);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine('*');
        }

        //Метод отвечает за передвижение игрока
        static void DVvraga(int xvrx, int yvrx, ref int xvr, ref int yvr, int xi, int yi)
        {
            //Задаем равный шанс на все 4 стороны передвижения врага с помощью Random
            Random rnd = new Random();
            int xod = rnd.Next(1, 5);
            //Проверяем результат Random и делаем ход
            switch (xod)
            {
                case 1:
                    xvr++;
                    break;
                case 2:
                    xvr--;
                    break;
                case 3:
                    yvr++;
                    break;
                case 4:
                    yvr--;
                    break;
            }
            //Устанавливаем курсор на предыдущей позиции врага
            Console.SetCursorPosition(xvrx, yvrx);
            //Проверяем,если в предыдущую позицию врага не попадает наш игрок, то стираем след, иначе отображаем там игрока
            //P.S:Чтобы избежать заркраски игрока, если он встанет в прошлую позицию врага
            if ((xi != xvrx) || (yi != yvrx))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine('#');
            }
            else
                Console.WriteLine('*');
            //Перемещаем врага в новую позицию
            Console.SetCursorPosition(xvr, yvr);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine('#');
        }

        //Метод отвечает за столкновение игрока/врага с полем игры
        static void VuxodZaPole(ref int xi, ref int yi, ref int xvr, ref int yvr)
        {
            //Если игрок касается нижней границы поля
            if (yi == 23)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('_');
                //Перемещаем игрока параллельно 
                yi = yi - 14;
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('*');
            }
            else
                //Если игрок касается верхней границы поля
                if (yi == 8)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('_');
                //Перемещаем игрока параллельно
                yi = yi + 14;
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('*');
            }
            //Если игрок касается левой границы поля
            if (xi == 31)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('|');
                //Перемещаем игрока параллельно
                xi = xi + 59;
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('*');
            }
            //Если игрок касается правой границы поля
            if (xi == 91)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('|');
                //Перемещаем игрока параллельно
                xi = xi - 59;
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('*');
            }
            //Если враг касается правой границы поля
            if (yvr == 23)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('_');
                // Перемещаем врага параллельно
                yvr = yvr - 14;
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine('#');
            }
            else
               //Если враг касается правой границы поля
               if (yvr == 8)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('_');
                //Перемещаем врага параллельно
                yvr = yvr + 14;
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine('#');
            }
            //Если враг касается правой границы поля
            if (xvr == 31)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('|');
                //Перемещаем врага параллельно
                xvr = xvr + 59;
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine('#');
            }
            //Если враг касается правой границы поля
            if (xvr == 91)
            {
                //Не даем стереть часть нашего поля
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine('|');
                //Перемещаем врага параллельно
                xvr = xvr - 59;
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine('#');
            }


        }

        //Метод отвечает за окончание игры и ее перезапуск
        static void OverGame(ref int xi, int yi, int xvr, int yvr, int xix, int yix, int xvrx, int yvrx, int c, int chi, int chv, int xmon, int ymon)
        {
            //Проверяем если игрок и враг попали в одну позицию или переместились в предыдущие позиции друг друга(т.е пересеклись)
            //Проверяем если игрок нажал "Escape" (переменная 'с') или Счетчик сбора монет равен 5 у игрока/врага
            if (((((xi == xvr) && (yi == yvr)) || ((xix == xvr) && (yix == yvr) && (xvrx == xi) && (yvrx == yi))) || (c == 1)) || (chi == 5) || (chv == 5))
            {
                //Удаляем отображение игрока с поля
                Console.SetCursorPosition(xi, yi);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine('*');

                //Удаляем отображение врага с поля
                Console.SetCursorPosition(xvr, yvr);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine('#');

                //Удаляем отображение монеты с поля
                Console.SetCursorPosition(xmon, ymon);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine('$');

                //Устанавливаем курсор на центре игрового поля и выводим одну из фраз
                Console.SetCursorPosition(57, 16);
                Console.ForegroundColor = ConsoleColor.Red;
                //Если причина окончания игры - столкновение или желание игрока окончить игру
                if ((chi != 5) && (chv != 5))
                    Console.WriteLine("GAME OVER!");
                //Если причина окончания игры - пять собранных монет игроком
                if (chi == 5)
                    Console.WriteLine("Player wins!");
                //Если причина окончания игры - пять собранных монет врагом
                if (chv == 5)
                    Console.WriteLine("Enemies wins!");
                //Ожиданием нажатие любой клавиши
                Console.ReadKey();
                //Передаем  Флаг для перезапуска игры
                xi = -1;
            }

        }

        //Метод отвечает за появление монет
        static void Moneta(int xi, int yi, int xvr, int yvr, ref int xmon, ref int ymon)
        {
            //Задание с помощью Random координаты монеты
            Random kro = new Random();
            xmon = kro.Next(32, 91);
            ymon = kro.Next(9, 23);

            //Отображаем монету на игровом поле
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(xmon, ymon);
            Console.WriteLine('$');


            //Проверяем на совпадение монеты с игроком/врагом
            if (((xmon == xi) && (ymon == yi)) || ((xmon == xvr) && (ymon == yvr)))
                //Делаем рекурсию если true
                Moneta(xi, yi, xvr, yvr, ref xmon, ref ymon);


        }

        //Метод отвечает за проверку на подбор монеты игроком/врагом
        static void Podbor(int xi, int yi, int xvr, int yvr, ref int xmon, ref int ymon, ref int chi, ref int chv)
        {
            //Создаем Флаг
            int flag = 0;
            //Если игрок подобрал монету, то увеличиваем его счетчик на 1
            if ((xi == xmon) && (yi == ymon))
            {
                chi = chi + 1;
                flag = 1;
            }
            //Если враг подобрал монету, то увеличиваем его счетчик на 1
            if ((xvr == xmon) && (yvr == ymon))
            {
                chv = chv + 1;
                flag = 1;
            }
            //Если монета была подобрана, то создаем новую, иначе ничего не происходит
            if (flag == 1)
                Moneta(xi, yi, xvr, yvr, ref xmon, ref ymon);
        }

        //Основной метод игры
        static void Main()
        {

            //Окраска консоли
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();

            //Вывод надписи в центре
            Console.SetCursorPosition(52, 16);
            Console.WriteLine("Нажмите любую клавишу \n                                                       для начала игры");
            Console.ReadKey();

        nachalo:
            //Описываем нажатую клавишу консоли
            ConsoleKeyInfo cki;

            /*Переменные: вначале x - значит координата по Ox объекта
                          вначале y - значит координата по Oy объекта
                          присутствие i - значит это переменная игрока
                          присутствие vr - значит это переменная врага
                          в конце x - значит это предыдущая позиция объекта
                          mon - значит это монета
              Пример:xi - координата по Ox игрока
                     yvrx - предыдущая координата врага по Oy
                     xvr - координата по Oy врага
            */

            //Объявление некоторых переменных
            int chi = 0;
            int chv = 0;
            //Присвоен 0 для прохождения в метод(Они сейчас примут свои нужные значения, это ни на что не влияет)
            int xmon = 0, ymon = 0;
            int xix = 0, yix = 0, xvrx = 0, yvrx = 0;



            //Удаление надписи при первичном запуске программы
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();

            //Создание игрового поля

            //Создание верхней границы
            Console.SetCursorPosition(31, 8);
            string pole1 = new string('_', 60);
            Console.WriteLine(pole1);

            //Создание нижней границы
            Console.SetCursorPosition(31, 23);
            string pole2 = new string('_', 60);
            Console.WriteLine(pole2);

            //Создание левой границы
            for (int i = 9; i < 24; i++)
            {
                Console.SetCursorPosition(31, i);
                Console.WriteLine('|');
            }

            //Создание правой границы
            for (int j = 9; j < 24; j++)
            {
                Console.SetCursorPosition(91, j);
                Console.WriteLine('|');
            }

            //Удаляем отображение курсора с экрана
            Console.CursorVisible = false;

        //Если позиция игрока и врага при создании игры совпадут
        vozv:

            //Создаем отображение игрока в центре игрового поля 
            int xi = 60;
            int yi = 16;
            int c = 0;

            Console.SetCursorPosition(xi, yi);
            Console.WriteLine('*');

            //Создаем отображение врага в случайном месте игрового поля

            Random rnd = new Random();
            int xvr = rnd.Next(32, 91);
            int yvr = rnd.Next(9, 23);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(xvr, yvr);
            Console.WriteLine('#');

            //вводим монетку
            Moneta(xi, yi, xvr, yvr, ref xmon, ref ymon);


            //Проверяем на совпадение игрока и врага
            if ((xvr == xi) && (yvr == yi))
                goto vozv;

            //Повторный ход игрока
            vkn:

            //Отображение счетчика игрока
            Console.SetCursorPosition(31, 6);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Player:{chi}");

            //Отображение счетчика врага
            Console.SetCursorPosition(31, 7);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Enemy:{chv}");

            //Проверяем собрано ли пять монет игроков или врагом
            if ((chi == 5) || (chv == 5))
                OverGame(ref xi, yi, xvr, yvr, xix, yix, xvrx, yvrx, c, chi, chv, xmon, ymon);
            //Если предыдущая проверка дала true, то xi было присвоено -1, значит начинаем игру сначала
            if (xi == -1)
                goto nachalo;

            //Активируем считывание клавиш
            cki = Console.ReadKey(true);
            //Запоминаем предыдущие позиции игрока и врага
            xix = xi;
            yix = yi;
            xvrx = xvr;
            yvrx = yvr;


            //Проверяем какая клавиша была нажата
            switch (cki.Key)
            {
                //Движение вверх
                case ConsoleKey.W:
                    yi--;
                    DVigroka(xix, yix, xi, yi);
                    DVvraga(xvrx, yvrx, ref xvr, ref yvr, xi, yi);
                    VuxodZaPole(ref xi, ref yi, ref xvr, ref yvr);
                    OverGame(ref xi, yi, xvr, yvr, xix, yix, xvrx, yvrx, c, chi, chv, xmon, ymon);
                    Podbor(xi, yi, xvr, yvr, ref xmon, ref ymon, ref chi, ref chv);
                    //Перезапуск игры
                    if (xi == -1)
                        goto nachalo;
                    goto vkn;
                //Движение вниз
                case ConsoleKey.S:
                    yi++;
                    DVigroka(xix, yix, xi, yi);
                    DVvraga(xvrx, yvrx, ref xvr, ref yvr, xi, yi);
                    VuxodZaPole(ref xi, ref yi, ref xvr, ref yvr);
                    OverGame(ref xi, yi, xvr, yvr, xix, yix, xvrx, yvrx, c, chi, chv, xmon, ymon);
                    Podbor(xi, yi, xvr, yvr, ref xmon, ref ymon, ref chi, ref chv);
                    //Перезапуск игры
                    if (xi == -1)
                        goto nachalo;
                    goto vkn;
                //Движение влево
                case ConsoleKey.A:
                    xi--;
                    DVigroka(xix, yix, xi, yi);
                    DVvraga(xvrx, yvrx, ref xvr, ref yvr, xi, yi);
                    VuxodZaPole(ref xi, ref yi, ref xvr, ref yvr);
                    OverGame(ref xi, yi, xvr, yvr, xix, yix, xvrx, yvrx, c, chi, chv, xmon, ymon);
                    Podbor(xi, yi, xvr, yvr, ref xmon, ref ymon, ref chi, ref chv);
                    //Перезапуск игры
                    if (xi == -1)
                        goto nachalo;
                    goto vkn;
                //Движение вправо
                case ConsoleKey.D:
                    xi++;
                    DVigroka(xix, yix, xi, yi);
                    DVvraga(xvrx, yvrx, ref xvr, ref yvr, xi, yi);
                    VuxodZaPole(ref xi, ref yi, ref xvr, ref yvr);
                    OverGame(ref xi, yi, xvr, yvr, xix, yix, xvrx, yvrx, c, chi, chv, xmon, ymon);
                    Podbor(xi, yi, xvr, yvr, ref xmon, ref ymon, ref chi, ref chv);
                    //Перезапуск игры
                    if (xi == -1)
                        goto nachalo;
                    goto vkn;
                //Проверка на остановку игры игроком
                case ConsoleKey.Escape:
                    //Флажок остановки
                    c = 1;
                    OverGame(ref xi, yi, xvr, yvr, xix, yix, xvrx, yvrx, c, chi, chv, xmon, ymon);
                    if (xi == -1)
                        goto nachalo;
                    goto vkn;
                default:
                    goto vkn;

            }

        }
    }
}
