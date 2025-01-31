using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Models;
public class OperationError
{
    public ErrorCode Code { get; set; }
    public string Message { get; set; }
}
