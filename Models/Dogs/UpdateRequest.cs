using System.ComponentModel.DataAnnotations;
using WebApi.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApi.Models.Dogs
{
    public class UpdateRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public List<IFormFile> AdditionalPictures { get; set; }
        
        /*
        private string _name;
        private int _age;
        private string _description;
        private IFormFile _profilePicture;
        private List<IFormFile> _additionalPictures;

        public string Name
        {
            get => _name;
            set => _name = replaceEmptyWithNull(value);
        }

        public int Age
        {
            get => _age;
            set => _age;
        }

        public string Description
        {
            get => _description;
            set => _description = replaceEmptyWithNull(value);
        }

        public IFormFile ProfilePicture
        {
            get => _profilePicture;
            set => _profilePicture;
        }

        public List<IFormFile> AdditionalPictures
        {
            get => _additionalPictures;
            set => _additionalPictures;
        }
        // helpers

        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
        */
    }
}