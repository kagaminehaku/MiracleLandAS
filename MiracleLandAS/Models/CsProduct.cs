﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleLandAS.Models
{
    public class CsProducts
    {
        public Guid Pid { get; set; }

        public string Pname { get; set; } = null!;

        public decimal Pprice { get; set; }

        public int Pquantity { get; set; }

        public string Pinfo { get; set; } = null!;

        public string Pimg { get; set; } = null!;
    }

    public class CsProductsToCart
    {
        public string token { get; set; }
        public Guid Pid { get; set; }
        public int Pquantity { get; set; }
    }

    public class PostPutProduct
    {
        public Guid Pid { get; set; }

        public string Pname { get; set; } = null!;

        public decimal Pprice { get; set; }

        public int Pquantity { get; set; }

        public string Pinfo { get; set; } = null!;

        public string PimgContent { get; set; }

    }

    public class Product
    {
        public Guid Pid { get; set; }

        public string Pname { get; set; } = null!;

        public decimal Pprice { get; set; }

        public int Pquantity { get; set; }

        public string Pinfo { get; set; } = null!;

        public string Pimg { get; set; } = null!;
    }

    public class PostPutProductNoImage
    {
        public Guid Pid { get; set; }

        public string Pname { get; set; } = null!;

        public decimal Pprice { get; set; }

        public int Pquantity { get; set; }

        public string Pinfo { get; set; } = null!;

    }

    public class EditProductImage
    {
        public Guid Pid { get; set; }
        public string? ProductImgContent { get; set; }
    }
}
