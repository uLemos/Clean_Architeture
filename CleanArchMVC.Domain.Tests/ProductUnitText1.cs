using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitText1
    {

        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_DomainExceptionValidParameters()
        {
            Action action = () => new Product(1, "lemos", "É isso aí", 50.99m, 30, "Isso é uma imagem");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Product Invalid Id")]
        public void CreateProduct_InvalidId_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1 ,"lemos", "É isso aí", 50.99m, 30, "Isso é uma imagem");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value"); //--
        }


        [Fact(DisplayName = "Create Product Invalid Name")]
        public void CreateProduct_WithNullName_DomainExceptionNullName()
        {
            Action action = () => new Product(1, null, "É isso aí", 50.99m, 30, "Isso é uma imagem");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required"); //----
        } 


        [Fact(DisplayName = "Create Product Short Name")]
        public void CreateProduct_ShortName_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "le", "É isso aí", 50.99m, 30, "Isso é uma imagem");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimun 3 characters"); // -----
        }


        [Fact(DisplayName = "Create Product Invalid Description")]
        public void CreateProduct_WithNullDescription_DomainExceptionNullDescription()
        {
            Action action = () => new Product(1, "lemos", null, 50.99m, 30, "Isso é uma imagem");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required"); // ----
        }


        [Fact(DisplayName = "Create Product Short Description")]
        public void CreateProduct_ShortDescription_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "lemos", "abcd", 50.99m, 30, "Isso é uma imagem");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description, too short, minimun 5 characters"); // ---
        }


        [Fact(DisplayName = "Create Product Invalid Price")]
        public void CreateProduct_InvalidPrice_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "lemos", "É isso aí", -50.99m, 30, "Isso é uma imagem");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value"); //---
        }


        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "lemos", "É isso aí", 50.99m, value, "hehe isso é uma imagem");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value"); //---
        }


        [Fact(DisplayName = "Create Product Long Image")]
        public void CreateProduct_LongImage_DomainExceptionLongImage()
        {
            Action action = () => new Product(1, "lemos", "É isso aí", 50.99m, 30
                , "Isso é uma imagem toooooooooooooooooooooooooooooooooooooooooooooooooooooo looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonnnnnnnnnnnnnnnnnnnnnnnnnnnnnnngggggggggggggggggggggggggggggggggggggggg");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters"); //---
        }


        [Fact(DisplayName = "Create Product Image Null")]
        public void CreateProduct_NullImage_DomainExceptionNullImage()
        {
            Action action = () => new Product(1, "lemos", "É isso aí", 50.99m, 30
                , null);
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
