using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TagCloud.Tests
{
    internal class TileTestingAt100OneSideSquares : OnFailDrawer
    {
        private List<Rectangle> tiledRectangles;
        private const int ElementsAmount = 100;

        [SetUp]
        public void SetUp()
        {
            cloudLayouter = new CircularCloudLayouter(TestingDegenerateSize.CenterPoint, 0.5);
            tiledRectangles = Enumerable
                .Range(0, ElementsAmount)
                .Select(number => cloudLayouter.PutNextRectangle(TestingDegenerateSize.SingleSize))
                .ToList();
        }

        [Test, Category("Simple Behaviour")]
        public void Should_TileSpace_AndNotSkipRectangles()
        {
            tiledRectangles
                .Select(rectangle => rectangle.Location)
                .Distinct()
                .Count()
                .Should()
                .Be(ElementsAmount);
        }
     
        [Test, Category("Simple Behaviour")]
        public void Should_GenerateNonOverlappingRectangles()
        {
            tiledRectangles
                .Select(rectangle => rectangle.Location)
                .Distinct()
                .Count()
                .Should()
                .Be(ElementsAmount);
        }

        [Test, Category("Simple Behaviour")]
        public void Should_GenerateRectangles_WithSpecifiedSize()
        {
            tiledRectangles
                .Select(rectangle => rectangle.Size)
                .Distinct()
                .Count()
                .Should()
                .Be(1);
        }
    }
}