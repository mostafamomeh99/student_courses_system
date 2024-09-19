using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Test
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
