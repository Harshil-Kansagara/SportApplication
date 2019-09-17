import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { TestList } from '../Coach/TestList/Model/TestList';
import { getLocaleDateTimeFormat } from '@angular/common';

@Injectable({ providedIn: 'root' })
export class TestListService{

  testList: TestList;

  constructor(private http: HttpClient) { }

  getTestList() {
    return this.http.get('api/TestLists/Index');
  }

  createTest(testList: TestList) {
    return this.http.post('api/TestLists/Create', testList);
  }

  deleteTest(id: number) {
    return this.http.delete('api/TestLists/delete/' + id);
  }

  initializeTestList(): TestList {
    return {
      Date: null,
      ParticipantNumber: 0,
      TestType: null,
      Id:0
    };
  }


}
