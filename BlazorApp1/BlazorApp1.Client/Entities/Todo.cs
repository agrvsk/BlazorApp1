using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Client.Entities;

public class Todo : ICloneable, IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title är obligatorisk")]
    [MaxLength(15, ErrorMessage = "Title får inte vara mer 15 tecken.")]

    public string Title { get; set; }

    [MaxLength(50, ErrorMessage = "Description får inte vara mer 50 tecken.")]
    public string Description { get; set; }
    public string AssignedTo { get; set; }

    public object Clone()
    {
        return new Todo
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            AssignedTo = this.AssignedTo,
        };

    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Title?.EndsWith(".dk") == true)
        {
            yield return new ValidationResult("Epost från Danmark är inte tillåtet", new[] { nameof(Title) });
        }

    }
}
