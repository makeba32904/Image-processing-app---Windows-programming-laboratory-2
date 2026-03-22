# Image Processor Library

Overview
This project is a C# Class Library that processes user-provided images based on specific validation rules.

Features
* Validate image size
* Validate aspect ratio
* Crop image to square (center crop)
* Resize image to 512x512

Rules
* Minimum size: 512x512
* Allowed aspect ratio: 0.5 – 2
* Output size: 512x512

Test
* Framework: MSTest
* All edge cases are tested:
  * Null image
  * Too small image
  * Invalid aspect ratio
  * Cropping
  * Resizing
* Code coverage: 100%

Project Structure
* ImageProcessorLib → Core logic
* ImageProcessorTests → Unit tests

How to Run
1. Open solution in Visual Studio
2. Go to Test Explorer
3. Click "Run All Tests"

Example Cases
* 128x512 → Invalid (ratio)
* 512x768 → Cropped to 512x512
* 4096x6000 → Resized to 512x512

Technologies
* .NET
* MSTest
* System.Drawing

Author
* Makeba
