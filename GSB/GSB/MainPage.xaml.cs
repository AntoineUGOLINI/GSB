using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace GSB
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            recuperation();

        }
        
        public async void recuperation()

        {
            HttpClient wc = new HttpClient();
            HttpResponseMessage reponse = await wc.GetAsync(new Uri("https://gsbapiandroid.000webhostapp.com/API/categories.php", UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<Categorie> unelisteCategories = null;
            unelisteCategories = JsonConvert.DeserializeObject<List<Categorie>>(json);
            DataAntibio.SetLesCategories(unelisteCategories);
            lvCategories.ItemsSource = unelisteCategories.ToList();
            recuperationAntibios();
            uneLCateg = unelisteCategories;

        }
        static public async void recuperationAntibios()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            HttpClient wc = new HttpClient();
            HttpResponseMessage reponse = await wc.GetAsync(new Uri("https://gsbapiandroid.000webhostapp.com/API/AllAntibiotiques.php", UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<Antibio> uneListeAntibios = null;
            uneListeAntibios = JsonConvert.DeserializeObject<List<Antibio>>(json, settings);
            DataAntibio.SetLesAntiobiotiques(uneListeAntibios);


        }
        public List<Categorie> uneLCateg{ get; set; }
       



        //public List<Categorie> lesCategories = DataAntibio.getLesCategories();


        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            //DataAntibio.initialiser();

            //lvCategories.ItemsSource = DataAntibio.getLesCategories().ToList();
           // string NbAntibioParKilo;
          //  NbAntibioParKilo = DataAntibio.getNbAntibioParKilo().ToString();
            //txtNbAntiobioParKilo.Text = NbAntibioParKilo;
        }

        private void lvCategories_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new Antibiotiques(lvCategories.SelectedItem.ToString()));

        }

        private void Barre_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = Barre.Text;
            List<Categorie> suggestions = uneLCateg.Where(c => c.getLibelle().ToLower().Contains(keyword.ToLower())).ToList<Categorie>();
            lvCategories.ItemsSource = suggestions.ToList();
        }
    }
}
