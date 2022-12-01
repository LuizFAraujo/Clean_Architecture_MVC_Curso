using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }


        // Relacionamento
        public int CategoryId { get; set; } // entendido como chave extrangeira
        public Category Category { get; set; }


        public Product(string name, string description,
            decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description,
            decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id Inválido!");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }


        public void Update(string name, string description,
            decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }



        private void ValidateDomain(string name, string description,
            decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome Inválido! Nome é requerido.");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome Inválido! Muito curto, minímo 3 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição Inválida! Descrição é requerida.");

            DomainExceptionValidation.When(description.Length < 5,
                "Descrição Inválida! Muito curta, minímo 5 caracteres.");

            DomainExceptionValidation.When(price < 0, "Valor Inválido de preço!");

            DomainExceptionValidation.When(stock < 0, "Valor Inválido de estoque!");

            DomainExceptionValidation.When(image.Length > 250,
                "Nome Inválido, da imagem! Muito longo, máximo 250 caracteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

    }
}
