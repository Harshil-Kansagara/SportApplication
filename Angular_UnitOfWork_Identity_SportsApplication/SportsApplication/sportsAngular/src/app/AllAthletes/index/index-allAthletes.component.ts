import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Debuger } from 'src/app/service/debug.service';
import * as jwt_decode from 'jwt-decode';

const cmp: string = "Index All Athletes"

@Component({
  templateUrl: './index-allAthletes.component.html'
})

export class IndexAllAthletesComponent implements OnInit {
  pageTitle = "All Athletes of ";
  userName: string;
  token: string;
  allAthleteList: string[] = [];

  constructor(private http: HttpClient, private router: Router, private _debug: Debuger) {
    this._debug.loadDebuger(cmp, "constructor", "created", []);
  }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
    }
    this.pageTitle = this.pageTitle.concat(this.userName);
    this.loadAllAthletesList();
  }

  loadAllAthletesList() {
    var promise = this.http.get('api/AllAthletes/Index').subscribe(
      data => {
        this.allAthleteList = data as string[];
        this._debug.loadDebuger(cmp, this.loadAllAthletesList.name, "Method Called", this.allAthleteList);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadAllAthletesList.name, "unsubscribed", this.allAthleteList);
      }
    )
  }

  onBack() {
    this.router.navigateByUrl('Coach/TestLists');
  }

  createAthlete() {
    this.router.navigateByUrl('AllAthletes/create');
  }
}
