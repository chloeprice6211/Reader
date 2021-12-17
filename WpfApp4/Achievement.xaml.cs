using System.Windows;
using System.IO;
using System;
using System.Windows.Threading;

namespace reader
{
    
    /// <summary>
    /// Interaction logic for Achievement.xaml
    /// </summary>
    public partial class Achievement : Window
    {
        delegate void moneyf();
        int second;
        event moneyf dmoney;
        DispatcherTimer timer;
        int countbook;
        int money;
        int countbuy;
        int countmoney;
        int time;
        int visite;


        public int Countbook
        {
            get
            {
                return countbook;
            }
            set
            {
                countbook = value;
            }
        }
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
        public int Countbuy
        {
            get
            {
                return countbuy;
            }
            set
            {
                countbuy = value;
            }
        }
        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public int Visite
        {
            get
            {
                return visite;
            }
            set
            {
                visite = value;
            }
        }

        //...


        public Achievement()
        {
            InitializeComponent();
            StreamReader SR = new(@"../../../userData/balance.txt");


            money = int.Parse(SR.ReadLine());

            SR = new(@"../../../userData/countbook.txt");
            countbook = int.Parse((SR.ReadLine()));
            SR = new(@"../../../userData/countbuy.txt");
            countbuy = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/time.txt");
            time = int.Parse(SR.ReadLine());
            SR = new(@"../../../userData/visite.txt");
            visite = System.Convert.ToInt32(SR.Read());

            SR = new(@"../../../userData/countmoney.txt");
            countmoney = int.Parse(SR.ReadLine());

            timme1.Content = converter(System.Convert.ToString(time));
            kesh1.Content = countmoney.ToString();
            start1.Content = converter(countbook.ToString());
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            moneyf dmoney = proverka1;
            second = 0;


        }
        private string converter(string numbers)
        {
            string text = "";
            for (int i = numbers.Length - 1; i > -1; i--)
            {
                text = text + numbers[i];

            }
            return text;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            proverka1();
            proverka2();

            second++;
            proverka4();
        }
        void proverka2()
        {
            if (int.Parse(kesh1.Content.ToString()) >= int.Parse(kesh2.Content.ToString()))
            {
                ///  MessageBox.Show(money.ToString());
                kesh2.Content = System.Convert.ToString(System.Convert.ToInt32(int.Parse(kesh2.Content.ToString()) * 1.7));
                kesh0.Content = kesh2.Content;

            }

        }
        void proverka1()
        {
            if (int.Parse(start1.Content.ToString()) >= int.Parse(start2.Content.ToString()))
            {
                start2.Content = System.Convert.ToString(System.Convert.ToInt32(int.Parse(start2.Content.ToString()) * 2));


            }

        }
        void proverka3()
        {
            if (System.Convert.ToInt64(start1.Content) >= System.Convert.ToInt64(start2.Content))
            {
                start2.Content = 3;


            }

        }
        void proverka4()
        {
            if (second == 10)
            {
                second = 0;
                time++;
                // MessageBox.Show(time.ToString());

                // MessageBox.Show(time.ToString()); 
                StreamReader SR = new(@"../../../userData/time.txt");

                int buf = int.Parse(SR.ReadLine());
                SR.Close();

                buf++;
                timme1.Content = converter(System.Convert.ToString(buf));
                StreamWriter SW = new(@"../../../userData/time.txt");
                SW.Write(converter(System.Convert.ToString(buf)));
                SW.Close();
            }

        }
        ~Achievement()
        {
            timer.Stop();
        }


    }
}