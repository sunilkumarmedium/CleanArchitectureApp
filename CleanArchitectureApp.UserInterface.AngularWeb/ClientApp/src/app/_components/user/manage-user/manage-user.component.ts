import { UserService } from '@app/_services/user/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MustMatch } from '@app/_shared/must-match.validator';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../../../_services/authentication/authentication.service';

@Component({
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.css']
})
export class ManageUserComponent implements OnInit {

    form!: FormGroup;
    id!: string;
    isAddMode!: boolean;
    submitted = false;
    loginUser: string | undefined;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit(): void {

    this.id = this.route.snapshot.params.id;
    this.isAddMode = !this.id;
    this.loginUser = this.authenticationService.userValue?.id;
    this.form = this.formBuilder.group({
      userId: this.id,
      userName: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: [''],
      userEmail: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.minLength(6), this.isAddMode ? Validators.required : Validators.nullValidator]],
      confirmPassword: [''],
      userStatus: [''],
      createdBy: this.loginUser,
      updatedBy: this.loginUser
  }, {
      validator: MustMatch('password', 'confirmPassword')
  }
  );

    if (!this.isAddMode) {
    this.userService.getUserById(this.id)
        .pipe(first())
        .subscribe(x => this.form.patchValue(x));
}
  }

  get formControls() { return this.form.controls; }

  private createUser() {
    this.formControls.password.patchValue(btoa(this.formControls.password.value));
    this.formControls.confirmPassword.patchValue(btoa(this.formControls.confirmPassword.value));

    this.userService.createUser(this.form.value)
                    .pipe( first())
                    .subscribe({
                      next: () => {
                        this.router.navigate(['/users'], { relativeTo: this.route });
                      }
                    });
  }

  private updateUser() {
    this.formControls.userStatus.patchValue(Number('1'));
    this.userService.updateUser(this.form.value)
                    .pipe( first())
                    .subscribe({
                      next: () => {
                        this.router.navigate(['/users'], { relativeTo: this.route });
                      }
                    });
  }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
  }

    if (this.isAddMode) {
        this.createUser();
    } else {
        this.updateUser();
    }

  }
}
