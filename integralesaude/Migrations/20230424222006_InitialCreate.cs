using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace integralesaude.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermeiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituiçãodeEnsino = table.Column<string>(name: "Instituição de Ensino", type: "nvarchar(max)", nullable: true),
                    COFEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatadeNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituiçãodeEnsino = table.Column<string>(name: "Instituição de Ensino", type: "nvarchar(max)", nullable: true),
                    CRM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspecializaçãoClínica = table.Column<int>(name: "Especialização Clínica", type: "int", nullable: false),
                    EstadonoSistema = table.Column<int>(name: "Estado no Sistema", type: "int", nullable: false),
                    TotaldeAtendimentos = table.Column<int>(name: "Total de Atendimentos", type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatadeNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatodeEmergencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ListadeAlergias = table.Column<string>(name: "Lista de Alergias", type: "nvarchar(max)", nullable: true),
                    ListadeCuidadosEspecíficos = table.Column<string>(name: "Lista de Cuidados Específicos", type: "nvarchar(max)", nullable: true),
                    Convênio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusdeAtendimento = table.Column<int>(name: "Status de Atendimento", type: "int", nullable: false),
                    TotaldeAtendimentos = table.Column<int>(name: "Total de Atendimentos", type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatadeNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Enfermeiros",
                columns: new[] { "Id", "COFEN", "Cpf", "DatadeNascimento", "Genero", "Instituição de Ensino", "NomeCompleto", "Telefone" },
                values: new object[,]
                {
                    { 13, "125524", "256.547.218-27", new DateTime(1980, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UFRJ", "Fernando Silva Borges", null },
                    { 14, "25134684", "584.395.127-20", new DateTime(1990, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UFSC", "Karina Monteiro", null }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "CRM", "Cpf", "DatadeNascimento", "Especialização Clínica", "Estado no Sistema", "Genero", "Instituição de Ensino", "NomeCompleto", "Telefone", "Total de Atendimentos" },
                values: new object[,]
                {
                    { 11, "04532", "256.589.129-27", new DateTime(1986, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, null, "UFRJ", "Victor Ferreira dos Santos", null, 0 },
                    { 12, "125623", "103.795.617-60", new DateTime(1984, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, null, "UFSC", "Vanessa Mendez", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "ContatodeEmergencia", "Convênio", "Cpf", "DatadeNascimento", "Genero", "Lista de Alergias", "Lista de Cuidados Específicos", "NomeCompleto", "Status de Atendimento", "Telefone", "Total de Atendimentos" },
                values: new object[,]
                {
                    { 1, "Maria Souza (mãe) - (11) 99999-8888", "Bradesco Saúde", "123.456.789-00", new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Penicilina", "Dieta sem glúten", "Ana Souza Lima", 0, null, 0 },
                    { 2, "João Oliveira (irmão) - (21) 98765-4321", "Unimed", "234.567.890-11", new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nenhuma", "Nenhum", "Pedro Santos Oliveira", 0, null, 0 },
                    { 3, "Rafael Ferreira (irmão) - (31) 99999-5555", "Amil", "345.678.901-22", new DateTime(1996, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nenhuma", "Hipertensão", "Marina Ferreira Costa", 0, null, 0 },
                    { 4, "Maria da Silva (esposa) - (81) 98888-7777", "Hapvida", "456.789.012-33", new DateTime(1960, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aspirina", "Diabetes", "José da Silva Santos", 0, null, 0 },
                    { 5, "Ana Almeida (mãe) - (51) 98765-4321", "SulAmérica Saúde", "567.890.123-44", new DateTime(1998, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Frutos do mar", "Nenhum", "Juliana Almeida Rodrigues", 0, null, 0 },
                    { 6, "Maria Santos (esposa) - (21) 99999-4444", "Bradesco Saúde", "678.901.234-55", new DateTime(1975, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nenhuma", "Nenhum", "Ricardo Santos Silva", 0, null, 0 },
                    { 7, "Luiz Pereira (pai) - (27) 98888-2222", "Unimed", "789.012.345-66", new DateTime(1987, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nenhuma", "Nenhum", "Fernanda Pereira Nunes", 0, null, 0 },
                    { 8, "Joana Costa (irmã) - (85) 99999-3333", "Unimed", "890.123.456-77", new DateTime(1995, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ovo", "Nenhum", "Marcelo Costa Oliveira", 0, null, 0 },
                    { 9, "Maria da Silva (esposa) - (11) 98888-5555", "Bradesco Saúde", "012.345.678-90", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "penicilina", "Hipertensão", "João da Silva", 0, null, 0 },
                    { 10, "Ana Oliveira (mãe) - (31) 99999-1111", "Amil", "123.456.789-01", new DateTime(1996, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nenhum", "Diabetes", "Amanda Oliveira Santos", 0, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeiros_Cpf",
                table: "Enfermeiros",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_Cpf",
                table: "Medicos",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Cpf",
                table: "Pacientes",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermeiros");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
