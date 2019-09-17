import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IndexAllAthletesComponent } from './index/index-allAthletes.component';
import { CreateAllAthletesComponent } from './create/create-allAthletes.component';
import { DeleteAllAthletesComponent } from './delete/delete-allAthletes.component';


const routes: Routes = [
  { path: '', component: IndexAllAthletesComponent },
  { path: 'create', component: CreateAllAthletesComponent },
  { path: 'delete/:id', component: DeleteAllAthletesComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule
  ],
  declarations: [
    IndexAllAthletesComponent,
    CreateAllAthletesComponent,
    DeleteAllAthletesComponent
  ]
})

export class AllAthletesModule {}
