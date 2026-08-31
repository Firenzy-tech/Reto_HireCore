using System;

public class JobOffer
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime PostedDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}
