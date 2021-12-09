using System.Windows;
using System.IO;
namespace reader
{
    /// <summary>
    /// Interaction logic for Achievement.xaml
    /// </summary>
    public partial class Achievement : Window
    {
        delegate void moneyf();

        
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

        public Achievement()
        {        InitializeComponent();
            StreamReader SR = new(@"../../../userData/balance.txt");


            money = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/countbook.txt");
            countbook = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/countbuy.txt");
            countbuy = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/time.txt");
            time = System.Convert.ToInt32(SR.Read());
            SR = new(@"../../../userData/visite.txt");
            visite = System.Convert.ToInt32(SR.Read());
            kesh1.Content = money;


            MessageBox.Show(money.ToString());

          


        }
       private void proverka()
        {
          
        }
            


    }
}
