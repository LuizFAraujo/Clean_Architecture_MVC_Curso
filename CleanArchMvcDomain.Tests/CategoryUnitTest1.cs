using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {

        //[Fact(DisplayName = "Create Category With Valid State")]
        [Fact(DisplayName = "Criar Categoria com Id OK.")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name ");
            action.Should()
                 .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }



        [Fact(DisplayName = "Criar Categoria com Id Negativo.")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name ");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 //.WithMessage("Invalid Id value.");
                 .WithMessage("Id Inválido!");
        }



        [Fact(DisplayName = "Criar Categoria com nome muito curto.")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Nome Inválido! Muito curto, minímo 3 caracteres.");
        }



        [Fact(DisplayName = "Criar Categoria sem nome.")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome Inválido! Nome é requerido.");
        }



        [Fact(DisplayName = "Criar Categoria com nome Nulo.")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }



    }
}
