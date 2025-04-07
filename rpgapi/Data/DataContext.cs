using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using rpgapi.models;
using rpgapi.Models;
using rpgapi.Models.Enums;
using rpgapi.Utils;
using RpgApi.Models;


namespace rpgapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Personagem> TB_PERSONAGENS { get; set; }
        public DbSet<Arma> TB_ARMAS { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }
        public DbSet<Habilidade> TB_HABILIDADES { get; set; }
        public DbSet<PersonagemHabilidade> TB_PERSONAGENS_HABILIDADES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGEM");
            modelBuilder.Entity<Arma>().ToTable("TB_ARMAS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Habilidade>().ToTable("TB_HABILIDADES");
            modelBuilder.Entity<PersonagemHabilidade>().ToTable("TB_PERSONAGEM_HABILIDADES");


            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Personagens)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired(false);

            modelBuilder.Entity<Personagem>()
                .HasOne(e => e.Arma)
                .WithOne(e => e.Personagem)
                .HasForeignKey<Arma>(e => e.PersonagemId)
                .IsRequired();

            modelBuilder.Entity<Personagem>().HasData
            (
                new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro, UsuarioId =1 },
                new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro, UsuarioId =1 },
                new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo, UsuarioId =1 },
                new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago, UsuarioId =1 },
                new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro, UsuarioId =1 },
                new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo, UsuarioId =1 },
                new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago, UsuarioId =1 }
            );

            modelBuilder.Entity<Arma>().HasData
            (
                new Arma() { Id = 1, Nome = "arco", Dano = 35,PersonagemId = 1},
                new Arma() { Id = 2, Nome = "arco", Dano = 35,PersonagemId = 2},
                new Arma() { Id = 3, Nome = "arco", Dano = 35,PersonagemId = 3},
                new Arma() { Id = 4, Nome = "arco", Dano = 35,PersonagemId = 4},
                new Arma() { Id = 5, Nome = "arco", Dano = 35,PersonagemId = 5},
                new Arma() { Id = 6, Nome = "arco", Dano = 35,PersonagemId = 6},
                new Arma() { Id = 7, Nome = "arco", Dano = 35,PersonagemId = 7}
            );

            modelBuilder.Entity<PersonagemHabilidade>()
                .HasKey(ph => new {ph.PersonagemId, ph.HabilidadeId});

            modelBuilder.Entity<Habilidade>().HasData
            (
                new Habilidade(){Id=1, Nome="adormecer", Dano=39},
                new Habilidade(){Id=2, Nome="congelar", Dano=41},
                new Habilidade(){Id=3, Nome="hipnotizar", Dano=37}
            );

            modelBuilder.Entity<PersonagemHabilidade>().HasData
            (
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId =1},
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId =2},
                new PersonagemHabilidade() {PersonagemId = 2, HabilidadeId =2},
                new PersonagemHabilidade() {PersonagemId = 3, HabilidadeId =2},
                new PersonagemHabilidade() {PersonagemId = 3, HabilidadeId =3},
                new PersonagemHabilidade() {PersonagemId = 4, HabilidadeId =3},
                new PersonagemHabilidade() {PersonagemId = 5, HabilidadeId =1},
                new PersonagemHabilidade() {PersonagemId = 6, HabilidadeId =2},
                new PersonagemHabilidade() {PersonagemId = 7, HabilidadeId =3}
            );

            //base.OnModelCreating(modelBuilder);
            Usuario user = new Usuario();
            Cripografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");

        }

        private void HasData(Habilidade habilidade1, Habilidade habilidade2, Habilidade habilidade3)
        {
            throw new NotImplementedException();
        }
    }
}