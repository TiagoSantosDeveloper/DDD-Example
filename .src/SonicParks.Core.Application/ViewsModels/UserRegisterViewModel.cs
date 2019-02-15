using SonicParks.Core.Application.Interfaces.ViewsModels;
using SonicParks.Core.Application.Validations;
using SonicParks.Core.CrossCutting.Locality;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SonicParks.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SonicParks.Core.Application.ViewsModels {

    public class UserRegisterViewModel : IUserRegisterViewModel {

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "PasswordRule")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [PasswordNewConfirmValidation]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

}
