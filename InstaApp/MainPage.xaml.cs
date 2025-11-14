using System.Collections.ObjectModel;

using InstaApp;

namespace InstaApp
{
    // Tworzenie modelu
    public class Post
    {
        public string Nickname { get; set; } = "";
        public string Avatar { get; set; } = "";
        public string Date { get; set; } = "";
        public string Picture { get; set; } = "";
        public string Likes { get; set; } = "";
        public string Comments { get; set; } = "";
        public string Description { get; set; } = "";

    }

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Post> data { get; set; }

        public MainPage()
        {
            // Ładowanie danych z pliku 
            LoadData();
            InitializeComponent();

            ListaPostow.ItemsSource = data; // Bindowanie z poziomu
        }

        async Task LoadData()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("posty.txt");
            using var reader = new StreamReader(stream);

            var contents = reader.ReadToEnd();

            // Zamiana zawartości na tablice wierszy z pliku
            string[] rows = contents.Split("\n"); // Ładowanie danych z plików
            foreach(string row in rows)
            {
                string[] dane = row.Split('\n');
                data.Add(new Post
                {
                    Nickname = dane[0],
                    Avatar = dane[1],
                    Date = dane[2],
                    Picture = dane[3],
                    Likes = dane[4],
                    Comments = dane[5],
                    Description = dane[6]
                });
            }

        }
    }
}
