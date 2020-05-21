using System;

namespace DatingApp.API.Dtos {
    public class UserForListDto {
        public UserForListDto(int id,
                              string username,
                              string gender,
                              int age,
                              string knownAs,
                              DateTime created,
                              string introduction,
                              string interests,
                              string city,
                              string country,
                              string photoUrl) {
            Id = id;
            Username = username;
            Gender = gender;
            Age = age;
            KnownAs = knownAs;
            Created = created;
            Introduction = introduction;
            Interests = interests;
            City = city;
            Country = country;
            PhotoUrl = photoUrl;
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
    }
}