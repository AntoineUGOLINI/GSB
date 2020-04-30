using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GSB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Antibiotiques : ContentPage
    {
        public Categorie categorie;
        public String libelle;
       
        //public Antibiotiques(Categorie laCategorie)
        //{
          //  InitializeComponent();

            //categorie = laCategorie;
        //}
        public Antibiotiques(String leLibelle)
        {
            InitializeComponent();
            libelle = leLibelle;
        }
       
           private void ContentPage_Appearing(object sender, EventArgs e)
        {

            lvAntibiotiques.ItemsSource = DataAntibio.getAntibiotiquesUnLibelle(libelle).ToList();
        }
        //private void ContentPage_Appearing(object sender, EventArgs e)
       // {
         //   lvAntibiotiques.ItemsSource = DataAntibio.getAntibiotiquesUneCateg(categorie).ToList();
        //}

        private void lvAntibiotiques_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Antibio antibio = lvAntibiotiques.SelectedItem as Antibio;
            if(antibio is AntibioParKilo)
            {
                stackPoids.IsVisible = true;
                
            }
            else
            {
                stackPoids.IsVisible = false;
            }

            Button.IsVisible = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (lvAntibiotiques.SelectedItem != null)
            {
                bool kilosSaisi = false;
                Antibio antibio = lvAntibiotiques.SelectedItem as Antibio;
                if(antibio is AntibioParKilo)
                {
                    if(inpPoids.Text != null)
                    {
                        kilosSaisi = true;
                    }
                }
                else
                {
                    kilosSaisi = true;
                }
                if (kilosSaisi)
                {
                    int nombreParJour = antibio.getNombre();
                    if(antibio is AntibioParKilo)
                    {
                        AntibioParKilo d = (AntibioParKilo)antibio;
                        txtResult.Text = "Il faut la quantité de :" + (d.getDoseKilo() * Convert.ToInt32(inpPoids.Text)).ToString() + " mg "+nombreParJour.ToString()+" fois par jour";
                    }
                    else
                    {
                        AntibioParPrise d = (AntibioParPrise)antibio;
                        txtResult.Text = "Il faut la quantité de :" + (d.getDosePrise()).ToString() + " mg " + nombreParJour.ToString() + " fois par jour";
                    }
                }
                else
                {
                    txtResult.Text = "Veuillez saisir le nombre de kilos";
                }
            }
            else
            {
               txtResult.Text = "Veuillez choisir un antibiotique";
            }
        }
    }
}