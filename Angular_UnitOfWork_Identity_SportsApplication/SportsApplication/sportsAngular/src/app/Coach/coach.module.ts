import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { IndexTestListComponent } from './testLists/index/index-testList.component';
import { DeleteTestListComponent } from './testLists/delete/delete-testList.component';
import { CreateTestListComponent } from './testLists/create/create-testList.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: '', component: IndexTestListComponent },
  { path: 'create', component: CreateTestListComponent },
  { path: 'delete/:id', component: DeleteTestListComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule
  ],

  declarations: [
    IndexTestListComponent,
    CreateTestListComponent,
    DeleteTestListComponent
  ]
})

export class CoachModule { }
