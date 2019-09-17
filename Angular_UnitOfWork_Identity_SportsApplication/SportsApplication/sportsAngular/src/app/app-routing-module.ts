import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { PageNotFoundComponent } from './page-not-found.component';
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
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: '**', component: PageNotFoundComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
