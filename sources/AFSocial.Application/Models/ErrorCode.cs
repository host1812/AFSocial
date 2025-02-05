using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Models;
public enum ErrorCode
{
    NOT_FOUND = 404,
    INTERNAL = 500,
    UNKNOWN = 0,
    VALIDATION = 400,
}
