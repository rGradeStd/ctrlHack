﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using GeoPrototypeWebApi.Controllers;

namespace GeoPrototypeWebApi.Facades
{
    public class InfrastructureObjectReviewImagesFacade : DbBaseFacade
    {
        public ImageFormat GetImageFormatByMimeType(string mimeType)
        {
            switch (mimeType.ToLower())
            {
                case "image/jpeg": return ImageFormat.Jpeg;
                case "image/png": return ImageFormat.Png;
                case "image/gif": return ImageFormat.Gif;
                case "image/bmp": return ImageFormat.Bmp;
            }

            return ImageFormat.MemoryBmp;
        }

        public void InsertImage(long reviewId, ReviewImage reviewImage)
        {
            Image thumbnailImage = null;
            using (var ms = new MemoryStream(reviewImage.Image))
                thumbnailImage = Image.FromStream(ms).GetThumbnailImage(200, 200, null, new IntPtr(0));

            byte[] thumbnailImageArray = null;
            using (var ms = new MemoryStream())
            {
                thumbnailImage
                    .Save(ms, thumbnailImage.RawFormat.Equals(ImageFormat.MemoryBmp) ?
                        GetImageFormatByMimeType(reviewImage.MimeType)
                        : thumbnailImage.RawFormat);

                thumbnailImageArray = ms.ToArray();
            }

            using (var db = GetDbConnection())
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = SqlStrings.InsertReviewImage;
                cmd.AddParameter("@ReviewId", reviewId);
                cmd.AddParameter("@ImageMimeType", reviewImage.MimeType);
                cmd.AddParameter("@Image", reviewImage.Image);
                cmd.AddParameter("@ThumbnailMimeType", reviewImage.MimeType);
                cmd.AddParameter("@ThumbnailImage", thumbnailImage);

                cmd.ExecuteNonQuery();
            }
        }
    }
}