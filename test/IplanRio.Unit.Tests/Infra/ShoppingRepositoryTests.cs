﻿using IplanRio.Domain.Interfaces.Repository;
using System.Collections.Generic;
using Moq;
using Xunit;
using IplanRio.Domain.Entities;
using FluentAssertions;

namespace IplanRio.Unit.Tests.Infra
{
    public class ShoppingRepositoryTests
    {
        private readonly Mock<IShoppingRepository> _shoppingRepository;

        public ShoppingRepositoryTests()
        {
            _shoppingRepository = new Mock<IShoppingRepository>();
        }

        [Fact]
        public void Get_Shoppings_Test()
        {
            // Arrange
            var shoppings = new List<Shopping>()
            {
                new Shopping
                {
                    Id = 1,
                    Nome = "Shopping Rio Sul",
                    Endereco = "Rua Lauro Müller, 116 - Botafogo, Rio de Janeiro - RJ, 22290-160",
                    HoraAbertura = "10:00",
                    HoraFechamento = "22:00"
                },

                new Shopping
                {
                    Id = 2,
                    Nome = "Shopping Carioca",
                    Endereco = "Av. Vicente de Carvalho, 909 - Vila da Penha, Rio de Janeiro - RJ, 21210-000",
                    HoraAbertura = "10:00",
                    HoraFechamento = "22:00"
                },

                new Shopping
                {
                    Id = 3,
                    Nome = "Shopping Tijuca",
                    Endereco = "Av. Maracanã, 987 - Tijuca, Rio de Janeiro - RJ, 20511-000",
                    HoraAbertura = "10:00",
                    HoraFechamento = "22:00"
                }
            };

            _shoppingRepository.Setup(r => r.Get()).Returns(shoppings);

            // Act
            var result = _shoppingRepository.Object.Get();

            // Assert
            result.Should().HaveCount(3);
        }

        [Fact]
        public void GetById_Shopping_Test()
        {
            // Arrange
            var shopping = new Shopping
            {
                Id = 1,
                Nome = "Shopping Rio Sul",
                Endereco = "Rua Lauro Müller, 116 - Botafogo, Rio de Janeiro - RJ, 22290-160",
                HoraAbertura = "10:00",
                HoraFechamento = "22:00"
            };

            _shoppingRepository.Setup(r => r.GetById(shopping.Id)).Returns(shopping);

            // Act
            var result = _shoppingRepository.Object.GetById(1);

            // Assert
            result.Should().Be(shopping);
        }

        [Fact]
        public void Insert_Shopping_Test()
        {
            // Arrange
            var shopping = new Shopping
            {
                Id = 1,
                Nome = "Shopping Rio Sul",
                Endereco = "Rua Lauro Müller, 116 - Botafogo, Rio de Janeiro - RJ, 22290-160",
                HoraAbertura = "10:00",
                HoraFechamento = "22:00"
            };

            _shoppingRepository.Setup(r => r.Insert(shopping));

            // Act
            _shoppingRepository.Object.Insert(shopping);
            _shoppingRepository.Object.Commit();
        }

        [Fact]
        public void Update_Shopping_Test()
        {
            // Arrange
            var shopping = new Shopping
            {
                Id = 1,
                Nome = "Shopping Rio Sul",
                Endereco = "Rua Lauro Müller, 116 - Botafogo, Rio de Janeiro - RJ, 22290-160",
                HoraAbertura = "10:00",
                HoraFechamento = "22:00"
            };

            _shoppingRepository.Setup(r => r.Update(shopping));

            // Act
            _shoppingRepository.Object.Update(shopping);
            _shoppingRepository.Object.Commit();
        }

        [Fact]
        public void Delete_Shopping_Test()
        {
            // Arrange
            var shopping = new Shopping
            {
                Id = 1,
                Nome = "Shopping Rio Sul",
                Endereco = "Rua Lauro Müller, 116 - Botafogo, Rio de Janeiro - RJ, 22290-160",
                HoraAbertura = "10:00",
                HoraFechamento = "22:00"
            };

            _shoppingRepository.Setup(r => r.Delete(shopping));

            // Act
            _shoppingRepository.Object.Delete(shopping);
            _shoppingRepository.Object.Commit();
        }
    }
}
