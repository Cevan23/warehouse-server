﻿namespace warehouse_BE.Domain.Entities;

public class Storage : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required string Status { get; set; }  // 'Active or Not Active'

    // Relationships
    public ICollection<Area>? Areas { get; set; } = new List<Area>();
}
