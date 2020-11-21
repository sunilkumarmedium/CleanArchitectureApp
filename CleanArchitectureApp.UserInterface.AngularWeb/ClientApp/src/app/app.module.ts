import { LoadingService } from './_services/loading.service';
import { ErrorInterceptor } from './_shared/error.interceptor';
import { JwtInterceptor } from './_shared/jwt.interceptor';
import { UserService } from './_services/user/user.service';
import { ConfirmationDialogService } from './_services/confirmation-dialog/confirmation-dialog.service';
import { AuthenticationService } from './_services/authentication/authentication.service';
import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './_components/user/user/user.component';
import { UserListComponent } from './_components/user/user-list/user-list.component';
import { ConfirmationDialogComponent } from './_components/confirmation-dialog/confirmation-dialog.component';
import { HomeComponent } from './_components/home/home.component';
import { NavComponent } from './_components/nav/nav.component';
import { AccountModule } from './_components/account/account.module';
import { FooterComponent } from './_components/footer/footer.component';
import { LoadingInterceptor } from './_shared/loading.interceptor';
import { LoadingComponent } from './_components/loading/loading.component';
import { GlobalErrorService } from './_services/error/global-error.service';
import { HeaderComponent } from './_components/header/header.component';
import { ToastComponent } from './_components/toast/toast.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserListComponent,
    ConfirmationDialogComponent,
    HomeComponent,
    NavComponent,
    HeaderComponent,
    FooterComponent,
    LoadingComponent,
    ToastComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AccountModule,
  ],
  providers: [
    AuthenticationService,
    ConfirmationDialogService,
    LoadingService,
    UserService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },

    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    { provide: ErrorHandler, useClass: GlobalErrorService },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
