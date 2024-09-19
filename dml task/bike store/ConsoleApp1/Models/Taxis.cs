using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Taxis
{
    public int TaxId { get; set; }

    public string State { get; set; } = null!;

    public decimal? StateTaxRate { get; set; }

    public decimal? AvgLocalTaxRate { get; set; }

    public decimal? CombinedRate { get; set; }

    public decimal? MaxLocalTaxRate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
