using System;
using System.Collections.Generic;
using Rank48.Models;
using Xamarin.Forms;

namespace Rank48.Cells
{
    public partial class TraineeCell : ViewCell
    {
        public static ImageSource Placeholder = ImageSource.FromFile("placeholder.png");

        public TraineeCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            // get values
            var rank = BindingContext as Rank;
            var trainee = rank.Trainee;
            var agency = trainee.Agency;

            // set rank
            rankLabel.Text =  rank.Ranking.ToString();

            // set trainee
            image.Source = new Uri(trainee.ImageUrl);
            nameLabel.Text = trainee.Name;

            // set agency
            //agencyImage.Source = new Uri(agency.MobileImageUrl);
            agencyLabel.Text = agency.Name;

            // set rank updated count
            string week = MainPage.Instance.CurrentWeek;
            int ranking = trainee.GetRankingUpdatedCount(week);
            string text = ranking > 0 ? $"+{ranking}" : ranking.ToString();
            Color color = ranking > 0 ? Color.Green : Color.Red;

            updatedRankLabel.Text = ranking != 0 ? text : string.Empty;
            updatedRankLabel.TextColor = color;

            base.OnBindingContextChanged();
        }
    }
}
