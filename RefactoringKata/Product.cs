﻿using System.Collections.Generic;

namespace RefactoringKata
{
    public class Product
    {
        public static int SIZE_NOT_APPLICABLE = -1;

        public string Code { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }

        public Dictionary<string, object> Data()
        {
            Dictionary<string, object> productData =
                new Dictionary<string, object> { { "code", this.Code }, { "color", this.ColorCodeToString() } };
            if (this.Size != Product.SIZE_NOT_APPLICABLE)
            {
                productData.Add("size", this.SizeCodeToString());
            }

            productData.Add("price", this.Price);
            productData.Add("currency", this.Currency);
            return productData;
        }

        private string SizeCodeToString()
        {
            switch (this.Size)
            {
                case 1:
                    return "XS";
                case 2:
                    return "S";
                case 3:
                    return "M";
                case 4:
                    return "L";
                case 5:
                    return "XL";
                case 6:
                    return "XXL";
                default:
                    return "Invalid Size";
            }
        }

        private string ColorCodeToString()
        {
            switch (this.Color)
            {
                case 1:
                    return "blue";
                case 2:
                    return "red";
                case 3:
                    return "yellow";
                default:
                    return "no color";
            }
        }
    }
}
