using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TagsCloudVisualization
{
    [TestFixture]
    public class MockTests
    {
        private Mock<ICloudLayouter> cloud;
        private Mock<ICloudDrawer> drawer;

        [SetUp]
        public void SetUp()
        {
            cloud = new Mock<ICloudLayouter>();
            cloud.Setup(l => l.PutNextRectangle(It.IsAny<Size>())).Returns(It.IsAny<Rectangle>());
            drawer = new Mock<ICloudDrawer>();
        }

        [Test]
        public void ReturnRightSize_Exactly3Times()
        {
            var maker = new CircularCloudMaker(cloud.Object, new Options());
            var dict = maker.MakeCloud(new Dictionary<string, int> { { "aaa", 1 }, { "aaaa", 2 }, { "aaaaa", 3 } });

            dict.Select(r => r.Value.Height * r.Value.Width).Should().BeInAscendingOrder();
            cloud.Verify(l => l.PutNextRectangle(It.IsAny<Size>()), Times.Exactly(3));
        }

        [Test]
        public void SaveToFile_ExactlyOnce()
        {
            drawer.Object.Save(It.IsAny<Dictionary<string, Rectangle>>());
            cloud.Verify(l => l.PutNextRectangle(It.IsAny<Size>()), Times.Never);
            drawer.Verify(s => s.Save(It.IsAny<Dictionary<string, Rectangle>>()), Times.Once);
        }

        [Test]
        public void Draw_ExactlyOnce()
        {
            drawer.Object.Draw(It.IsAny<Dictionary<string, Rectangle>>());
            cloud.Verify(l => l.PutNextRectangle(It.IsAny<Size>()), Times.Never);
            drawer.Verify(s => s.Draw(It.IsAny<Dictionary<string, Rectangle>>()), Times.Once);
        }
    }
}