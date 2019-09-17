import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AthleteData } from '../AthleteByTest/Model/AthleteData';

@Injectable({ providedIn: 'root' })

export class AthleteByTestService {

  athleteData: AthleteData;

  constructor(private http: HttpClient) { }

  getTestDetail(id: number) {
    return this.http.get('api/AthleteByTest/Index/' + id);
  }

  getAthleteList(id: number) {
    return this.http.get('/api/AthleteByTest/Create/' + id);
  }

  getAthleteData(id: number, athleteId: number) {
    return this.http.get('api/AthleteByTest/edit/' + id + "/" + athleteId); 
  }

  createAthleteData(athleteData: AthleteData) {
    return this.http.post('/api/AthleteByTest/Create/', athleteData);
  }

  editAthleteData(athleteData: AthleteData) {
    return this.http.post('api/AthleteByTest/edit/', athleteData);
  }

  deleteAthleteData(id: number) {
    return this.http.delete('api/AthleteByTest/delete/' + id);
  }

  initializedAthleteData(): AthleteData {
    return {
      athleteId: 0,
      testId: 0,
      distance: 0,
      id:0
    }
  }
}
