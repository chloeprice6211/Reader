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

        event moneyf dmoney;
        DispatcherTimer timer;
        int countbook;
        int money;
        int countbuy;
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
        {        InitializeComponent();
            StreamReader SR = new(@"../../../userData/balance.txt");

     
            money = System.Convert.ToInt32(SR.Read());
            money = 101;
            SR = new(@"../../../userData/countbook.txt");
            countbook = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/countbuy.txt");
            countbuy = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/time.txt");
            time = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/visite.txt");
            visite = System.Convert.ToInt32(SR.Read());
            kesh1.Content = money;
              timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            moneyf dmoney = proverka1;
          

        }
        void timer_Tick(object sender, EventArgs e)
        {
            proverka1();

        }
       void proverka1()
        {
            if (System.Convert.ToInt64(kesh1.Content) >= System.Convert.ToInt64(kesh2.Content))
            {
                kesh1.Content = 250;

            }

        }
        void proverka2()
        {
            if (System.Convert.ToInt64(start1.Content) >= System.Convert.ToInt64(start2.Content))
            {
                start2.Content = 3;


            }

        }
        ~Achievement()
        {
            timer.Stop();
        }


    }
}
