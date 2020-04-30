using System;
using System.Collections.Generic;
using System.Text;

namespace GSB
{
    public class Categorie
    {
       public  String libelle;
        public Categorie(String pLibelle)
        {
            this.libelle = pLibelle;
        }
        public String getLibelle()
        {
            return this.libelle;
        }       
        
        override public string ToString()
        {
            return libelle;
        }
    }

}
