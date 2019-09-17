import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule, MatButtonModule, MatDialogModule, MatInputModule, MatPaginatorModule, MatSortModule } from '@angular/material';
import { IndexAllAthletesComponent, addAthleteDialogComponent } from './index/index-allAthletes.component';

const routes: Routes = [
  { path: '', component: IndexAllAthletesComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule,
    MatTableModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatPaginatorModule,
    MatSortModule
  ],
  declarations: [
    IndexAllAthletesComponent,
    addAthleteDialogComponent
  ],
  entryComponents: [addAthleteDialogComponent]
})

export class AllAthletesModule { }
