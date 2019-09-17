import { Component, OnInit } from '@angular/core';
import { Debuger } from '../service/debug.service';
import { HttpClient } from '@angular/common/http';
import * as jwt_decode from 'jwt-decode';

const cmp: string = "Athlete Index";

@Component({
  templateUrl: './index-athlete.component.html'
})

export class IndexAthleteComponent implements OnInit {
  pageTitle = "Detail of ";
  token: string;
  userName: string;
  userRoleId: string;
  athleteDetails: string[] = [];

  constructor(private _debug: Debuger, private http: HttpClient) {
    this._debug.loadDebuger(cmp,"Constructor", "created",[])
  }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      console.log(this.token, " ", "Token is not null");
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
      this.pageTitle = this.pageTitle.concat(this.userName);
    } else {
      console.log("Token is null");
    }

    this.loadAthleteData();
  }

  loadAthleteData() {
    var promise = this.http.get('api/AthleteDetails/Index').subscribe(
      (res: any) => {
        this.athleteDetails = res as string[];
        this._debug.loadDebuger(cmp, this.loadAthleteData.name, "Get method called", this.athleteDetails);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadAthleteData.name, "unsubscribed", this.athleteDetails)
      }, err => {
        console.log(err);
      }
    );
  }
}
