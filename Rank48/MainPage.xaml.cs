using System.Collections.Generic;
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

            picker.ItemDisplayBinding = new Binding
            {
                StringFormat = "Week {0}"
            };
        }

        async void OnCreate()
        {
            var manager = Produce48Manager.Instance;

            listView.IsRefreshing = true;

            await Task.Run(async () =>
            {
                await manager.InitializeAsync();
            });

            listView.IsRefreshing = false;

            var weeks = manager.Ranking.Keys.ToList();
            picker.ItemsSource = weeks;
            picker.SelectedIndex = 0;
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;

            if (e.SelectedItem is Rank rank)
            {
                var trainee = rank.Trainee;

                string week = picker.SelectedItem as string;
                int ranking = trainee.GetRankingUpdatedCount(week);
                string text = ranking > 0 ? $"+{ranking}" : ranking.ToString();

                DisplayAlert(trainee.Name, /*trainee.AWord*/text, "OK");
            }
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var manager = Produce48Manager.Instance;

            var item = manager.Ranking[picker.SelectedItem as string];
            var ranks = item.Ranks;

            listView.ItemsSource = ranks;
        }
    }
}
