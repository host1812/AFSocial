using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.Commands;
public class CreatePostCommand : IRequest<OperationResult<Post>>
{
    /// <summary>
    /// Gets the unique identifier for the user profile associated with the post.
    /// </summary>
    [Required]
    public Guid UserProfileId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the text content of the post.
    /// </summary>
    [Required]
    [MaxLength(1024)]
    public string TextContent { get; set; } = string.Empty;
}
