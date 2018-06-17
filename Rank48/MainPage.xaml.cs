using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rank48.Models;
using Xamarin.Forms;

namespace Rank48
{
    public partial class MainPage : ContentPage
    {
        Task initTask;

        public MainPage()
        {
            InitializeComponent();

            initTask = Task.Run(async () =>
            {
                await Produce48Manager.Instance.InitializeAsync();
            });
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await initTask;

            var manager = Produce48Manager.Instance;
            var week1Rank = manager.Ranking["1"].Ranks;
            listView.ItemsSource = week1Rank;
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = sender as ListView;
            listView.SelectedItem = null;

            if (e.SelectedItem is Rank rank)
            {
                var trainee = rank.Trainee;
                DisplayAlert("", trainee.Name, "OK");
            }
        }
    }
}
