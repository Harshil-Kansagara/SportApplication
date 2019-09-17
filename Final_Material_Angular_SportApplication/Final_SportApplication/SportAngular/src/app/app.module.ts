import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './Account/Login/login.component';
import { PageNotFoundComponent } from './page-not-found.component';
import { RegisterComponent } from './Account/Register/register.component';
import { MatInputModule, MatFormFieldModule, MatOptionModule, MatSelectModule, MatButtonModule, MatCheckboxModule, MatDatepickerModule, MatTableModule, MatPaginatorModule, MatSortModule } from '@angular/material'
import { ReactiveFormsModule, FormsModule, FormControl } from '@angular/forms';
import { ConfirmEqualValidatorDirective } from './Shared/confirm-equal-validator.directive';
import { Debuger } from './service/debug.service';
import { AuthInterceptor } from './Auth/auth.interceptor';
import { IndexAthleteComponent } from './Athlete/index-athlete.component';
import { DatePipe } from '@angular/common';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ConfirmEqualValidatorDirective,
    PageNotFoundComponent,
    IndexAthleteComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatInputModule, MatOptionModule, MatSelectModule, MatButtonModule, MatCheckboxModule, MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    AppRoutingModule
  ],
  providers: [Debuger, DatePipe, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
