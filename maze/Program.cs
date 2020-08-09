using System;
using System.Threading;
using System.IO;

namespace maze
{
    class WriteToFile
    {
        static StreamWriter sw = new StreamWriter("gameTracker.txt");

        DateTime start;
        DateTime end;
        public void startWriteToFile(int x, int y, int money)
        {
            sw.WriteLine("Игра начата");
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + "(" + x + "," + y + ")\t" + money + " монеток");

            start = DateTime.Now.ToLocalTime();
        }
        public void writeToFile(int x, int y, int money)
        {
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + "(" + x + "," + y + ")\t" + money + " монеток");
        }
        public void endWriteToFile(int x, int y, int money)
        {
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + "(" + x + "," + y + ")\t" + money + " монеток");
            sw.WriteLine("Игра закончена");

            end = DateTime.Now.ToLocalTime();

            TimeSpan interval = end - start;

            sw.WriteLine("Общее время игры: " + interval.Minutes + " минут(ы) " + interval.Seconds + " секунд(ы)");

            sw.Close();
        }

        public void endWriteToFileWithExecption(int x, int y, int money)
        {
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + "(" + x + "," + y + ")\t" + money + " монеток");
            sw.WriteLine("Игра закончена с ошибкой");

            sw.Close();
        }

    }

    class LogActs
    {
        static StreamWriter sw = new StreamWriter("acts.log");
        public void startWriteToFile()
        {
            sw.WriteLine("Игра начата");
        }
        public void writeToFileKey(ConsoleKey key)
        {
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + "Нажата клавиша: " + key);
        }
        public void writeToFileMoneyandCoorditants(int x, int y, int money)
        {
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + "Подобрана монетка: " + "(" + x + "," + y + ") " + "(" + money + " монеток)");
        }
        public void endWriteToFile()
        {
            sw.WriteLine("Игра закончена");

            sw.Close();
        }

        public void endWriteToFileWithExecption()
        {
            sw.WriteLine("Игра закончена с ошибкой");

            sw.Close();
        }

    }

    class WallExeption : Exception
    {
        public WallExeption() : base("*врезался в стенку*") { }
    }
    class KeyExeption : Exception
    {
        public KeyExeption() : base("*ввел не стрелку*") { }
    }

    class LogExceptions
    {
        static StreamWriter sw = new StreamWriter("exceptions.log");
        public void startWriteToFile()
        {
            sw.WriteLine("Игра начата");
        }
        public void KeyExceptions(KeyExeption ex)
        {
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + ex.Message);
        }
        public void WallExceptions(WallExeption ex)
        {
            sw.WriteLine("<" + DateTime.Now.ToLocalTime() + ">\t" + ex.Message);
        }
        public void endWriteToFile()
        {
            sw.WriteLine("Игра закончена");

            sw.Close();
        }
        public void endWriteToFileWithException()
        {
            sw.WriteLine("Игра закончена ошибкой");

            sw.Close();
        }

    }
    class Field
    {
        public const int rows = 27;
        public const int columns = 32;
        public const int maxMoney = 72;
        public string[,] field = new string[rows, columns] {
     { "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#" },
     { "#"," ","#","$"," "," ","#"," ","#","$","#"," "," "," "," "," "," "," ","#"," "," "," ","#"," "," "," "," "," "," ","$"," ","#" },
     { "#"," ","#"," ","#"," "," "," "," "," "," "," ","#"," "," "," ","#"," ","$"," "," "," ","#"," "," "," ","#","$"," ","#","#","#" },
     { "#"," ","#","#","#","#","#","#","#"," ","#"," ","$","$","#"," ","#"," "," "," ","#"," "," "," ","$","#"," "," ","#"," "," ","#" },
     { "#"," "," "," "," "," "," ","#"," "," ","#","#","#","#","#","#","#"," ","#"," ","$","#"," "," ","#"," ","#"," ","$","#"," ","#" },
     { "#"," ","#"," "," "," "," "," "," "," "," ","$"," "," "," "," ","#"," "," "," "," "," ","#"," "," "," ","$"," ","#"," "," ","#" },
     { "#"," ","$","$"," ","#","#"," ","$"," "," "," "," "," "," ","$","#","#","#"," ","#","#","#"," "," ","#"," ","#","#"," "," ","#" },
     { "#"," "," ","#","#","#"," ","#"," "," ","#"," ","$"," "," "," ","#"," "," "," "," "," ","$"," "," "," "," "," "," "," ","$","#" },
     { "#"," "," "," "," "," "," ","#"," "," "," ","#"," ","#"," "," ","#"," "," ","$","#"," ","$"," "," "," ","#"," "," ","#"," ","#" },
     { "#","#"," ","#"," "," "," ","#"," ","#"," "," "," "," ","#","$","#"," "," "," "," "," "," ","#","#","#"," "," "," "," ","#","#" },
     { "#","$","#"," "," ","#"," "," "," ","#"," ","#"," "," "," ","#","#"," ","#","#","$","#"," "," ","$"," ","#","#","#","#"," ","#" },
     { "#"," "," ","$"," ","#"," "," ","$"," "," "," "," ","#"," "," ","#"," "," "," "," "," "," ","#"," "," "," ","#","$"," "," ","#" },
     { "#"," "," ","#"," ","$"," "," ","#"," "," "," "," "," "," "," ","#"," "," ","#"," "," "," ","#"," ","#"," "," ","$"," "," ","#" },
     { "#","#"," ","#","#","#","#","#","#","#","#","#","#"," "," ","#","#"," ","$","#"," ","#"," "," "," "," ","#"," ","#"," "," ","#" },
     { "#"," "," "," "," "," "," "," "," ","#"," ","$","#"," "," "," ","#"," "," ","#","$"," "," ","$"," "," "," "," "," "," ","#","#" },
     { "#"," "," "," "," "," "," ","#"," "," "," ","#"," "," ","#"," ","#","#","#","#","#","#","#","#","#"," "," ","#"," ","#","$","#" },
     { "#","$"," ","#"," "," "," "," "," "," ","#"," "," "," ","#","$","#"," "," "," "," "," "," "," "," ","#","#"," "," "," "," ","#" },
     { "#"," "," "," ","#"," "," ","#","$"," "," ","#","#","#","$","$","#"," "," ","#","#","#","#"," "," "," ","#"," "," ","#","#","#" },
     { "#"," "," "," ","#"," ","#","$","$"," "," ","$"," "," "," ","#","#"," ","#","#","$"," ","#"," ","$"," ","#"," "," ","#","$","#" },
     { "#"," ","$","#"," ","#","$"," "," ","$","$","#"," "," "," ","#","#"," "," ","#"," "," ","#","#","#","#","#"," "," "," "," ","#" },
     { "#"," "," "," "," ","#","#"," "," "," "," "," "," ","#","$"," ","#"," "," ","#"," "," ","$","$","#","$","#","#","#"," "," ","#" },
     { "#","$"," ","#"," ","#"," "," "," "," "," "," "," "," ","#"," ","#","#"," ","#"," "," ","#","#"," "," ","#"," "," "," "," ","#" },
     { "#"," "," "," "," "," "," ","#","#","#"," ","#"," "," "," "," ","#"," "," ","#","$","$"," "," "," "," "," "," "," ","$","#","#" },
     { "#","$","#"," "," "," ","#"," "," "," ","$"," "," ","#"," ","#","#"," "," ","#"," "," ","#"," ","#"," ","#"," ","#","$"," ","#" },
     { "#","#","$"," ","#"," "," ","$","#","#"," ","#"," "," ","#"," ","$"," ","$","$"," "," "," "," ","#","#","#"," ","#"," "," ","#" },
     { "#","$"," "," "," ","#"," "," ","$"," ","#"," "," "," ","$"," ","#"," ","#"," "," ","#"," "," ","$"," "," "," ","$"," ","$","#" },
     { "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#" }

            };

        public void showField()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(field[i, j]);
                }
            }
        }

        public void showMoneyStatistics(int x, int y, int money)
        {
            Console.SetCursorPosition(x, y);

            Console.WriteLine("Монетки: " + money);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {

        Play:
            Console.SetWindowSize(Field.columns, Field.rows + 2);
            Console.SetBufferSize(Field.columns, Field.rows + 2);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Field field = new Field();
            field.showField();

            WriteToFile writeToFile = new WriteToFile();
            LogActs logActs = new LogActs();
            LogExceptions logExceptions = new LogExceptions();

            ConsoleKey key;

            int x = 1, y = 1;
            int money = 0;

            writeToFile.startWriteToFile(x, y, money);
            logActs.startWriteToFile();
            logExceptions.startWriteToFile();

            try
            {
                do
                {
                    Console.Clear();
                    field.showField();
                    field.showMoneyStatistics(0, 27, money);

                    Console.SetCursorPosition(x, y);
                    Console.Write('*');

                    ConsoleKeyInfo info = Console.ReadKey(); //получаем следующий нажатый пользователем символ или функциональную клавишу
                    key = info.Key;// Возвращает клавишу консоли, представленную текущим объектом ConsoleKeyInfo.

                    if (key == ConsoleKey.LeftArrow)
                    {
                        logActs.writeToFileKey(key);

                        if (field.field[y, x - 1] == "#")
                        {
                            ++x;
                            --x;

                            throw new WallExeption();
                        }
                        else
                        {
                            --x;

                            writeToFile.writeToFile(x, y, money);
                        }
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        logActs.writeToFileKey(key);

                        if (field.field[y, x + 1] == "#")
                        {
                            --x;
                            ++x;

                            throw new WallExeption();
                        }
                        else
                        {
                            ++x;

                            writeToFile.writeToFile(x, y, money);
                        }
                    }
                    else if (key == ConsoleKey.UpArrow)
                    {
                        logActs.writeToFileKey(key);

                        if (field.field[y - 1, x] == "#")
                        {
                            ++y;
                            --y;

                            throw new WallExeption();
                        }
                        else
                        {
                            --y;

                            writeToFile.writeToFile(x, y, money);
                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        logActs.writeToFileKey(key);

                        if (field.field[y + 1, x] == "#")
                        {
                            --y;
                            ++y;

                            throw new WallExeption();
                        }
                        else
                        {
                            ++y;

                            writeToFile.writeToFile(x, y, money);
                        }
                    }
                    else
                    {
                        logActs.writeToFileKey(key);

                        throw new KeyExeption();
                    }
                    if (field.field[y, x] == "$")
                    {
                        ++money;

                        field.field[y, x] = " ";

                        logActs.writeToFileMoneyandCoorditants(x, y, money);

                    }

                } while (money != Field.maxMoney);

                writeToFile.endWriteToFile(x, y, money);
                logActs.endWriteToFile();
                logExceptions.endWriteToFile();

                Console.Clear();

                Console.SetCursorPosition(Field.rows / 2 - 7, 13);
                Console.WriteLine("Вы собрали все монетки!");

                Console.SetCursorPosition(Field.rows / 2 - 3, 15);
                Console.WriteLine("Поздравляю!");

                Console.SetCursorPosition(0, 27);
            }
            catch (KeyExeption ex)
            {
                logExceptions.KeyExceptions(ex);

                Console.Clear();

                Console.SetCursorPosition(Field.rows / 2 - 7, 11);
                Console.WriteLine("Вы нажали не ту кнопку(");

                Console.SetCursorPosition(Field.rows / 2 - 7, 13);
                Console.WriteLine("Вы собрали " + money + " / " + Field.maxMoney + " монеток");

                Console.SetCursorPosition(Field.rows / 2 - 8, 15);
                Console.WriteLine("Попробуйте сыграть еще раз");

                Console.SetCursorPosition(0, 27);

                writeToFile.endWriteToFileWithExecption(x, y, money);
                logActs.endWriteToFileWithExecption();
                logExceptions.endWriteToFileWithException();
            }
            catch (WallExeption ex)
            {
                logExceptions.WallExceptions(ex);

                Console.Clear();

                Console.SetCursorPosition(Field.rows / 2 - 7, 11);
                Console.WriteLine("Вы врезалсь в стенку(");

                Console.SetCursorPosition(Field.rows / 2 - 7, 13);
                Console.WriteLine("Вы собрали " + money + " / " + Field.maxMoney + " монеток");

                Console.SetCursorPosition(Field.rows / 2 - 8, 15);
                Console.WriteLine("Попробуйте сыграть еще раз");

                Console.SetCursorPosition(0, 27);

                writeToFile.endWriteToFileWithExecption(x, y, money);
                logActs.endWriteToFileWithExecption();
                logExceptions.endWriteToFileWithException();
            }

        OneMoreTime:

            Thread.Sleep(2000);

            Console.Clear();

            Console.SetCursorPosition(Field.rows / 2 - 6, 13);
            Console.WriteLine("Играть еще раз? (y/n)");

            Console.SetCursorPosition(Field.rows / 2 + 2, 15);

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "y": goto Play;
                case "n":
                    Console.SetCursorPosition(Field.rows / 2 - 11, 15);
                    Environment.Exit(0);

                    break;
                default:
                    Console.Clear();

                    Console.SetCursorPosition(Field.rows / 2 - 2, 13);
                    Console.WriteLine("Неверный ввод");

                    Console.SetCursorPosition(0, 27);

                    Thread.Sleep(500);

                    goto OneMoreTime;
            }
        }
    }

}
