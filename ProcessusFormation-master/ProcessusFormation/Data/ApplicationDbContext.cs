using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessusFormation.Models;
using ProcessusFormation.Models.Formation;
using ProcessusFormation.Models.Compétence;
using ProcessusFormation.Models.Evaluation;
//using ProcessusFormation.Models.Formation;

namespace ProcessusFormation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ParticipantModel> Participants { get; set; }
        public DbSet<BesoinFormationModel> BesoinFormations { get; set; }
        public DbSet<BesoinCollecteModel> BesoinCollectes { get; set; }
        public DbSet<FormateurModel> Formateurs { get; set; }
        public DbSet<CompetenceModel> Competences { get; set; }
        public DbSet<EvaluationFroid> EvaluationFroids { get; set; }
        public DbSet<EvaluationChaud> EvaluationChauds { get; set; }
        public DbSet<SuiviFormationModel> SuiviFormations { get; set; }
        public DbSet<CompetenceEvaluationFroidModel> CompetenceEvaluationFroids { get; set; }
        public DbSet<ParticipantToFormationModel> ParticipantToFormations { get; set; }
        public DbSet<DomaineModel> Domaines { get; set; }
        public DbSet<LabelModel> Labels { get; set; }
        public DbSet<EvaluationFroidParticipant> EvaluationFroidParticipants { get; set; }
        public DbSet<MetierModel> Metiers { get; set; }
        public DbSet<Intermidiaire> Intermidiaires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantFormation>().HasKey(pt => new { pt.BesoinFormationId, pt.ParticipantId });
            modelBuilder.Entity<ParticipantFormation>().HasOne(pt => pt.BesoinFormation).WithMany(pt => pt.ParticipantFormations).HasForeignKey(pt => pt.BesoinFormationId);
            modelBuilder.Entity<ParticipantFormation>().HasOne(pt => pt.Participant).WithMany(pt => pt.ParticipantFormations).HasForeignKey(pt => pt.ParticipantId);

            modelBuilder.Entity<ParticipantToFormationModel>().HasKey(pt => new { pt.IdFormation, pt.Id });
            modelBuilder.Entity<ParticipantToFormationModel>().HasOne(pt => pt.BesoinFormation).WithMany(pt => pt.ParticipantToFormations).HasForeignKey(pt => pt.IdFormation);
            modelBuilder.Entity<ParticipantToFormationModel>().HasOne(pt => pt.ApplicationUsers).WithMany(pt => pt.ParticipantToFormations).HasForeignKey(pt => pt.Id);


            modelBuilder.Entity<DomaineModel>()
           .HasMany(c => c.Labels)
            .WithOne(e => e.Domaines);
              

            base.OnModelCreating(modelBuilder);


        }

    }
}
