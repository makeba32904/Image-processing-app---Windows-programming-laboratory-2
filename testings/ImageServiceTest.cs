using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using ImagingImage.Services;

namespace testings
{
    [TestClass]
    public sealed class ImageServiceTest
    {
        private ImageService _service;
        [TestInitialize]
        public void Setup()
        {
            _service = new ImageService();
        }
        [TestMethod]
        public void Should_Fail_When_Image_Is_Null()
        {
            var result = _service.ProcessImage(null);
            Assert.IsFalse(result.Success);
        }
        [TestMethod]
        public void Should_Throw_When_Image_Too_Small() 
        {
            Bitmap img = new Bitmap(128, 128);
            var result = _service.ProcessImage(img);
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Image is too small", result.Message);
        }
        [TestMethod]
        public void Should_Crop_Rectangular_Image()
        {
            Bitmap img = new Bitmap(512, 768);
            var result = _service.ProcessImage(img);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Image);
            Assert.AreEqual(512, result.Image.Width);
            Assert.AreEqual(512, result.Image.Height);
        }
        [TestMethod]
        public void Should_Fail_When_Aspect_Ratio_Invalid()
        {
            Bitmap img = new Bitmap(128, 512);
            var result = _service.ProcessImage(img);
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Invalid aspect ratio", result.Message);
        }
        [TestMethod]
        public void Should_Pass_When_Ratio_Is_Exactly_2()
        {
            Bitmap img = new Bitmap(1024, 512);
            var result = _service.ProcessImage(img);
            Assert.IsTrue(result.Success);
        }
        [TestMethod]
        public void Should_Pass_When_Ratio_Is_Exactly_0_5()
        {
            Bitmap img = new Bitmap(512, 1024);
            var result = _service.ProcessImage(img);
            Assert.IsTrue(result.Success);
        }
        [TestMethod]
        public void Should_Resize_Large_Image()
        {
            Bitmap img = new Bitmap(4096, 6000);
            var result = _service.ProcessImage(img);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Image);
            Assert.AreEqual(512, result.Image.Width);
            Assert.AreEqual(512, result.Image.Height);
        }
        [TestMethod]
        public void Should_Keep_Valid_Image()
        {
            Bitmap img = new Bitmap(512, 512);
            var result = _service.ProcessImage(img);
            Assert.IsNotNull(result.Image);
            Assert.AreEqual(512, result.Image.Width);
            Assert.AreEqual(512, result.Image.Height);
        }
    }
}
