using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WpfDirect2D.Shapes
{
    public class VectorShape : IShape
    {
        private string _geometryPath;
        private Point _pixelLocation;

        public VectorShape()
        {
            BrushColorsToCache = new List<Color>();
        }

        public VectorShape(Point pixelLocation) : this()
        {
            PixelLocation = pixelLocation;
        }

        public bool IsValid => !string.IsNullOrEmpty(GeometryPath);

        /// <summary>
        /// Path describing the geometry in svg / xaml path format
        /// </summary>
        public string GeometryPath
        {
            get { return _geometryPath; }
            set
            {
                _geometryPath = value;
                GeometryHash = GeometryPath.GetHashCode();
            }
        }

        public Point PixelLocation
        {
            get { return _pixelLocation; }
            set
            {
                _pixelLocation = value;
                PixelXLocation = Convert.ToSingle(value.X);
                PixelYLocation = Convert.ToSingle(value.Y);
            }
        }

        public float PixelXLocation { get; private set; }

        public float PixelYLocation { get; private set; }

        public float Rotation { get; set; }

        public float Scaling { get; set; }

        public Color FillColor { get; set; }

        public Color StrokeColor { get; set; }

        public float StrokeWidth { get; set; }

        public bool IsSelected { get; set; }

        public Color SelectedColor { get; set; }

        public List<Color> BrushColorsToCache { get; }

        public int GeometryHash { get; set; }

        public List<Color> GetColorsToCache()
        {
            //make sure the stroke, fill, and selected colors are in the list
            if (!BrushColorsToCache.Contains(FillColor))
            {
                BrushColorsToCache.Add(FillColor);
            }

            if (!BrushColorsToCache.Contains(StrokeColor))
            {
                BrushColorsToCache.Add(StrokeColor);
            }

            if (!BrushColorsToCache.Contains(SelectedColor))
            {
                BrushColorsToCache.Add(SelectedColor);
            }

            return BrushColorsToCache;
        }
    }
}
