using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integrale.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace integralesaude.Models
{
    public class LabMedicineContext : DbContext
    {
        public LabMedicineContext(DbContextOptions<LabMedicineContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacientesModel>().HasIndex(p =>new {p.Cpf}).IsUnique(true);
               modelBuilder.Entity<PacientesModel>().HasData(new[]
               {
                new PacientesModel()
                {
                    NomeCompleto = "Ana Souza Lima",
                    DataNascimento = new DateTime(1990,10,05),
                    Cpf = "123.456.789-00",
                    Id = 1,
                    ContatodeEmergencia = "Maria Souza (mãe) - (11) 99999-8888",
                    ListaAlergias = "Penicilina",
                    ListadeCuidadosEspecificos = "Dieta sem glúten",
                    Convenio = "Bradesco Saúde",
                },

                new PacientesModel()
                {
                    NomeCompleto = "Pedro Santos Oliveira",
                    DataNascimento = new DateTime(1990,03,22),
                    Cpf = "234.567.890-11",
                    Id = 2,
                    ContatodeEmergencia = "João Oliveira (irmão) - (21) 98765-4321",
                    ListaAlergias = "Nenhuma",
                    ListadeCuidadosEspecificos = "Nenhum",
                    Convenio = "Unimed"  
                },

                new PacientesModel()
                {
                    NomeCompleto = "Marina Ferreira Costa",
                    DataNascimento = new DateTime(1996,06,12),
                    Cpf = "345.678.901-22",
                    Id = 3,
                    ContatodeEmergencia = "Rafael Ferreira (irmão) - (31) 99999-5555",
                    ListaAlergias = "Nenhuma",
                    ListadeCuidadosEspecificos = "Hipertensão",
                    Convenio = "Amil"  
                },
                new PacientesModel()
                {
                    NomeCompleto = "José da Silva Santos",
                    DataNascimento = new DateTime(1960,01,30),
                    Cpf = "456.789.012-33",
                    Id = 4,
                    ContatodeEmergencia = "Maria da Silva (esposa) - (81) 98888-7777",
                    ListaAlergias = "Aspirina",
                    ListadeCuidadosEspecificos = "Diabetes",
                    Convenio = "Hapvida"
                },
                new PacientesModel()
                {
                    NomeCompleto = "Juliana Almeida Rodrigues",
                    DataNascimento = new DateTime(1998,09,18),
                    Cpf = "567.890.123-44",
                    Id = 5,
                    ContatodeEmergencia = "Ana Almeida (mãe) - (51) 98765-4321",
                    ListaAlergias = "Frutos do mar",
                    ListadeCuidadosEspecificos = "Nenhum",
                    Convenio = "SulAmérica Saúde"
                },
                new PacientesModel()
                {
                    NomeCompleto = "Ricardo Santos Silva",
                    DataNascimento = new DateTime(1975,07,03),
                    Cpf = "678.901.234-55",
                    Id = 6,
                    ContatodeEmergencia = "Maria Santos (esposa) - (21) 99999-4444",
                    ListaAlergias = "Nenhuma",
                    ListadeCuidadosEspecificos = "Nenhum",
                    Convenio = "Bradesco Saúde"
                },
                new PacientesModel()
                {
                    NomeCompleto = "Fernanda Pereira Nunes",
                    DataNascimento = new DateTime(1987,11,20),
                    Cpf = "789.012.345-66",
                    Id = 7,
                    ContatodeEmergencia = "Luiz Pereira (pai) - (27) 98888-2222",
                    ListaAlergias = "Nenhuma",
                    ListadeCuidadosEspecificos = "Nenhum",
                    Convenio = "Unimed"
                },
                new PacientesModel()
                {
                    NomeCompleto = "Marcelo Costa Oliveira",
                    DataNascimento = new DateTime(1995,04,02),
                    Cpf = "890.123.456-77",
                    Id = 8,
                    ContatodeEmergencia = "Joana Costa (irmã) - (85) 99999-3333",
                    ListaAlergias = "ovo",
                    ListadeCuidadosEspecificos = "Nenhum",
                    Convenio = "Unimed"
                },
                new PacientesModel()
                {
                    NomeCompleto = "João da Silva",
                    DataNascimento = new DateTime(1980,05,15),
                    Cpf = "012.345.678-90",
                    Id = 9,
                    ContatodeEmergencia = "Maria da Silva (esposa) - (11) 98888-5555",
                    ListaAlergias = "penicilina",
                    ListadeCuidadosEspecificos = "Hipertensão",
                    Convenio = "Bradesco Saúde"
                },
                new PacientesModel()
                {
                    NomeCompleto = "Amanda Oliveira Santos",
                    DataNascimento = new DateTime(1996,08,27),
                    Cpf = "123.456.789-01",
                    Id = 10,
                    ContatodeEmergencia = "Ana Oliveira (mãe) - (31) 99999-1111",
                    ListaAlergias = "nenhum",
                    ListadeCuidadosEspecificos = "Diabetes",
                    Convenio = "Amil"
                }
                });
            
            modelBuilder.Entity<MedicosModel>().HasIndex(p =>new {p.Cpf}).IsUnique(true);
               modelBuilder.Entity<MedicosModel>().HasData(new[]
               {
                new MedicosModel()
               {
                    NomeCompleto = "Victor Ferreira dos Santos",
                    DataNascimento = new DateTime(1986,05,10),
                    Cpf = "256.589.129-27",
                    Id = 11,
                    InstituicaodeEnsino = "UFRJ",
                    CRM = "04532"
                    
               },
                new MedicosModel()
               {
                    NomeCompleto = "Vanessa Mendez",
                    DataNascimento = new DateTime(1984,03,20),
                    Cpf = "103.795.617-60",
                    Id = 12,
                    InstituicaodeEnsino = "UFSC",
                    CRM = "125623"
                    
               }
               });

                modelBuilder.Entity<EnfermeirosModel>().HasIndex(p =>new {p.Cpf}).IsUnique(true);
               modelBuilder.Entity<EnfermeirosModel>().HasData(new[]
               {
                new EnfermeirosModel()
               {
                    NomeCompleto = "Fernando Silva Borges",
                    DataNascimento = new DateTime(1980,02,10),
                    Cpf = "256.547.218-27",
                    Id = 13,
                    InstituicaodeEnsino = "UFRJ",
                    COFEN = "125524"
                    
               },
                new EnfermeirosModel()
               {
                    NomeCompleto = "Karina Monteiro",
                    DataNascimento = new DateTime(1990,04,25),
                    Cpf = "584.395.127-20",
                    Id = 14,
                    InstituicaodeEnsino = "UFSC",
                    COFEN = "25134684"
                    
               }
               });



            
        }
        public DbSet<MedicosModel> Medicos {get; set;}
        public DbSet<PacientesModel> Pacientes {get; set;}
        public DbSet<EnfermeirosModel> Enfermeiros {get; set;}
        public DbSet<AtendimentoModel> Atendimentos {get; set;}

        
    }
}