using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos {
    public class UserForDetailedDto {
        public UserForDetailedDto(int id,
                                  string username,
                                  string gender,
                                  int age,
                                  string knownAs,
                                  DateTime created,
                                  DateTime lastActive,
                                  string introduction,
                                  string interests,
                                  string city,
                                  string country,
                                  string photoUrl,
                                  PhotoForDetailedDto[] photos) {
            Id = id;
            Username = username;
            Gender = gender;
            Age = age;
            KnownAs = knownAs;
            Created = created;
            LastActive = lastActive;
            Introduction = introduction;
            Interests = interests;
            City = city;
            Country = country;
            PhotoUrl = photoUrl;
            Photos = photos;
        }

        public int Id { get; }

        public string Username { get; }

        public string Gender { get; }

        public int Age { get; }

        public string KnownAs { get; }

        public DateTime Created { get; }

        public DateTime LastActive { get; }

        public string Introduction { get; }

        public string Interests { get; }

        public string City { get; }

        public string Country { get; }

        public string PhotoUrl { get; }

        public PhotoForDetailedDto[] Photos { get; set; }
    }
}