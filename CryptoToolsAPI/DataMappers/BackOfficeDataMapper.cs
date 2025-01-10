using CryptoToolsAPI.DbContext;
using CryptoToolsAPI.DTOs.BackOffice;
using CryptoToolsAPI.Models;
using CryptoToolsAPI.NewFolder.NewFolder;

namespace CryptoToolsAPI.DataMappers
{
    public class BackOfficeDataMapper
    {
        private readonly Context _context;
        public BackOfficeDataMapper(Context context) 
        { 
            _context = context;
        }

        public List<UserResponseDTO> CreateUsers(List<UserRequestDTO> usersRequest) 
        {
            var users = new List<UserResponseDTO>();
            if (usersRequest != null) 
            {
                foreach (var item in usersRequest) 
                {
                    item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
                    _context.Users.Add(new Users() 
                    {
                        Name = item.Name,
                        Password = item.Password,
                        Description = item.Description,
                        Email = item.Email,
                        IPRange = item.IPRange,
                        Claim = item.Claim,
                        Value = item.Value,
                        Enabled = item.Enabled,
                    });

                    users.Add(new UserResponseDTO()
                    {
                        Name = item.Name,
                        Email = item.Email,
                        Description = item.Description,
                    });
                }

                _context.SaveChanges();
            }

            return users ?? new List<UserResponseDTO>();
        }

        public List<UserStatusResponseDTO> UpdateUserStatus(List<UserStatusRequestDTO> usersRequest) 
        { 
            var users = new List<UserStatusResponseDTO>();
            if(usersRequest != null) 
            { 
                foreach(var item in usersRequest) 
                { 
                    var user = _context.Users.Where(x => x.Email.Equals(item.Email)).FirstOrDefault();
                    if(user != null) 
                    {
                        user.Enabled = item.Enabled;
                        _context.Users.Update(user);

                        users.Add(new UserStatusResponseDTO()
                        {
                            ID = user.ID,
                            Email = item.Email,
                            Enabled = item.Enabled
                        });
                    }
                }
                _context.SaveChanges();
            }

            return users ?? new List<UserStatusResponseDTO>();
        }
    }
}
