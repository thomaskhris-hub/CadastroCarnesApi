using CadastroCarnes.Data.Context;
using CadastroCarnes.Model.Entities;

namespace CadastroCarnes.Data.Seeds;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Estados.Any())
        {
            var estados = new List<Estado>
            {
                new()
                {
                    Nome = "São Paulo",
                    UF = "SP",
                    Cidades = new List<Cidade>
                    {
                        new() { Nome = "São Paulo" },
                        new() { Nome = "Campinas" },
                        new() { Nome = "Santos" }
                    }
                },

                new()
                {
                    Nome = "Rio de Janeiro",
                    UF = "RJ",
                    Cidades = new List<Cidade>
                    {
                        new() { Nome = "Rio de Janeiro" },
                        new() { Nome = "Niterói" }
                    }
                },

                new()
                {
                    Nome = "Minas Gerais",
                    UF = "MG",
                    Cidades = new List<Cidade>
                    {
                        new() { Nome = "Belo Horizonte" },
                        new() { Nome = "Uberlândia" }
                    }
                }
            };

            context.Estados.AddRange(estados);
            context.SaveChanges();
        }
    }
}