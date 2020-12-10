using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Exceptions
{
    public class BadRequestException: Exception
    {
/*        public ModelStateDictionary ModelState { get; set; }
*/
        public BadRequestException(string message): base(message)
        {
        }

        public BadRequestException(string key, string errorMessage): base("the model state is invalid.")
        {
/*            ModelState = new ModelStateDictonaary();
            ModelState.AddModelError(key, errorMessage);*/
        }

/*        public BadRequestException(ModelStateDictionary modelState): base("The model state is invalid.")
        {
            if (modelState.IsValid || modelState.ErrorCount == 0)
            {
                return;
            }   

            ModelState = modelState;
        }*/

    }
}
