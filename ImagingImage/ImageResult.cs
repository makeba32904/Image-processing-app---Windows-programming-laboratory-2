using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImagingImage
{
    public class ImageResult
    {   
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Bitmap? Image { get; set; }
    }
}
