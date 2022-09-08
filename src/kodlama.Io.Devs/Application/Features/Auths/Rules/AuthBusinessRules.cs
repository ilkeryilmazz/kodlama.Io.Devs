using Application.Features.Auths.Constants;
using Application.Features.Users.Dtos;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
       
        public void RegisteredUserCanNotBeNull(User user)
        {
            if (user==null)
            {
                throw new BusinessException(BusinessConstants.CreatedUserCanNotBeNull);
            }
        }
        
        public void VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            
            if (HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt)!=true)
            {
                throw new BusinessException(BusinessConstants.PasswordIsFault);
            }
        }
        public void IsUserExists(User user)
        {

            if (user==null)
            {
                throw new BusinessException(BusinessConstants.UserNotExists);
            }
        }
        public void IsUserAlreadyRegistrated(User user)
        {

            if (user != null)
            {
                throw new BusinessException(BusinessConstants.IsUserAlreadyRegistered);
            }
        }
    }
}
