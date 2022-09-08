using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        public void IsUserExists(User user)
        {

            if (user == null)
            {
                throw new BusinessException(BusinessConstants.UserNotExists);
            }
        }
    }
}
