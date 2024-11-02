﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightInstruments
{
    public partial class ASIControl : InstrumentBase
    {

        public ASIControl()
        {
            DoubleBuffered = true;
            this.Size = new Size(300, 300);
        }

        protected override void DrawInstrument(PaintEventArgs e)
        {
            DrawASI(e.Graphics);
        }


        private void DrawASI(Graphics g)
        {
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //
            //int centerX = Width / 2;
            //int centerY = Height / 2;
            //int radius = Math.Min(Width, Height) / 2 - 20;
            //
            //// Draw the outer frame with screws
            //DrawOuterFrame(g, centerX, centerY, radius);
            //
            //// Draw the black background and gray dial ring
            //
            //Color agedGray = Color.FromArgb(255, 60, 60, 60); // Dark, slightly warm gray
            //Pen agedGrayPen = new Pen(agedGray);
            //Brush agedGrayBrush = new SolidBrush(agedGray);
            //
            //int outerRingWidth = (int)(Height * 0.08);
            //g.FillEllipse(agedGrayBrush, centerX - radius, centerY - radius, radius * 2, radius * 2);
            //using (Pen ringPen = new Pen(Color.FromArgb(230, 60, 60, 60), outerRingWidth))
            //{
            //    g.DrawEllipse(ringPen, centerX - radius, centerY - radius, radius * 2, radius * 2);
            //}
            //
            //// Draw tick marks and numbers
            //DrawDial(g, centerX, centerY, radius);
            //
            //// Draw the needle with an arrow tip
            //DrawLongNeedle(g, centerX, centerY, radius);
            //DrawShortNeedle(g, centerX, centerY, radius);
            //
            //// Draw the central cover circle to hide the needle base
            //DrawCenterCover(g);
            //
            //// Draw the center text (Winter, knots)
            ////DrawCenterText(g, centerX, centerY);
            //
            //
            //// Draw side labels with unit and serial numbers
            //DrawSideLabels(g, centerX, centerY, radius);
        }

//        private void DrawLongNeedle(Graphics g, int centerX, int centerY, int radius)
//        {
//            // Map -10 to +10 range to an angle from -150 to +150 degrees around the dial
//            double needleAngle = -90 + ((CurrentValue % 1000) * 360 / 1000);
//
//            // Define needle dimensions proportionally
//            int needleLength = (int)(radius * 1.0);         // Length of the needle as 90% of the radius
//            int needleWidth = (int)(radius * 0.05);         // Width of the needle as 5% of the radius
//            int triangleHeight = (int)(needleWidth * 1.5);  // Height of the triangle tip
//
//            // Create the needle path at the origin (pointing up)
//            using (GraphicsPath needlePath = new GraphicsPath())
//            {
//                // Define the needle as a rectangle with a triangle at the end
//                needlePath.AddPolygon(new Point[]
//                {
//            new Point(0, -needleWidth / 2),                    // Left point of the rectangle
//            new Point(needleLength - triangleHeight, -needleWidth / 2), // Left side near the triangle
//            new Point(needleLength - triangleHeight, -needleWidth / 2), // Base of the triangle (left)
//            new Point(needleLength, 0),                        // Tip of the triangle
//            new Point(needleLength - triangleHeight, needleWidth / 2),  // Base of the triangle (right)
//            new Point(needleLength - triangleHeight, needleWidth / 2),  // Right side near the triangle
//            new Point(0, needleWidth / 2)                      // Right point of the rectangle
//                });
//
//                // Rotate the needle path to match the calculated angle
//                using (Matrix matrix = new Matrix())
//                {
//                    matrix.RotateAt((float)needleAngle, new PointF(0, 0));
//                    needlePath.Transform(matrix);
//                }
//
//                // Define colors for needle and shadow
//                Color agedWhite = Color.FromArgb(255, 240, 240, 220); // Slightly yellowish, aged white
//                Brush agedWhiteBrush = new SolidBrush(agedWhite);
//
//                Color shadowColor = Color.FromArgb(100, 50, 50, 50); // Semi-transparent dark color for shadow
//                Brush shadowBrush = new SolidBrush(shadowColor);
//
//                // Create and draw the shadow slightly offset
//                using (GraphicsPath shadowPath = (GraphicsPath)needlePath.Clone())
//                {
//                    using (Matrix shadowTranslateMatrix = new Matrix())
//                    {
//                        shadowTranslateMatrix.Translate(centerX + radius * 0.02f, centerY + radius * 0.02f); // Offset shadow by 2% of the radius
//                        shadowPath.Transform(shadowTranslateMatrix);
//                    }
//
//                    // Draw the shadow
//                    g.FillPath(shadowBrush, shadowPath);
//                }
//
//                // Translate the needle path to the center of the dial
//                using (Matrix translateMatrix = new Matrix())
//                {
//                    translateMatrix.Translate(centerX, centerY);
//                    needlePath.Transform(translateMatrix);
//                }
//
//                // Draw the needle
//                g.FillPath(agedWhiteBrush, needlePath);
//            }
//        }
//
//        private void DrawShortNeedle(Graphics g, int centerX, int centerY, int radius)
//        {
//            // Map -10 to +10 range to an angle from -150 to +150 degrees around the dial
//            double needleAngle = -90 + ((CurrentValue / 1000) * 360 / 10);
//
//            // Define needle dimensions proportionally
//            int needleLength = (int)(radius * .6);         // Length of the needle as 90% of the radius
//            int needleWidth = (int)(radius * 0.1);         // Width of the needle as 5% of the radius
//            int triangleHeight = (int)(needleWidth * 1.5);  // Height of the triangle tip
//
//            // Create the needle path at the origin (pointing up)
//            using (GraphicsPath needlePath = new GraphicsPath())
//            {
//                // Define the needle as a rectangle with a triangle at the end
//                needlePath.AddPolygon(new Point[]
//                {
//            new Point(0, -needleWidth / 2),                    // Left point of the rectangle
//            new Point(needleLength - triangleHeight, -needleWidth / 2), // Left side near the triangle
//            new Point(needleLength - triangleHeight, -needleWidth / 2), // Base of the triangle (left)
//            new Point(needleLength, 0),                        // Tip of the triangle
//            new Point(needleLength - triangleHeight, needleWidth / 2),  // Base of the triangle (right)
//            new Point(needleLength - triangleHeight, needleWidth / 2),  // Right side near the triangle
//            new Point(0, needleWidth / 2)                      // Right point of the rectangle
//                });
//
//                // Rotate the needle path to match the calculated angle
//                using (Matrix matrix = new Matrix())
//                {
//                    matrix.RotateAt((float)needleAngle, new PointF(0, 0));
//                    needlePath.Transform(matrix);
//                }
//
//                // Define colors for needle and shadow
//                Color agedWhite = Color.FromArgb(255, 240, 240, 220); // Slightly yellowish, aged white
//                Brush agedWhiteBrush = new SolidBrush(agedWhite);
//
//                Color shadowColor = Color.FromArgb(100, 50, 50, 50); // Semi-transparent dark color for shadow
//                Brush shadowBrush = new SolidBrush(shadowColor);
//
//                // Create and draw the shadow slightly offset
//                using (GraphicsPath shadowPath = (GraphicsPath)needlePath.Clone())
//                {
//                    using (Matrix shadowTranslateMatrix = new Matrix())
//                    {
//                        shadowTranslateMatrix.Translate(centerX + radius * 0.02f, centerY + radius * 0.02f); // Offset shadow by 2% of the radius
//                        shadowPath.Transform(shadowTranslateMatrix);
//                    }
//
//                    // Draw the shadow
//                    g.FillPath(shadowBrush, shadowPath);
//                }
//
//                // Translate the needle path to the center of the dial
//                using (Matrix translateMatrix = new Matrix())
//                {
//                    translateMatrix.Translate(centerX, centerY);
//                    needlePath.Transform(translateMatrix);
//                }
//
//                // Draw the needle
//                g.FillPath(agedWhiteBrush, needlePath);
//            }
//        }
//
//
//
//        private void DrawOuterFrame(Graphics g, int centerX, int centerY, int radius)
//        {
//            int screwOffset = radius + 20;
//            int screwSize = 12;
//
//            // Draw screws in an octagonal layout
//            Brush screwBrush = Brushes.Gold;
//            g.FillEllipse(screwBrush, centerX - screwOffset, centerY - screwOffset, screwSize, screwSize); // Top left
//            g.FillEllipse(screwBrush, centerX + screwOffset - screwSize, centerY - screwOffset, screwSize, screwSize); // Top right
//            g.FillEllipse(screwBrush, centerX - screwOffset, centerY + screwOffset - screwSize, screwSize, screwSize); // Bottom left
//            g.FillEllipse(screwBrush, centerX + screwOffset - screwSize, centerY + screwOffset - screwSize, screwSize, screwSize); // Bottom right
//        }
//
//        private void DrawDial(Graphics g, int centerX, int centerY, int radius)
//        {
//            // Proportional dimensions based on radius
//            float majorTickWidth = radius * 0.04f;
//            float minorTickWidth = radius * 0.02f;
//            int majorTickLength = (int)(radius * 0.15);    // Length of major ticks
//            int minorTickLength = (int)(radius * 0.1);     // Length of minor ticks
//            float fontSize = radius * 0.15f;               // Font size for numbers
//            float labelOffset = radius * 0.12f;             // Proportional offset for label positioning
//
//            // Create pens and font dynamically based on radius
//            Pen majorTickPen = new Pen(Color.White, majorTickWidth);
//            Pen minorTickPen = new Pen(Color.White, minorTickWidth);
//            Font numberFont = new Font("Arial", fontSize, FontStyle.Bold);
//
//            // Iterate through each tick mark position from -10 to 10
//            for (int i = 0; i < 50; i++)
//            {
//                // Calculate the angle for each tick mark position
//                double angle;
//                angle = -90 + i * 360 / 50; // General spacing for other ticks
//
//                double radian = angle * (Math.PI / 180);
//
//                bool isMajorTick = (i % 5 == 0); // Major ticks for even numbers
//                int tickLength = isMajorTick ? majorTickLength : minorTickLength;
//                Pen tickPen = isMajorTick ? majorTickPen : minorTickPen;
//
//                // Calculate positions for tick marks
//                Point innerPoint = new Point(
//                    centerX + (int)((radius - tickLength) * Math.Cos(radian)),
//                    centerY + (int)((radius - tickLength) * Math.Sin(radian))
//                );
//                Point outerPoint = new Point(
//                    centerX + (int)(radius * Math.Cos(radian)),
//                    centerY + (int)(radius * Math.Sin(radian))
//                );
//
//                // Draw tick mark
//                g.DrawLine(tickPen, innerPoint, outerPoint);
//
//                // Draw numbers for major ticks
//                if (isMajorTick && i != 0)
//                {
//                    string numberLabel = Math.Abs(i / 5).ToString();
//                    SizeF labelSize = g.MeasureString(numberLabel, numberFont);
//
//                    // Position numbers relative to the radius with a proportional offset
//                    Point labelPoint = new Point(
//                        centerX + (int)((radius - tickLength - labelOffset) * Math.Cos(radian)) - (int)(labelSize.Width / 2),
//                        centerY + (int)((radius - tickLength - labelOffset) * Math.Sin(radian)) - (int)(labelSize.Height / 2)
//                    );
//
//                    g.DrawString(numberLabel, numberFont, Brushes.White, labelPoint);
//                }
//            }
//
//            // Dispose of pens and font
//            majorTickPen.Dispose();
//            minorTickPen.Dispose();
//            numberFont.Dispose();
//        }
//
//
//
//        private void DrawCenterCover(Graphics g)
//        {
//            int centerX = Width / 2;
//            int centerY = Height / 2;
//            int radius = Math.Min(Width, Height) / 4 ;
//            int centerCircleRadius = (int)(radius * 0.4);
//            g.FillEllipse(Brushes.Black, centerX - centerCircleRadius, centerY - centerCircleRadius, centerCircleRadius * 2, centerCircleRadius * 2);
//        }
//
//
//
//
//        private void DrawSideLabels(Graphics g, int centerX, int centerY, int radius)
//        {
////            // Proportional font size based on radius
////            float fontSize = radius * 0.05f; // Adjust factor as needed for proper scaling
////            float horizontalOffset = radius * 0.45f; // Horizontal offset from the center for labels
////            float verticalSpacing = radius * 0.07f; // Vertical spacing between labels
////
////            // Create font dynamically based on radius
////            using (Font labelFont = new Font("Arial", fontSize, FontStyle.Bold))
////            {
////                // Measure label height based on the font size
////                float labelHeight = g.MeasureString("S Nr. 05453", labelFont).Height;
////
////                // X position for right-aligned labels, offset by a fraction of the radius
////                float labelX = centerX + horizontalOffset;
////
////                // Calculate Y positions for each label, with vertical spacing between them
////                float serialLabelY = centerY - labelHeight - verticalSpacing;
////                float unitLabelY = centerY - (labelHeight / 2) - verticalSpacing / 2; // Centered vertically
////                float wnrLabelY = centerY - labelHeight /2 + verticalSpacing;
////
////                // Draw each label at the calculated positions
////                g.DrawString("S Nr. 05453", labelFont, Brushes.White, labelX, serialLabelY);
////                g.DrawString("knots", labelFont, Brushes.White, labelX, unitLabelY);
////                g.DrawString("WNr. 69573", labelFont, Brushes.White, labelX, wnrLabelY);
////            }
//        }
//
        protected override void OnUDPDataReceived(string udpData)
        {
            try
            {
                // Parse the JSON data
                var jsonObject = JObject.Parse(udpData);

                // Check if the "vario" key exists and is a valid float
                if (jsonObject.TryGetValue("airspeed", out JToken? outToken) && outToken != null && outToken.Type == JTokenType.Float)
                {
                    double val = outToken.ToObject<double>();
                    TargetValue = val; // Update the property based on JSON data
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON data: {ex.Message}");
            }
        }
    }
}
