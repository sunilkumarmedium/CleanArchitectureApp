import { ManageUserComponent } from './_components/user/manage-user/manage-user.component';
import { HomeComponent } from './_components/home/home.component';
import { UserListComponent } from './_components/user/user-list/user-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_shared/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'users', component: UserListComponent, canActivate: [AuthGuard]},
  { path: 'manageuser', component: ManageUserComponent , canActivate: [AuthGuard]},
  { path: 'manageuser/:id', component: ManageUserComponent , canActivate: [AuthGuard]},
  { path: 'account', loadChildren: () => import('./_components/account/account.module').then(m => m.AccountModule) },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
