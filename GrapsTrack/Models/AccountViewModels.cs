using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GrapsTrack.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class PerformerVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InfoLink { get; set; }
        public IEnumerable<EventVm> PossibleEvents { get; set; } = new List<EventVm>();
        public bool IsChecked { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
    
    public class CreatePerformerVm
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InfoLink { get; set; }
        public SelectList Events { get; set; }

        public int SelectedEventId { get; set; }
    }

    public class CreateEventVm
    {
        public int Id { get; set; }
        public int PerformerId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public SelectList Performers { get; set; }

        public int SelectedPerformerId { get; set; }
    }

    public class EditEventVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public List<PerformerVm> Performers { get; set; } = new List<PerformerVm>();
    }


    public class EditPerformerVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InfoLink { get; set; }
        
    }

    public class DetailPerformerVm
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InfoLink { get; set; }
    }

    public class DetailEventVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public SelectList Performers { get; set; }

        public int SelectedPerformerId { get; set; }
    }

    public class EventVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Promotion Promotion { get; set; }

        public List<PerformerVm> Performers { get; set; } = new List<PerformerVm>();
    }
}
