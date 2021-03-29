namespace Gallery.InputModels
{
    using Gallery.Enums;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ItemCreateIM
    {
        private const string MinPrice = "0.00";
        private const string MaxPrice = "100.00";
        private const string RequiredErrorMessage = "The field is required.";

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Description { get; set; }

        [Required(ErrorMessage = "At least one image is required.")]
        public ICollection<IFormFile> Images { get; set; } = new List<IFormFile>();

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Type { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string CommercialType { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Size { get; set; }

        public decimal Price { get; set; }

        public byte Quantity { get; set; }
    }
}
