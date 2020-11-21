import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { ToastService } from '../toast/toast.service';

@Injectable({
  providedIn: 'root'
})
export class GlobalErrorService implements ErrorHandler{

  constructor(
    private injector: Injector
  ) { }
  handleError(errorResponse: any): void {
    if (errorResponse.status === 401) {
      this.injector.get(ToastService).danger('Unauthorised: Please login again.');
    } else if (errorResponse.status === 400) {

      this.injector.get(ToastService).danger(this.formatErrors(errorResponse.error.Errors));
    } else {
      // All other errors including 500
      const error = errorResponse && errorResponse.rejection ? errorResponse.rejection.error : errorResponse;

      this.injector.get(ToastService).danger(error.message);
      // IMPORTANT: Don't Rethrow the error otherwise it will not emit errors after once
      // https://stackoverflow.com/questions/44356040/angular-global-error-handler-working-only-once
      // throw errorResponse;
    }
  }
  private formatErrors(errors: any) {

    return errors ? errors.map((err: any) => err.PropertyName + ' : ' + err.ErrorMessage).join('<br>') : '';
  }
}
