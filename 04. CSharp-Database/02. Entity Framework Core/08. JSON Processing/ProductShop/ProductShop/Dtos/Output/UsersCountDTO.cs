using System.Collections.Generic;

namespace ProductShop
{
    internal class UsersCountDTO
    {
        public UsersCountDTO()
        {
        }

        public int UsersCount { get; set; }
        public List<LastNameAgeSoldDTO> Users { get; set; }
    }
}