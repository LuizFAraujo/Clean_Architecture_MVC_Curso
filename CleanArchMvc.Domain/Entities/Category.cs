using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; } = null!;


        // Relacionamento
        public ICollection<Product> Products { get; private set; }


        //----------- Construtor
        public Category(string name)
        {
            //Name = name;
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id Inválido!");
            Id = id;
            ValidateDomain(name);
        }


        public void Update(string name)
        {
            ValidateDomain(name);
        }


        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome Inválido! Nome é requerido.");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome Inválido! Muito curto, minímo 3 caracteres.");

            Name = name;
        }
    }
}
