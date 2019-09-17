import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { ConfirmEqualValidatorDirective } from './shared/confirm-equal-validator.directive';
import { PageNotFoundComponent } from './page-not-found.component';
import { AppRoutingModule } from './app-routing-module';
import { Debuger } from './service/debug.service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthInterceptor } from './Auth/auth.interceptor';
import { CommonModule, DatePipe } from '@angular/common';
import { IndexAthleteComponent } from './Athlete/index-athlete.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    IndexAthleteComponent,
    ConfirmEqualValidatorDirective,
    PageNotFoundComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
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
