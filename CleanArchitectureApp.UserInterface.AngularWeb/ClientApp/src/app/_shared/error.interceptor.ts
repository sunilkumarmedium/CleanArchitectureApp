import { AuthenticationService } from './../_services/authentication/authentication.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private authenticationService: AuthenticationService
  ) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request)
    .pipe(catchError(err => {
      if ([401, 403].includes(err.status) && this.authenticationService.userValue) {
        this.authenticationService.logout();
      }
      const error = err.error?.message || err.statusText;
      return throwError(error);

    }

    ));
  }
}
