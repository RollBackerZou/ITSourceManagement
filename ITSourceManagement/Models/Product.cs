using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "商品名称")]
        [Required(ErrorMessage = "必填")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "必须是[3,60]个字符")]
        public string Title { get; set; }
        [Display(Name = "商品类型")]
        [Required]
        public string Genre { get; set; }
        [Display(Name = "商品简介")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "商品售价")]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Display(Name = "上新日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "商品图片")]
        [Required]
        public string Photo { get; set; }
    }
}