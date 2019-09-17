import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import * as jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  pageTitle = 'Sport Application';
  token: string;
  userName: string;
  userRoleId: string;

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      console.log(this.token, " ", "Token is not null");
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
      this.userRoleId = decode_token['UserRoleId'];
      if (this.userRoleId == "d6272412-958c-472d-91d1-d0afd48e7452") {
        console.log("Coach");
        this.router.navigate(['/Coach/TestLists']);
      } else if (this.userRoleId == "36bf775a-621e-4a6d-92b5-5263da58882c") {
        console.log("Athlete");
        this.router.navigateByUrl('Athlete');
      }
    } else {
      console.log("Token is null");
    }
  }

  logOut() {
    localStorage.removeItem('token');
    window.location.href = '/login';
  }
}
