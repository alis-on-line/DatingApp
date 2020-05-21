using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IDatingRepository datingRepository;

        public UsersController(IDatingRepository datingRepository) {
            this.datingRepository = datingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() {
            var users = await datingRepository.GetUsers();
            var userLists = users.Select(x => new UserForListDto(id: x.Id,
                                                        username: x.Username,
                                                        gender: x.Gender,
                                                        age: x.DateOfBirth.CalculateAge(),
                                                        knownAs: x.KnownAs,
                                                        created: x.Created,
                                                        introduction: x.Introduction,
                                                        interests: x.Interests,
                                                        city: x.City,
                                                        country: x.Country,
                                                        photoUrl: x.Photos.SingleOrDefault(x => x.IsMain).Url));
            return Ok(userLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) {
            var user = await datingRepository.GetUser(id);
            var photo = user.Photos
                            .SingleOrDefault(x => x.Id == id);
            var photos = user.Photos
                             .Select(x => new PhotoForDetailedDto(id: x.Id,
                                                                  url: x.Url,
                                                                  description: x.Description,
                                                                  dateAdded: x.DateAdded,
                                                                  isMain: x.IsMain))
                             .ToArray();
            var userDetails = new UserForDetailedDto(id: user.Id,
                                                     username: user.Username,
                                                     gender: user.Gender,
                                                     age: user.DateOfBirth.CalculateAge(),
                                                     knownAs: user.KnownAs,
                                                     created: user.Created,
                                                     lastActive: user.LastActive,
                                                     introduction: user.Introduction,
                                                     interests: user.Interests,
                                                     city: user.City,
                                                     country: user.Country,
                                                     photoUrl: photo.Url,
                                                     photos: photos);
            return Ok(userDetails);
        }
    }
}