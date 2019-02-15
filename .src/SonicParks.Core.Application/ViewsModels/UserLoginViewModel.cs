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

    public class UserLoginViewModel : IUserLoginViewModel {

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

}
