using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Models;

public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Body { get; set; } = string.Empty;
}
