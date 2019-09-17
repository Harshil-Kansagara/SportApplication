import { Component, OnInit } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import { HttpClient } from '@angular/common/http';
import { Debuger } from 'src/app/service/debug.service';
import { Router } from '@angular/router';

const cmp: string = "TestList";
@Component({
  templateUrl:'./index-testList.component.html'
})

export class IndexTestListComponent implements OnInit {
  pageTitle = "Test List of ";

  token: string;
  userName: string;
  testLists: string[] = [];

  constructor(private http: HttpClient, private _debug: Debuger, private router: Router) {
    this._debug.loadDebuger(cmp, "constructor", "created", []);
  }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
    }
    this.pageTitle = this.pageTitle.concat(this.userName);
    this.loadTestLists();
  }

  loadTestLists() {
    var promise = this.http.get('api/TestLists/Index').subscribe(
      data => {
        this.testLists = data as string[];
        this._debug.loadDebuger(cmp, this.loadTestLists.name, "Method Called", this.testLists);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadTestLists.name, "unsubscribed", this.testLists);
      }
    )
  }

  createTest() {
    this.router.navigateByUrl('Coach/TestLists/create');
  }

  viewAllAthletes() {
    this.router.navigateByUrl('AllAthletes');
  }

  viewAthleteByTest(id:string) {
    this.router.navigateByUrl('Coach/AthleteByTest/' + id);
  }
}
