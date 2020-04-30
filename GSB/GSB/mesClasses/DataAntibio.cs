using System;
using System.Collections.Generic;
using System.Text;

namespace GSB
{
    public static class DataAntibio
    {
        static private List<Antibio> lesAntibiotiques;
        static private List<Categorie> lesCategories;
       

        static public void initialiser()
        {
            DataAntibio.lesCategories = new List<Categorie>();
            Categorie uneCategorie1 = new Categorie("Aminoglycosides");
            DataAntibio.lesCategories.Add(uneCategorie1);
            Categorie uneCategorie2 = new Categorie("AntiFongiques");
            DataAntibio.lesCategories.Add(uneCategorie2);
            Categorie uneCategorie3 = new Categorie("Antiviraux");
            DataAntibio.lesCategories.Add(uneCategorie3);
            Categorie uneCategorie4 = new Categorie("Carbapénèmes");
            DataAntibio.lesCategories.Add(uneCategorie4);
            Categorie uneCategorie5 = new Categorie("Céphalosporines");
            DataAntibio.lesCategories.Add(uneCategorie5);
            Categorie uneCategorie6 = new Categorie("Macrolides");
            DataAntibio.lesCategories.Add(uneCategorie6);
            Categorie uneCategorie7 = new Categorie("Pénicillines");
            DataAntibio.lesCategories.Add(uneCategorie7);
            Categorie uneCategorie8 = new Categorie("Quinolones");
            DataAntibio.lesCategories.Add(uneCategorie8);
            Categorie uneCategorie9 = new Categorie("Sulfamidés");
            DataAntibio.lesCategories.Add(uneCategorie9);
            Categorie uneCategorie10 = new Categorie("Autres");
            DataAntibio.lesCategories.Add(uneCategorie10);

            DataAntibio.lesAntibiotiques = new List<Antibio>();
            AntibioParKilo unAntibioParKilo;
            unAntibioParKilo = new AntibioParKilo("Amiklin", "mg", uneCategorie1, 15, 20);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);
            unAntibioParKilo = new AntibioParKilo("Garamycine", "mg", uneCategorie1, 6, 24);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);

            AntibioParPrise unAntibioParPrise;
            unAntibioParPrise = new AntibioParPrise("WH", "mg", uneCategorie1, 15, 20);
            DataAntibio.lesAntibiotiques.Add(unAntibioParPrise);
            unAntibioParPrise = new AntibioParPrise("YO", "mg", uneCategorie1, 6, 24);
            DataAntibio.lesAntibiotiques.Add(unAntibioParPrise);
        }
        static public List<Categorie> getLesCategories()
        {
            return DataAntibio.lesCategories;
        }
      static public void SetLesCategories(List<Categorie> LesCateg)
        {
            lesCategories = LesCateg;
        }
        static public void SetLesAntiobiotiques(List<Antibio> LesAnt)
        {
            lesAntibiotiques = LesAnt;
        }
        static public List<Antibio> getAntibiotiquesUnLibelle(String libC)
        {
            List<Antibio> liste = new List<Antibio>();
            foreach (Antibio a in DataAntibio.lesAntibiotiques)
            {
                if (a.getCategorie().getLibelle() == libC)
                {
                    liste.Add(a);
                }
            }
            return liste;
        }
        /*static public int getNbAntibioParKilo()
        {
            int nbAnti = 0;
            foreach(Antibio a in lesAntibiotiques)
            {
                if(a is AntibioParKilo)
                {
                    nbAnti = nbAnti + 1;
                }
            }
            return nbAnti;
        }
       /* static public List<Antibio> getAntibiotiquesUneCateg(Categorie c)
        {
            List<Antibio> liste = new List<Antibio>();
            foreach (Antibio a in DataAntibio.lesAntibiotiques)
            {
                if (a.getCategorie().getLibelle() == c.getLibelle())
                {
                    liste.Add(a);
                }
            }
            return liste;
        }*/
    }
}
