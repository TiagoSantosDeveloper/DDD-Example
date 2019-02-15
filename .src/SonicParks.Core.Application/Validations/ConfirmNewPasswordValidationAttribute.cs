using SonicParks.Core.Application.ViewsModels;
using SonicParks.Core.CrossCutting.Locality;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SonicParks.Core.Application.Validations {

    public class PasswordNewConfirmValidationAttribute : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

            return base.IsValid(validationContext.ObjectInstance, validationContext);

        }

        public override bool IsValid(object value) {

            try {

                UserRegisterViewModel userViewModel = (UserRegisterViewModel)value;
                return !string.IsNullOrWhiteSpace(userViewModel.NewPassword + userViewModel.NewPasswordConfirm) && userViewModel.NewPassword.Equals(userViewModel.NewPasswordConfirm);

            }
            catch {

                return false;

            }



        }

        public override string FormatErrorMessage(string name) {

            return Messages.PasswordConfirm;

        }

    }

}
