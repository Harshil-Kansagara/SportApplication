import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { MatButtonModule, MatTableModule, MatFormFieldModule, MatSelectModule, MatOptionModule, MatInputModule, MatPaginatorModule, MatSortModule } from '@angular/material';
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
    CommonModule,
    MatButtonModule, MatTableModule, MatFormFieldModule,
    MatInputModule, MatOptionModule, MatSelectModule, MatPaginatorModule, MatSortModule,
    ReactiveFormsModule
  ],
  declarations: [
    IndexAthleteByTestComponent,
    CreateAthleteByTestComponent,
    EditAthleteByTestComponent
  ],
  providers: [DatePipe]
})

export class AthleteByTestModule { }
