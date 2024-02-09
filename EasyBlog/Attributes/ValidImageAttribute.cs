﻿using System.ComponentModel.DataAnnotations;

namespace EasyBlog.Attributes
{
    public class ValidImageAttribute : ValidationAttribute
    {
        public double MaxFileSizeMB { get; set; } = 1;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = (IFormFile?)value;
            
            if (file == null)
                return ValidationResult.Success;

            if (!file.ContentType.StartsWith("image/"))
            {
                return new ValidationResult("Invalid image file.");
            }
            else if (file.Length > MaxFileSizeMB * 1024 * 1024)
            {
                return new ValidationResult($"Maximum file size: {MaxFileSizeMB} MB");
            }

            return ValidationResult.Success;
        }
    }
}
