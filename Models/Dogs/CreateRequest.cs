using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApi.Models.Dogs
{
    public class CreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile ProfilePicture { get; set; }

        [Required]
        public List<IFormFile> AdditionalPictures { get; set; }
    }
}