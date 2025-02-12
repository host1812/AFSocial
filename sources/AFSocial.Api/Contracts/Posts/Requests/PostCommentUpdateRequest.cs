﻿using System.ComponentModel.DataAnnotations;

namespace AFSocial.Api.Contracts.Posts.Requests;

public class PostCommentUpdateRequest
{
    [Required]
    public string Text { get; set; } = string.Empty;
}
