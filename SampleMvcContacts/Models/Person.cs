using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Person Class
/// </summary>
public class Person
{
	public int personId { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required")]
	public string firstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name is required")]
	public string lastName { get; set; }

    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email address is required")]
	public string emailAddress { get; set; }
}
