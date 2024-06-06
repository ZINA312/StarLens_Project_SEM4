using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.UI.ValueConverters
{
    public class PublicationIdToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int Id)
            {
                string imagePath = GetImagePath(Id);
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    return ImageSource.FromFile(imagePath);
                }
            }
            return ImageSource.FromFile("dotnet_bot.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetImagePath(int Id)
        {
            string imagesFolder = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    imagesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "Images");
                    break;
                case Device.Android:
                    imagesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Images");
                    break;
                case Device.UWP:
                    imagesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Images");
                    break;
            }

            if (!Directory.Exists(imagesFolder))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    Directory.CreateDirectory(imagesFolder);
                });
            }

            string imagePath = Path.Combine(imagesFolder, $"{Id}.png");
            if (!File.Exists(imagePath))
            {
                string jpgPath = Path.ChangeExtension(imagePath, "jpg");
                string jpegPath = Path.ChangeExtension(imagePath, "jpeg");

                if (File.Exists(jpgPath))
                {
                    imagePath = jpgPath;
                }
                else if (File.Exists(jpegPath))
                {
                    imagePath = jpegPath;
                }
            }

            return imagePath;
        }
    }
}
