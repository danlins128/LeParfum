using LeParfum.Data.Entities;

namespace LeParfum.Application.Models
{
    public class User : UserEntity
    {
        public UserEntity ToEntity() => this;
        public static User FromEntity(UserEntity entity) => new()
        {
            Id = entity.Id,
            UserName = entity.UserName,
            Password = entity.Password,
        };
    }
}