using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.Queries;
public class GetAllPostCommentsQuery : IRequest<OperationResult<IEnumerable<PostComment>>>
{
    public Guid PostId { get; set; }
}
