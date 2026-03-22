using System.Drawing;

namespace ImagingImage.Services
{
    public class ImageService
    {
        public ImageResult ProcessImage(Bitmap input)
        //<summary>
        // Processes an image:
        //Validates size
        //Crops to square
        //Resizes to 512x512
        // </summary>
        {
            if (input == null)
            {
                return new ImageResult
                {
                    Success = false,
                    Message = "Image is null"
                };
            }
            int width = input.Width;
            int height = input.Height;
            double ratio = (double)width / height;
            if (ratio < 0.5 || ratio > 2)
            {
                return new ImageResult
                {
                    Success = false,
                    Message = "Invalid aspect ratio"
                };
            }
            if (width<512 || height < 512)
            {
                return new ImageResult
                {
                    Success = false,
                    Message = "Image is too small"
                };
            }
            int size = Math.Min(width, height);
            int x = (width - size) / 2;
            int y = (height - size) / 2;
            Rectangle cropArea = new Rectangle(x, y, size, size);
            using (Bitmap cropped = input.Clone(cropArea, input.PixelFormat))
            {
                if (size != 512)
                {
                    return new ImageResult
                    {
                        Success = true,
                        Message = "Processed successfully",
                        Image = new Bitmap(cropped, new Size(512, 512))
                    };
                }
                return new ImageResult
                {
                    Success = true,
                    Message = "Processed successfully",
                    Image = new Bitmap(cropped)
                };
            }
        }
    }
}
