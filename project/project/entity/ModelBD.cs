namespace project.entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelBD : DbContext
    {
        public ModelBD()
            : base("name=ModelBD")
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<Commande> Commande { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.Categorie)
                .IsFixedLength();

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Commande)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.FullName)
                .IsFixedLength();

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.Pwd)
                .IsFixedLength();

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.Profil)
                .IsFixedLength();
        }
    }
}
