using System;

namespace DatingApp.API.Dtos {
    public class PhotoForDetailedDto {
        public PhotoForDetailedDto(int id, string url, string description, DateTime dateAdded, bool isMain) {
            Id = id;
            Url = url;
            Description = description;
            DateAdded = dateAdded;
            IsMain = isMain;
        }
        
        public int Id { get; }

        public string Url { get; }

        public string Description { get; }

        public DateTime DateAdded { get; }

        public bool IsMain { get; }
    }
}