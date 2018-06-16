using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            listView.ItemsSource = Produce48Manager.Instance.Trainees.Values;
        }
    }
}
