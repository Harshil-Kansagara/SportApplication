import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Account/Login/login.component';
import { PageNotFoundComponent } from './page-not-found.component';
import { RegisterComponent } from './Account/Register/register.component';
import { AuthGuard } from './Auth/auth.guard';
import { IndexAthleteComponent } from './Athlete/index-athlete.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'Coach/TestLists',
    canActivate: [AuthGuard],
    loadChildren: 'src/app/Coach/coach.module#CoachModule'
  },
  {
  path: 'AllAthletes',
    canActivate: [AuthGuard],
      loadChildren: 'src/app/AllAthletes/allAthletes.module#AllAthletesModule'
  },
  {
    path: 'Coach/AthleteByTest/:id',
    canActivate: [AuthGuard],
    loadChildren: 'src/app/AthleteByTest/athleteByTest.module#AthleteByTestModule'
  },
  {
    path: 'Athlete',
    canActivate: [AuthGuard],
    component: IndexAthleteComponent
  },
  { path: 'register', component: RegisterComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
