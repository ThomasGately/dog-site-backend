using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Dogs;

namespace WebApi.Services
{
    public interface IDogService
    {
        IEnumerable<DogResponse> GetAll();
        DogResponse GetById(int id);
        DogResponse Create(CreateRequest model);
        DogResponse Update(int id, UpdateRequest model);
        void Delete(int id);
    }
    
    public class DogService : IDogService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public DogService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        public IEnumerable<DogResponse> GetAll()
        {
            var Dogs = _context.Dogs;
            return _mapper.Map<IList<DogResponse>>(Dogs);
        }

        public DogResponse GetById(int id)
        {
            var dog = getDog(id);
            return _mapper.Map<DogResponse>(dog);
        }

        public DogResponse Create(CreateRequest model)
        {

            // map model to new dog object
            var dog = _mapper.Map<Dog>(model);
            dog.Created = DateTime.UtcNow;

            // save dog
            _context.Dogs.Add(dog);
            _context.SaveChanges();

            return _mapper.Map<DogResponse>(dog);
        }

        public DogResponse Update(int id, UpdateRequest model)
        {
            var dog = getDog(id);

            // copy model to dog and save
            _mapper.Map(model, dog);
            dog.Updated = DateTime.UtcNow;
            _context.Dogs.Update(dog);
            _context.SaveChanges();

            return _mapper.Map<DogResponse>(dog);
        }
        
        public void Delete(int id)
        {
            var dog = getDog(id);
            _context.Dogs.Remove(dog);
            _context.SaveChanges();
        }

        // helper methods

        private Dog getDog(int id)
        {
            var Dog = _context.Dogs.Find(id);
            if (Dog == null) throw new KeyNotFoundException("Dog not found");
            return Dog;
        }
    }
}