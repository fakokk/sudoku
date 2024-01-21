using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            HOUSE.Image = Image.FromFile(@"D:\homework\ta\lab11_kla\WindowsFormsApp1\house.jpg");
            VADIMKA.Image = Image.FromFile(@"D:\homework\ta\lab11_kla\WindowsFormsApp1\vadim.jpg");

            HOUSE.SizeMode = PictureBoxSizeMode.Zoom;

            VADIMKA.SizeMode = PictureBoxSizeMode.Zoom;
            VADIMKA.Visible = false;

            //устанавливаем ширину клетки судоку
            SUDOKU.Width = 450;
            SUDOKU.Height = 450;

            SUDOKU.RowCount = 9;
            SUDOKU.ColumnCount = 9;

            numbers_storage.RowCount = 81;
            numbers_storage.ColumnCount = 3;

            numbers_storage.RowTemplate.Height = 50;

            SUDOKU.RowTemplate.Height = 50;

            for (int i = 0; i < 9; i++) 
            {
                SUDOKU.Columns[i].Width = 50;
            }

            for (int i = 0; i < 3; i++)
            {
                numbers_storage.Columns[i].Width = 50;
            }


            SUDOKU.ColumnHeadersVisible = false;
            SUDOKU.RowHeadersVisible = false;

            numbers_storage.ColumnHeadersVisible = false;
            numbers_storage.RowHeadersVisible = false;

            foreach (DataGridViewColumn c in SUDOKU.Columns)
            {
                SUDOKU.DefaultCellStyle.Font = new Font("Verdana", 16);
            }

            my_sudoku.States_Sud_PULL();

            print_sudoku();

            timer.Interval = 1; //интервал между срабатываниями 1000 миллисекунд
            timer.Tick += new EventHandler(timer_Tick); //подписываемся на события Tick
            //timer.Start();

        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int timerCounter = 0; //счётчик для таймера
        //обработчик события Tick

        VADIMKA_mur vadik = new VADIMKA_mur();

        bool chislo = false;

        //индексы очищаемой муравьем ячейки
        int x, y;
        
        public void return_index()
        {
            var _random = new Random();

            //если число еще не выбрано

            for (int i = 0; (chislo == false); i++)
            {
                //рандомим число
                int x1 = _random.Next(0, 8);
                int y1 = _random.Next(0, 8);

                //если эта ячейка не пустая
                //string str = SUDOKU.Rows[y].Cells[x].Value.ToString();

                //if ( (SUDOKU.Rows[y].Cells[x].Value.ToString() == String.Empty) & (my_sudoku.array_states[x, y] == SUDOKU_RESH.States_Sud.s12) & (chislo == false)&(SUDOKU.Rows[x1].Cells[y1].Style.BackColor == Color.YellowGreen) )
                //{
                //    continue;
                //}

                if ((my_sudoku.array_states[x1, y1] != SUDOKU_RESH.States_Sud.s12) & (chislo == false) & (SUDOKU.Rows[x1].Cells[y1].Style.BackColor != Color.YellowGreen))
                {

                    //запоминаем эти числа
                    x = x1;
                    y = y1;

                    SUDOKU.Rows[y].Cells[x].Style.BackColor = Color.Aqua;

                    label1.Text = x1.ToString();
                    label2.Text = y1.ToString();

                    chislo = true;

                    vadik.State = VADIMKA_mur.States.Go_to_Num;
                    vadik_state.Text = vadik.State.ToString();
                }
            }
            //3, 4, закончили упражнение
        }
        
        //изменение координат
        int dx, dy;
        int x_max, y_max;
        int xx, yy;

        //процедура которая вычисляет изменения координат муравья раз в тик (постоянно)
        public void return_coordinat()
        {
            x_max = Convert.ToInt32(x * 50);
            y_max = Convert.ToInt32(y * 50);

            dx = Convert.ToInt32((x_max + xx) * 0.01);
            dy = Convert.ToInt32((y_max + yy) * 0.01);

        }

        //чтобы вадик бежал домой
        public void update_coordinat() 
        {
            x_max = Convert.ToInt32(HOUSE.Left + 30);
            y_max = Convert.ToInt32(HOUSE.Top + 30);

            dx = Convert.ToInt32(x_max * 0.01);
            dy = Convert.ToInt32(y_max * 0.01);

        }

        void timer_Tick(object sender, EventArgs e)
        {
            //В текстбокс выводим значение timerCounter увеличенное на 1
            this.text_timer.Text = (++timerCounter).ToString();

            //если сейчас вадик дома
            if (vadik.State == VADIMKA_mur.States.AtHome)
            {
                VADIMKA.Visible = true;
                //выбираем ячейку которую будем заполнять
                //индексы хранятся в глобальных x, y

                return_index();

                //теперь посчитаем изменение координат
                xx = VADIMKA.Left;
                yy = VADIMKA.Top;

                return_coordinat();

                //все нужные данные есть
                //вадимка готов бежать к листочку

                vadik.State = VADIMKA_mur.States.Go_to_Num;

                vadik_state.Text= vadik.State.ToString();

            }
            else
            //если вадик бежит к листу
            if (vadik.State == VADIMKA_mur.States.Go_to_Num)
            {
                //меняем координаты
                VADIMKA.Top -= dy;
                VADIMKA.Left -= dx;

                //если уже рядом с нужной ячейкой
                if ((VADIMKA.Top <= y_max)&(VADIMKA.Left <= x_max))
                {

                    vadik.State = VADIMKA_mur.States.Num;

                    VADIMKA.Top = y_max + 13;
                    VADIMKA.Left = x_max + 13;

                    vadik_state.Text = vadik.State.ToString();
                }
                else
                if ((VADIMKA.Top <= y_max) || (VADIMKA.Left <= x_max))
                {
                    if (VADIMKA.Top <= y_max)
                    {
                        dy = 0;
                    }
                    else
                    if
                    (VADIMKA.Left <= x_max)
                    {
                        dx = 0;
                    }
                }
            }
            else
            //если вадик добежал до листа
            if (vadik.State == VADIMKA_mur.States.Num)
            {

                //запоминаем число которое нужно забрать
                vadik.number = SUDOKU.Rows[y].Cells[x].Value.ToString();

                SUDOKU.Rows[y].Cells[x].Value = "";
                my_sudoku.array_states[x, y] = SUDOKU_RESH.States_Sud.s12;

                //можно отправлять вадика домой
                vadik.State = VADIMKA_mur.States.Go_to_home;
                vadik_state.Text = vadik.State.ToString();

                SUDOKU.Rows[y].Cells[x].Style.BackColor = Color.YellowGreen;

                update_coordinat();

                timer.Start();
            }
            else 
            //вадик стащил число и понес его домой
            if (vadik.State == VADIMKA_mur.States.Go_to_home)
            {
                //меняем координаты
                VADIMKA.Top += dy;
                VADIMKA.Left += dx;

                //если уже рядом с домом
                if ((VADIMKA.Top >= y_max) & (VADIMKA.Left >= x_max))
                {
                    vadik.State = VADIMKA_mur.States.AtHome_with_number;
                    vadik_state.Text = vadik.State.ToString();

                    VADIMKA.Visible = false;
                }
                else
                if ((VADIMKA.Top >= y_max) || (VADIMKA.Left >= x_max))
                {
                    if (VADIMKA.Top >= y_max)
                    {
                        dy = 0;
                    }
                    else
                    if
                    (VADIMKA.Left >= x_max)
                    {
                        dx = 0;
                    }
                }
            }
            else
            //вадик пришел домой с числом
            if (vadik.State == VADIMKA_mur.States.AtHome_with_number)
            {
                

                vadik.State = VADIMKA_mur.States.AtHome;
                vadik_state.Text = vadik.State.ToString();

                //теперь занесем число в наш список
                //если это первое число

                //numbers_storage.RowCount = 81;
                //numbers_storage.ColumnCount = 3;

                string s = "[" + x + ", " + y + "]";

                numbers_storage[0, counter_numbers].Value = counter_numbers;
                numbers_storage[1, counter_numbers].Value = s;
                numbers_storage[2, counter_numbers].Value = vadik.number;



                //все обнуляем чтобы не было косяков
                dx = 0; dy = 0;
                x_max = 0; y_max = 0;
                xx = 0; yy = 0;
                x = 0; y = 0;

                chislo = false;


                counter_numbers++;


            }

        }

        int counter_numbers = 0;

        //выпускаем вадимку
        private void button2_Click(object sender, EventArgs e)
        {
            VADIMKA.Visible = true;
            timer.Start();

            counter_numbers = 0;
        }

        public class VADIMKA_mur
        {
            public VADIMKA_mur() { State = States.AtHome; }

            public enum States { AtHome, Go_to_Num, Num, Go_to_home, AtHome_with_number };

            //текущее состояние муравья
            public States State;

            //число которое стащил вадик из судоку
            public string number;

            public void change_state(States s0)
            {
                if (s0 == States.AtHome)
                {
                    State = States.Go_to_Num;
                }
                if (s0 == States.Go_to_Num)
                {
                    State = States.Num;
                }
                if (s0 == States.Num)
                {
                    State = States.Go_to_home;
                }
                if (s0 == States.Go_to_home)
                {
                    State = States.AtHome;
                }
            }



        }


        //кнопка решить судоку
        private void button1_Click(object sender, EventArgs e)
        {
            reshenie_sudoku();
        }

        SUDOKU_RESH my_sudoku = new SUDOKU_RESH();


        public void reshenie_sudoku()
        {
            //int horizontal, vertical, square;

            List<int> flags = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<int> flags_h = new List<int>();
            List<int> flags_v = new List<int>();
            List<int> flags_s = new List<int>();

            //листы для попарного сравнения

            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            List<int> l3 = new List<int>();

            List<int> l1v = new List<int>();
            List<int> l1s = new List<int>();
            List<int> l2h = new List<int>();
            List<int> l2s = new List<int>();
            List<int> l3h = new List<int>();
            List<int> l3v = new List<int>();

            List<int> l_res = new List<int>();


            //проверяем каждую клеточку, чтобы совпало три условия
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    //j и i местами не менять!!!!
                    if (my_sudoku.array_states[j, i] == my_sudoku.my_unique_state)
                    {
                        //выделяем проверяемую ячейку
                        SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Green;

                        //проверка вертикали
                        for (int c = 0; c < 9; c++)
                        {
                            flags_v.Add(my_sudoku.translate_to_int(my_sudoku.array_states[j, c]));
                        }

                        //проверка горизонтали
                        for (int c = 0; c < 9; c++)
                        {
                            flags_h.Add(my_sudoku.translate_to_int(my_sudoku.array_states[c, i]));
                        }

                        //проверка квадратика
                        //int a = id_square(i, j);

                        int k = 0, l = 0;

                        if ((j < 3) & (i < 3)) { k = 3; l = 3; }
                        else
                        if ((j < 6) & (i < 3)) { k = 6; l = 3; }
                        else
                        if ((j < 9) & (i < 3)) { k = 9; l = 3; }
                        else

                        if ((j < 3) & (i < 6)) { k = 3; l = 6; }
                        else
                        if ((j < 6) & (i < 6)) { k = 6; l = 6; }
                        else
                        if ((j < 9) & (i < 6)) { k = 9; l = 6; }
                        else

                        if ((j < 3) & (i < 9)) { k = 3; l = 9; }
                        else
                        if ((j < 6) & (i < 9)) { k = 6; l = 9; }
                        else
                        if ((j < 9) & (i < 9)) { k = 9; l = 9; }

                        //смотрим на конкретный квадратик где обозревается ячейка

                        for (int ll = l - 3; ll < l; ll++)
                        {
                            for (int kk = k - 3; kk < k; kk++)
                            {
                                flags_s.Add(my_sudoku.translate_to_int(my_sudoku.array_states[kk, ll]));
                            }
                        }
                            
                        //теперь сравниваем листы чтобы получить элементы которых нет в общем списке
                        l1 = LIST_ENABLED(flags, flags_h);
                        l2 = LIST_ENABLED(flags, flags_v);
                        l3 = LIST_ENABLED(flags, flags_s);

                        //здесь нужно менять алгоритм
                        //попарно сравниваем места где также могут быть повторы
                        l1v = LIST_ENABLED(l1, flags_v);
                        l1s = LIST_ENABLED(l1, flags_s);

                        l2h = LIST_ENABLED(l2, flags_h);
                        l2s = LIST_ENABLED(l2, flags_s);

                        l3h = LIST_ENABLED(l3, flags_h);
                        l3v = LIST_ENABLED(l3, flags_v);

                        int counter = 0;
                        int coouter_big = 0;

                        //выявляем то самое особое число
                        for (int b = 0; b < l1v.Count(); b++)
                        {
                            for (int c = 0; c < l1s.Count(); c++)
                            {
                                if (l1v[b] == l1s[c])
                                {
                                    counter++;
                                }
                                //если это число встретилось во всех пяти списках, значит оно нам надо
                                if ((counter == 5))
                                {
                                    l_res.Add(l1v[b]);
                                    //счетчик таких подходящих чисел - для исключения ошибки
                                    coouter_big++;
                                }

                            }

                            for (int c = 0; c < l2h.Count(); c++)
                            {
                                if (l1v[b] == l2h[c])
                                {
                                    counter++;
                                }

                                if (counter == 5)
                                {
                                    l_res.Add(l1v[b]);
                                    coouter_big++;
                                }
                            }

                            for (int c = 0; c < l2s.Count(); c++)
                            {
                                if (l1v[b] == l2s[c])
                                {
                                    counter++;
                                }

                                if (counter == 5)
                                {
                                    l_res.Add(l1v[b]);
                                    coouter_big++;
                                }

                            }
                            for (int c = 0; c < l3h.Count(); c++)
                            {
                                if (l1v[b] == l3h[c])
                                {
                                    counter++;
                                }

                                if (counter == 5)
                                {
                                    l_res.Add(l1v[b]);
                                    coouter_big++;
                                }

                            }

                            for (int c = 0; c < l3v.Count(); c++)
                            {
                                if (l1v[b] == l3v[c])
                                {
                                    counter++;
                                }
                                if (counter == 5)
                                {
                                    l_res.Add(l1v[b]);
                                    coouter_big++;
                                }

                            }

                        }

                        //элементы которые нигде не повторяются
                        //if ((coouter_big >0 ) & (l_res[1] != 12) )
                        //& (my_sudoku.translate_to_int(my_sudoku.array_states[i, j]) == 12)
                        {
                            my_sudoku.array_states[j, i] = my_sudoku.translate_to_state(l_res[0]);
                            SUDOKU.Rows[i].Cells[j].Value = my_sudoku.translate_to_int(my_sudoku.array_states[j,i]);
                            SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }

                        flags_h.Clear();
                        flags_v.Clear();
                        flags_s.Clear();

                        l1.Clear();
                        l2.Clear();
                        l3.Clear();

                        l1v.Clear();
                        l1s.Clear();
                        l2h.Clear();
                        l2s.Clear();
                        l3h.Clear();
                        l3v.Clear();

                        l_res.Clear();
                    }
                }

        }

        public List<int> LIST_ENABLED (List<int> l1, List<int> l2)
        {
            List<int> l3 = new List<int>();

            int c = 0;

            for (int i = 0; i < l1.Count; i++) 
            {
                for (int j = 0;  j < l2.Count; j++)
                {
                    if (l1[i] == l2[j])
                        c++;
                    //если вышло так что на последнем шаге есть единственный уникальный элемент
                    if (( j == l2.Count - 1)&(c == 0))
                    {
                        l3.Add(l1[i]);
                    }

                }
                c = 0;
            }
            return l3;
        }

        public void print_sudoku()
        {
            for (int i = 0;i < 9;i++) 
            {
                for (int j = 0;j < 9;j++) 
                {
                    if (my_sudoku.Array1[i, j] != 12)
                        SUDOKU[i, j].Value = my_sudoku.Array1[i, j];

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public class SUDOKU_RESH
        {
            public SUDOKU_RESH() { }


            //условие задачи - не решеное судоку
            public int[,] Array1 = { { 12, 5, 7, 12, 2, 3, 12, 1, 6 },
                                        { 1, 4, 12, 7, 12, 6, 8, 12, 2 },
                                        { 12, 3, 6, 9, 1, 8, 12, 5, 4 },

                                        { 5, 8, 1, 12, 9, 7, 6, 12, 3 },
                                        { 12, 6, 12, 5, 8, 4, 12, 9, 12 },
                                        { 4, 12, 2, 6, 12, 12, 5, 7, 8 },

                                        { 9, 2, 12, 12, 6, 5, 12, 8, 7 },
                                        { 3, 12, 5, 8, 12, 2, 1, 12, 12 },
                                        { 12, 1, 8, 12, 7, 12, 4, 2, 5 }
                                    };


            //s12 - клетка ещё пустая
            public enum States_Sud {s1, s2, s3, s4, s5, s6, s7, s8, s9, s12 };

            public States_Sud my_unique_state = States_Sud.s12;

            public States_Sud[,] array_states = { { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },
                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },
                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },

                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },
                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },
                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },

                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },
                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },
                                                  { States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, States_Sud.s12, },};

            public void States_Sud_PULL()
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        array_states[i, j] = translate_to_state(Array1[i, j]);
                    }
                }
                    
            }

            public States_Sud translate_to_state(int a)
            {
                States_Sud state = States_Sud.s12;

                if (a == 1) state = States_Sud.s1;
                if (a == 2) state = States_Sud.s2;
                if (a == 3) state = States_Sud.s3;

                if (a == 4) state = States_Sud.s4;
                if (a == 5) state = States_Sud.s5;
                if (a == 6) state = States_Sud.s6;

                if (a == 7) state = States_Sud.s7;
                if (a == 8) state = States_Sud.s8;
                if (a == 9) state = States_Sud.s9;

                if (a == 12) state = States_Sud.s12;

                return state;
            }

            public int translate_to_int(States_Sud s)
            {
                int state = 0;

                if (s == States_Sud.s1) state = 1;
                if (s == States_Sud.s2) state = 2;
                if (s == States_Sud.s3) state = 3;

                if (s == States_Sud.s4) state = 4;
                if (s == States_Sud.s5) state = 5;
                if (s == States_Sud.s6) state = 6;

                if (s == States_Sud.s7) state = 7;
                if (s == States_Sud.s8) state = 8;
                if (s == States_Sud.s9) state = 9;


                if (s == States_Sud.s12) state = 12;

                return state;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
