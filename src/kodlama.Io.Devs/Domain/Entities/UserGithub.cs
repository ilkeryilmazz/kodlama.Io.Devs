using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class UserGithub:Entity
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
   
        public UserGithub()
        {

        }

        public UserGithub(int id,int userId, string githubAddress):this()
        {
            Id = id;
            UserId = userId;
            GithubAddress = githubAddress;
        }
    }
}
