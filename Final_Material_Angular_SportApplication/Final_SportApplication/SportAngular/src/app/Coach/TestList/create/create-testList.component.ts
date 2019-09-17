import { Component, OnInit } from '@angular/core';
import { TestList } from '../Model/TestList';
import { TestListService } from '../../../service/testList.service';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { Debuger } from '../../../service/debug.service';
import { ToastrService } from 'ngx-toastr';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material';
import { AppDateAdapter, APP_DATE_FORMATS } from './format-datepicker';

const cmp: string = "Create Test"

@Component({
  templateUrl: './create-testList.component.html',
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})
export class CreateTestListComponent implements OnInit {

  pageTitle = "Create Test";
  testList: TestList;
  testType: string[];
  date: string;

  constructor(private tLService: TestListService, private datePipe: DatePipe, private router: Router,
    private _debug: Debuger, private toastr: ToastrService) { }

  ngOnInit() {
    this.testList = this.tLService.initializeTestList();
    console.log(this.testList.Date);
    this.testType = ['Cooper Test', '100 meter sprint'];
  }

  save() {
    //this.date = this.datePipe.transform(this.testList.Date, 'dd-MM-yyyy');
    //console.log(this.date);
    //this.testList.Date = new Date(this.date);
    this.testList.Date = new Date(this.testList.Date);
    console.log(this.testList.Date);
    
    var promise = this.tLService.createTest(this.testList).subscribe(
      (res: any) => {
        this._debug.loadDebuger(cmp, this.save.name, "save post method called", res);
        promise.unsubscribe;
        this._debug.loadDebuger(cmp, this.save.name, "Unsubscribe", res);
        this.toastr.success("Test is created successfully", "Created Test");
        this.router.navigateByUrl('/Coach/TestLists');
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('The test type with same date is already added. Please delete first!', 'Duplicate Test.');
        } else {
          console.log(err);
        }
      }
    );

    console.log(this.testList);

    this.testList = this.tLService.initializeTestList();

  }

  back() {
    this.router.navigateByUrl('/Coach/TestLists');
  }
}
