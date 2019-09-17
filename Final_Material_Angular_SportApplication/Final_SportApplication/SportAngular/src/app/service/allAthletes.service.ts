import { Injectable } from '@angular/core';
import { AthleteList } from '../AllAthletes/Model/Athletes';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })

export class allAthletesService {

  athletes: AthleteList;

  constructor(private http: HttpClient) { }

  getAthleteList() {
    return this.http.get('api/AllAthletes/Index');
  }

  deleteAthlete(id: number) {
    return this.http.delete('api/AllAthletes/Delete/' + id);
  }

  createAthlete(result: string) {
    return this.http.post('api/AllAthletes/Create', JSON.parse('{"AthleteName":"' + result + '"}'));
  }

  initializeAthleteList(): AthleteList {
    return {
      AthleteName: null,
      Id: 0
    };
  }
}
