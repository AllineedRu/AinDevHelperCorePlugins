﻿using System;

namespace AinDevHelperVisitorPattern {
    /// <summary>
    /// Реализация посетителя для вычисления площади фигур
    /// </summary>
    public class AreaVisitor : IVisitor {
        public void VisitCircle(Circle circle) {
            double area = Math.PI * circle.Radius * circle.Radius;
            Console.WriteLine($"Площадь круга: {area}");
        }

        public void VisitRectangle(Rectangle rectangle) {
            double area = rectangle.Width * rectangle.Height;
            Console.WriteLine($"Площадь прямоугольника: {area}");
        }

        public void VisitSquare(Square square) {
            double area = square.SideLength * square.SideLength;
            Console.WriteLine($"Площадь квадрата: {area}");
        }

        public void VisitTriangle(Triangle triangle) {
            double area = 0.5 * triangle.Base * triangle.Height;
            Console.WriteLine($"Площадь треугольника: {area}");
        }
    }
}
