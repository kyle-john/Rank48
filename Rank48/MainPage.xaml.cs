using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rank48.Models;
using Xamarin.Forms;

namespace Rank48
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            OnCreate();
        }

        async void OnCreate()
        {
            var manager = Produce48Manager.Instance;

            listView.IsRefreshing = true;

            await Task.Run(async () =>
            {
                await manager.InitializeAsync();
            });
            var week1Rank = manager.Ranking["1"].Ranks;
            listView.ItemsSource = week1Rank;

            listView.IsRefreshing = false;
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;

            if (e.SelectedItem is Rank rank)
            {
                var trainee = rank.Trainee;
                DisplayAlert(trainee.Name, trainee.AWord, "OK");
            }
        }
    }
}
