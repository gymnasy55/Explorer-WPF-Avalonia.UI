﻿using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Explorer.Shared.ViewModels;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;

namespace Explorer.WPF.UI
{
    internal class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drawingImage = new DrawingImage();
            if (value is DirectoryViewModel)
            {
                var resource = Application.Current.TryFindResource("FolderIconImage");
                if (resource is ImageSource directoryImageSource)
                    return directoryImageSource;
            }
            else if (value is FileViewModel fileViewModel)
            {
                var extension = new FileInfo(fileViewModel.FullName).Extension;

                var imagePath = ExtensionToImageFileConverter.GetImagePath(extension);

                if (imagePath.Extension.ToUpper() == ".SVG")
                {
                    var settings = new WpfDrawingSettings
                    {
                        TextAsGeometry = false,
                        IncludeRuntime = true
                    };

                    var converter = new FileSvgReader(settings);

                    var drawing = converter.Read(imagePath.FullName);

                    if (drawing != null)
                        return new DrawingImage(drawing);
                }
                else
                {
                    var bitmapImage = new BitmapImage(new Uri(imagePath.FullName));
                    return bitmapImage;
                }

                var resource = Application.Current.TryFindResource("FileIconImage");

                if (resource is ImageSource fileImageSource)
                    return fileImageSource;
            }
            return drawingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
