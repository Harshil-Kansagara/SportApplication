import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IndexAthleteByTestComponent } from './index/index-athleteByTest.component';
import { CreateAthleteByTestComponent } from './create/create-athleteByTest.component';
import { EditAthleteByTestComponent } from './edit/edit-athleteByTest.component';

const routes: Routes = [
  { path: '', component: IndexAthleteByTestComponent },
  { path: 'create', component: CreateAthleteByTestComponent },
  { path: 'edit/:athleteId', component: EditAthleteByTestComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    FormsModule,
    CommonModule
  ],
  declarations: [
    IndexAthleteByTestComponent,
    CreateAthleteByTestComponent,
    EditAthleteByTestComponent
  ]
})

export class AthleteByTestModule { }
