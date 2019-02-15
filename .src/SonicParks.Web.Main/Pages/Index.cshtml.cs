using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SonicParks.Core.Application.ViewsModels;
using SonicParks.Core.Application.Interfaces.ViewsModels;
using System.Threading;
using SonicParks.Core.Application.Interfaces.AppServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SonicParks.Web.Main.Pages {

    public class IndexModel : PageModel {

        private IUserAppService userAppService;

        [ModelBinder]
        public UserRegisterViewModel UserRegisterViewModel { get; set; }

        [ModelBinder]
        public UserLoginViewModel UserLoginViewModel { get; set; }

        public IndexModel(IUserAppService userAppService) {

            this.userAppService = userAppService;

        }

        public void OnGetAsync() { }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRegisterAsync(UserRegisterViewModel userRegisterViewModel, CancellationToken cancellationToken) {

            ModelState[nameof(UserLoginViewModel.Password)].ValidationState = ModelValidationState.Skipped;
            ModelState[nameof(UserLoginViewModel.Email)].ValidationState = ModelValidationState.Skipped;

            if (ModelState.IsValid) {

                await userAppService.New(userRegisterViewModel, cancellationToken);
                return RedirectToPage("Index");

            }
            else {

                return Page();

            }

        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPostLogin(UserLoginViewModel userLoginViewModel, CancellationToken cancellationToken) {

            ModelState[nameof(UserRegisterViewModel.Email)].ValidationState = ModelValidationState.Skipped;
            ModelState[nameof(UserRegisterViewModel.NewPassword)].ValidationState = ModelValidationState.Skipped;
            ModelState[nameof(UserRegisterViewModel.NewPasswordConfirm)].ValidationState = ModelValidationState.Skipped;

            if (ModelState.IsValid) {

                return NotFound();

            }
            else {

                return Page();

            }

        }

    }

}
