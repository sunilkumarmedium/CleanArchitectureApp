import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { finalize, first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/_services/authentication/authentication.service';
import { ToastService } from 'src/app/_services/toast/toast.service';

@Component({
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {
  form!: FormGroup;
  loading = false;
  submitted = false;
  injector: any;

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      username: ['', [Validators.required]]
  });
  }

  get formControls()
  {
    return this.form.controls;
  }
  onSubmit(){
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }

    this.authenticationService.forgotPassword(this.formControls.username.value)
            .pipe(first())
            // .pipe(finalize(() => this.loading = false))
            .subscribe({
                next: () => this.injector.get(ToastService).success('Please check your email for password reset instructions'),
                error: (error: any) => this.injector.get(ToastService).danger(error)
            });

  }

}
