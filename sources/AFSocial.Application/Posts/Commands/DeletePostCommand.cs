using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.Commands;
public class DeletePostCommand : IRequest<OperationResult<Post>>
{
    public Guid PostId { get; set; }
}
