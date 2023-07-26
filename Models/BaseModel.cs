using System;
namespace dotnet_template2023.Models;

	public class BaseModel
	{
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDateTime { get; set; } = DateTime.UtcNow;
}

