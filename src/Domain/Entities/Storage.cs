﻿namespace warehouse_BE.Domain.Entities;

public class Storage : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required StorageStatus Status { get; set; }
    public string? CompanyId { get; set; }
    public ICollection<Area>? Areas { get; set; } = new List<Area>();
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public ICollection<UserStorage> UserStorages { get; set; } = new List<UserStorage>();

}
