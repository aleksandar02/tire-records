using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TireRecords.Models;

namespace TireRecords.Services
{
    public class PdfService
    {
        public static byte[] CreatePdf(ReceiptDetailsViewModel receiptDetailsViewModel, List<string> imagePaths)
        {
            var fileStream = new MemoryStream();

            PdfDocument document = new PdfDocument();
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

            PdfPage page = new PdfPage();

            document.AddPage(page);
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            page.Size = PdfSharp.PageSize.A4;

            PdfService.GenerateLeftSide(receiptDetailsViewModel, page, options, imagePaths);
            PdfService.GenerateRightSide(receiptDetailsViewModel, page, options, imagePaths);

            document.Save(fileStream);

            return fileStream.ToArray();
        }

        public static void GenerateLeftSide(ReceiptDetailsViewModel receiptDetails, PdfPage page, XPdfFontOptions options, List<string> imagePaths)
        {
            XFont font = new XFont("Calibri", 12, XFontStyle.Bold, options);

            using (XGraphics gfx = XGraphics.FromPdfPage(page))
            {
                // Split line
                XPen splitLine = new XPen(XColors.Black, 1);

                gfx.DrawLine(splitLine, page.Width / 2, 10, page.Width / 2, page.Height - 10);

                // Vulco image
                //XImage vulcoImage = XImage.FromFile(imagePaths.ElementAt(0));
                //gfx.DrawImage(vulcoImage, 20, 20, 120, 50);

                XTextFormatter tf = new XTextFormatter(gfx);
                tf.Alignment = XParagraphAlignment.Center;

                // Text between images
                //var rect = new XRect(150, 25, 150, 12);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("AUTO GUMI CENTAR STOŠIĆ", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(150, 39, 150, 12);
                //font = new XFont("Calibri", 9, XFontStyle.Regular, options);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Kapetana Koče 47, 35000 Jagodina", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(150, 51, 150, 12);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("035 8 223 689 | 063 433 644", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                var rect = new XRect(20, 25, 150, 12);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("AUTO GUMI CENTAR STOŠIĆ", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(12, 39, 150, 12);
                font = new XFont("Calibri", 9, XFontStyle.Regular, options);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Kapetana Koče 47, 35000 Jagodina", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(4, 51, 150, 12);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("035 8 223 689 | 065 223 6891", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Auto logo
                XImage logoImage = XImage.FromFile(imagePaths.ElementAt(0));
                gfx.DrawImage(logoImage, 315, 20, 90, 60);

                // Website and gmail
                //rect = new XRect(20, 70, 115, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("gumejagodina@gmail.com", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(15, 60, 115, 10);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("gumejagodina@gmail.com", font, XBrushes.Black, rect, XStringFormats.TopLeft);


                // Compant info
                //tf.Alignment = XParagraphAlignment.Left;
                //rect = new XRect(305, 80, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("PIB:                    100563059", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(305, 90, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Mat. broj:         17312618", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(305, 100, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Registarski br.  BD65 402", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(305, 110, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Br.evid PDV      131895379", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                font = new XFont("Calibri", 9, XFontStyle.Bold, options);

                rect = new XRect(290, 85, 120, 10);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("T.R. 170-0030020435000-28", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(280, 95, 120, 10);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("155-23599-23", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // After header line
                XPen afterLine = new XPen(XColors.Black, 1);

                gfx.DrawLine(afterLine, 20, 142, page.Width / 2 - 20, 142);

                // Heading
                font = new XFont("Calibri", 13, XFontStyle.Bold, options);
                tf.Alignment = XParagraphAlignment.Center;

                rect = new XRect(20, 146, page.Width / 2 - 40, 15);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Potvrda o vraćanju pneumatika sa čuvanja", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(20, 160, page.Width / 2 - 40, 15);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"broj {receiptDetails.Receipt.RNumber} izdata dana: {receiptDetails.Receipt.CreatedAt.ToString("dd.MM.yyyy")} godine", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Client and Vehicle Info
                font = new XFont("Calibri", 11, XFontStyle.Regular, options);
                tf.Alignment = XParagraphAlignment.Left;

                // Firstname and Lastname
                rect = new XRect(20, 190, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Prezime i ime:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(110, 190, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Client.LastName.ToUpper()} {receiptDetails.Client.FirstName.ToUpper()}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Phone and email
                rect = new XRect(20, 205, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Telefon / email:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(110, 205, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Client.MobilePhone} / {receiptDetails.Client.Email}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Brand
                rect = new XRect(20, 220, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Marka:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(110, 220, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Vehicle.Brand}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Reg Number
                rect = new XRect(20, 235, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Registarski broj:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(110, 235, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Vehicle.RegistrationNumber}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Tires

                // After Client and vehicle line
                afterLine = new XPen(XColors.Black, 1);

                gfx.DrawLine(afterLine, 20, 280, page.Width / 2 - 20, 280);

                // Table header
                font = new XFont("Calibri", 9, XFontStyle.Regular, options);
                tf.Alignment = XParagraphAlignment.Left;

                rect = new XRect(20, 265, 150, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Marka i tip", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(170, 265, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Dimenzija", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(260, 265, 55, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Index", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(315, 265, 40, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Dot", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(355, 265, 47, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Dubina", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                var yPosition = 285;

                foreach (var tire in receiptDetails.Tires)
                {
                    font = new XFont("Calibri", 11, XFontStyle.Bold, options);

                    rect = new XRect(20, yPosition, 20, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.PositionText}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    font = new XFont("Calibri", 11, XFontStyle.Regular, options);

                    rect = new XRect(40, yPosition, 130, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Brand} {tire.Model}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(170, yPosition, 90, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Dimension}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(260, yPosition, 55, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Index}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(315, yPosition, 40, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.DOT}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(355, yPosition, 47, 14);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Depth} mm", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    yPosition += 15;
                }

                font = new XFont("Calibri", 10, XFontStyle.Regular, options);

                rect = new XRect(22, 355, page.Width / 2 - 40, 110);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Receipt.Message}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                afterLine = new XPen(XColors.Black, 1);

                gfx.DrawLine(afterLine, 22, 355, page.Width / 2 - 20, 355);
                gfx.DrawLine(afterLine, 22, 465, page.Width / 2 - 20, 465);
                gfx.DrawLine(afterLine, 22, 355, 22, 465);
                gfx.DrawLine(afterLine, page.Width / 2 - 20, 355, page.Width / 2 - 20, 465);

                font = new XFont("Calibri", 9, XFontStyle.Regular, options);
                tf.Alignment = XParagraphAlignment.Center;

                rect = new XRect(40, 470, 100, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Za AUTO GUMI CENTAR STOŠIĆ", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(40, 480, 100, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Receipt.UserName}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(250, 470, 100, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Pneumatike preuzeo", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                gfx.DrawLine(afterLine, 20, 520, 160, 520);

                rect = new XRect(162, 510, 20, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("m.p.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                gfx.DrawLine(afterLine, 184, 520, 400, 520);

                rect = new XRect(20, 530, page.Width / 2 - 40, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Stranka može da preuzme pneumatike s ovom potvrdom do godinu dana od datuma ostavljanja", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(20, 540, page.Width / 2 - 40, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("pneumatike na čuvanje. Posle ovog perioda ne odgovaramo za čuvanje pneumatika(točkova).", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                font = new XFont("Calibri", 13, XFontStyle.Bold, options);

                rect = new XRect(20, 560, page.Width / 2 - 40, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("OVLAŠĆENI UVOZNIK I DISTRIBUTER", font, XBrushes.Black, rect, XStringFormats.TopLeft);
            }
        }

        public static void GenerateRightSide(ReceiptDetailsViewModel receiptDetails, PdfPage page, XPdfFontOptions options, List<string> imagePaths)
        {
            XFont font = new XFont("Calibri", 12, XFontStyle.Bold, options);

            using (XGraphics gfx = XGraphics.FromPdfPage(page))
            {
                // Vulco image
                //XImage vulcoImage = XImage.FromFile(imagePaths.ElementAt(0));
                //gfx.DrawImage(vulcoImage, page.Width / 2 + 20, 20, 120, 50);

                XTextFormatter tf = new XTextFormatter(gfx);
                tf.Alignment = XParagraphAlignment.Center;

                // Text between images
                //var rect = new XRect(page.Width / 2 + 150, 25, 150, 12);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("AUTO GUMI CENTAR STOŠIĆ", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(page.Width / 2 + 150, 39, 150, 12);
                //font = new XFont("Calibri", 9, XFontStyle.Regular, options);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Kapetana Koče 47, 35000 Jagodina", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(page.Width / 2 + 150, 51, 150, 12);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("035 8 223 689 | 063 433 644", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                var rect = new XRect(page.Width / 2 + 20, 25, 150, 12);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("AUTO GUMI CENTAR STOŠIĆ", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 12, 39, 150, 12);
                font = new XFont("Calibri", 9, XFontStyle.Regular, options);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Kapetana Koče 47, 35000 Jagodina", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 2, 51, 150, 12);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("035 8 223 689 | 065 223 6891", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Auto logo
                XImage logoImage = XImage.FromFile(imagePaths.ElementAt(0));
                gfx.DrawImage(logoImage, page.Width / 2 + 315, 20, 90, 60);

                // Website and gmail
                rect = new XRect(page.Width / 2 + 15, 60, 115, 10);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("gumejagodina@gmail.com", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(page.Width / 2 + 20, 80, 115, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("stosicgumefelne@gmail.com", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Compant info
                //tf.Alignment = XParagraphAlignment.Left;
                //rect = new XRect(page.Width / 2 + 305, 80, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("PIB:                    100563059", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(page.Width / 2 + 305, 90, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Mat. broj:         17312618", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(page.Width / 2 + 305, 100, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Registarski br.  BD65 402", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                //rect = new XRect(page.Width / 2 + 305, 110, 120, 10);

                //gfx.DrawRectangle(XBrushes.Transparent, rect);
                //tf.DrawString("Br.evid PDV      131895379", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                font = new XFont("Calibri", 9, XFontStyle.Bold, options);

                rect = new XRect(page.Width / 2 + 296, 85, 120, 10);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("T.R. 170-0030020435000-28", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 287, 95, 120, 10);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("155-23599-23", font, XBrushes.Black, rect, XStringFormats.TopLeft);


                // After header line
                XPen afterLine = new XPen(XColors.Black, 1);

                gfx.DrawLine(afterLine, page.Width / 2 + 20, 142, page.Width - 20, 142);

                // Heading
                font = new XFont("Calibri", 13, XFontStyle.Bold, options);
                tf.Alignment = XParagraphAlignment.Center;

                rect = new XRect(page.Width / 2 + 20, 146, page.Width / 2 - 40, 15);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Potvrda o vraćanju pneumatika sa čuvanja", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 20, 160, page.Width / 2 - 40, 15);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"broj {receiptDetails.Receipt.RNumber} izdata dana: {receiptDetails.Receipt.CreatedAt.ToString("dd.MM.yyyy")} godine", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Client and Vehicle Info
                font = new XFont("Calibri", 11, XFontStyle.Regular, options);
                tf.Alignment = XParagraphAlignment.Left;

                // Firstname and Lastname
                rect = new XRect(page.Width / 2 + 20, 190, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Prezime i ime:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 110, 190, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Client.LastName.ToUpper()} {receiptDetails.Client.FirstName.ToUpper()}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Phone and email
                rect = new XRect(page.Width / 2 + 20, 205, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Telefon / email:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 110, 205, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Client.MobilePhone} / {receiptDetails.Client.Email}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Brand
                rect = new XRect(page.Width / 2 + 20, 220, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Marka:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 110, 220, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Vehicle.Brand}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Reg Number
                rect = new XRect(page.Width / 2 + 20, 235, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Registarski broj:", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 110, 235, 290, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Vehicle.RegistrationNumber}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Tires

                // After Client and vehicle line
                afterLine = new XPen(XColors.Black, 1);

                gfx.DrawLine(afterLine, page.Width / 2 + 20, 280, page.Width - 20, 280);

                // Table header
                font = new XFont("Calibri", 9, XFontStyle.Regular, options);
                tf.Alignment = XParagraphAlignment.Left;

                rect = new XRect(page.Width / 2 + 20, 265, 150, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Marka i tip", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 170, 265, 90, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Dimenzija", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 260, 265, 55, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Index", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 315, 265, 40, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Dot", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 355, 265, 47, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Dubina", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                // Tire data
                var yPosition = 285;

                foreach (var tire in receiptDetails.Tires)
                {
                    font = new XFont("Calibri", 11, XFontStyle.Bold, options);

                    rect = new XRect(page.Width / 2 + 20, yPosition, 20, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.PositionText}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    font = new XFont("Calibri", 11, XFontStyle.Regular, options);

                    rect = new XRect(page.Width / 2 + 40, yPosition, 130, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Brand} {tire.Model}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(page.Width / 2 + 170, yPosition, 90, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Dimension}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(page.Width / 2 + 260, yPosition, 55, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Index}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(page.Width / 2 + 315, yPosition, 40, 13);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.DOT}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    rect = new XRect(page.Width / 2 + 355, yPosition, 47, 14);

                    gfx.DrawRectangle(XBrushes.Transparent, rect);
                    tf.DrawString($"{tire.Depth} mm", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                    yPosition += 15;
                }

                font = new XFont("Calibri", 10, XFontStyle.Regular, options);

                rect = new XRect(page.Width / 2 + 20, 355, page.Width / 2 - 40, 110);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Receipt.Message}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                afterLine = new XPen(XColors.Black, 1);

                gfx.DrawLine(afterLine, page.Width / 2 + 20, 355, page.Width - 20, 355);
                gfx.DrawLine(afterLine, page.Width / 2 + 20, 465, page.Width - 20, 465);
                gfx.DrawLine(afterLine, page.Width / 2 + 20, 355, page.Width / 2 + 20, 465);
                gfx.DrawLine(afterLine, page.Width / 2 + page.Width / 2 - 20, 355, page.Width / 2 + page.Width / 2 - 20, 465);

                font = new XFont("Calibri", 9, XFontStyle.Regular, options);
                tf.Alignment = XParagraphAlignment.Center;

                rect = new XRect(page.Width / 2 + 40, 470, 100, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Za AUTO GUMI CENTAR STOŠIĆ", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 40, 480, 100, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString($"{receiptDetails.Receipt.UserName}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 250, 470, 100, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Pneumatike preuzeo", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                gfx.DrawLine(afterLine, page.Width / 2 + 20, 520, page.Width / 2 + 160, 520);

                rect = new XRect(page.Width / 2 + 162, 510, 20, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("m.p.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                gfx.DrawLine(afterLine, page.Width / 2 + 184, 520, page.Width / 2 + 400, 520);

                rect = new XRect(page.Width / 2 + 20, 530, page.Width / 2 - 20, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("Stranka može da preuzme pneumatike s ovom potvrdom do godinu dana od datuma ostavljanja", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                rect = new XRect(page.Width / 2 + 20, 540, page.Width / 2 - 40, 11);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("pneumatike na čuvanje. Posle ovog perioda ne odgovaramo za čuvanje pneumatika(točkova).", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                font = new XFont("Calibri", 13, XFontStyle.Bold, options);

                rect = new XRect(page.Width / 2 + 20, 560, page.Width / 2 - 40, 14);

                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString("OVLAŠĆENI UVOZNIK I DISTRIBUTER", font, XBrushes.Black, rect, XStringFormats.TopLeft);
            }
        }
    }
}