import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Debuger } from 'src/app/service/debug.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

const cmp: string = "Delete TestList" 
@Component({
  templateUrl:'/delete-testList.component.html'
})

export class DeleteTestListComponent implements OnInit {
  pageTitle = "Delete Test";
  id: string;
  testList = {
    date: '',
    participant_num: '',
    test_type: ''
  }

  constructor(private router: Router, private _debug: Debuger, private http: HttpClient,
    private activatedRoute: ActivatedRoute, private toastr: ToastrService) {
    this._debug.loadDebuger(cmp, "Constructor", "Created", []);
    
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });
    var promise = this.http.get('api/TestLists/Delete/' + this.id).subscribe(
      (res: any) => {
        if (res != null) {
          this.testList.date = res.date;
          this.testList.participant_num = res.participant_num;
          this.testList.test_type = res.test_type;
          this._debug.loadDebuger(cmp, this.ngOnInit.name, "ngOnInit method call get api", this.testList);
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.ngOnInit.name, "promise unsubscribe", this.testList);
        } else {
          this.toastr.error("No Data Found!");
        }
      }
    );
  }

  onBack() {
    this.router.navigateByUrl('/Coach/TestLists');
  }

  onDelete() {
    var promise = this.http.delete('api/TestLists/Delete/' + this.id).subscribe(
      (res: any) => {
        this.toastr.success("Test List deleted successfully");
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "promise unsubscribe", []);
        this.router.navigateByUrl('/Coach/TestLists');
      }, err => {
        console.log(err);
      }
    );
  }
}
