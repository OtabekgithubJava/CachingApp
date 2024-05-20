using MediatR;
using PersonalBrand.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Application.UseCases.IdentitieCases.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserModel>>
    {
    }
}
