import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule, MatButtonModule, MatDatepickerModule, MatFormFieldModule, MatNativeDateModule, MatInputModule, MatOptionModule, MatSelectModule, MatPaginatorModule, MatSortModule } from '@angular/material';
import { IndexTestListComponent } from './TestList/index/index-testList.component';
import { CreateTestListComponent } from './TestList/create/create-testList.component';


const routes: Routes = [
  { path: '', component: IndexTestListComponent },
  { path: 'create', component: CreateTestListComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule,
    MatTableModule, MatButtonModule, MatDatepickerModule, MatNativeDateModule, MatFormFieldModule,
    MatInputModule, MatOptionModule, MatSelectModule, MatPaginatorModule, MatSortModule,
    ReactiveFormsModule
  ],
  declarations: [
    IndexTestListComponent,
    CreateTestListComponent
    //   DeleteTestListComponent
  ],
  providers: [DatePipe, MatDatepickerModule]
})

export class CoachModule { }
