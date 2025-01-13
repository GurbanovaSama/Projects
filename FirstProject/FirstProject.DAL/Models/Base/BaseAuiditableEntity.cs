﻿namespace FirstProject.DAL.Models.Base;

public class BaseAuiditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public DateTime DeletedAt { get; set; } 
    
}