using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Models;
public class OperationResult<T>
{
    public T? Value { get; set; }
    public bool IsError { get; set; }
    public List<string> Errors { get; set; }
}
