using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string GuidProfilePicture { get; set; }
        [NotMappedAttribute]
        public IFormFile ProfilePicture { get; set; }
        public string GuidAdditionalPicture { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> AdditionalPictures { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}