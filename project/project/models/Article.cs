using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
    class Article
    {
        private static int nbreArticle;
        private int id;
        private int reference;
        private string libelle;
        private int stock;
        private int prix;
        private string categorie;

        public Article()
        {
            Id = ++nbreArticle;
        }

        public int Id { get => id; set => id = value; }
        public int Reference { get => reference; set => reference = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Prix { get => prix; set => prix = value; }
        public string Categorie { get => categorie; set => categorie = value; }
    }
}
