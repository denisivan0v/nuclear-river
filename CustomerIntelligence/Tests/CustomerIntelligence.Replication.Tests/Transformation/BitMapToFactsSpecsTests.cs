﻿using System.Linq;

using NuClear.CustomerIntelligence.Domain.DTO;
using NuClear.CustomerIntelligence.Domain.Specifications;

using NUnit.Framework;

// ReSharper disable PossibleUnintendedReferenceComparison
namespace NuClear.CustomerIntelligence.Replication.Tests.Transformation
{
    [TestFixture]
    internal class BitMapToFactsSpecsTests
    {
        [Test]
        public void ShouldMapFromFirmStatisticsDto()
        {
            var dto = new FirmStatisticsDto
            {
                ProjectId = 1,
                Firms = new[]
                                  {
                                      new FirmStatisticsDto.FirmDto
                                      {
                                          FirmId = 2,
                        Categories = new[]
                        {
                            new FirmStatisticsDto.FirmDto.CategoryDto
                            {
                                          CategoryId = 3,
                                          Hits = 4,
                                          Shows = 5
                                      }
                                  }
                    }
                }
            };

            var entities = Specs.Map.Bit.FirmCategoryStatistics().Map(dto);

            Assert.That(entities.Count(), Is.EqualTo(1));
            Assert.That(entities.Single().ProjectId, Is.EqualTo(1));
            Assert.That(entities.Single().CategoryId, Is.EqualTo(3));
            Assert.That(entities.Single().FirmId, Is.EqualTo(2));
            Assert.That(entities.Single().Hits, Is.EqualTo(4));
            Assert.That(entities.Single().Shows, Is.EqualTo(5));
        }

        [Test]
        public void ShouldMapFromCategoryStatisticsDto()
        {
            var dto = new CategoryStatisticsDto
            {
                ProjectId = 1,
                Categories = new[]
                                  {
                                      new CategoryStatisticsDto.CategoryDto
                                      {
                                          CategoryId = 2,
                                          AdvertisersCount = 3,
                                      }
                                  }
            };

            var entities = Specs.Map.Bit.ProjectCategoryStatistics().Map(dto);

            Assert.That(entities.Count(), Is.EqualTo(1));
            Assert.That(entities.Single().ProjectId, Is.EqualTo(1));
            Assert.That(entities.Single().CategoryId, Is.EqualTo(2));
            Assert.That(entities.Single().AdvertisersCount, Is.EqualTo(3));
        }
    }
}