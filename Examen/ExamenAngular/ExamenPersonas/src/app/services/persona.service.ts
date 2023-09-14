import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { IPersonaForCreationDTO } from "../interfaces/persona-for-creation-dto";
import { Observable } from "rxjs";
import { IPersonaGetDTO } from "../interfaces/persona-get-dto";


@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  myAppUrl: string;

  private http: HttpClient;

  constructor(httpClient: HttpClient) {
    this.http = httpClient;
    this.myAppUrl = 'https://localhost:7214/';
  }

  postPersona(personaPost: IPersonaForCreationDTO): Observable<string> {
    return this.http.post<string>(this.myAppUrl + 'api/examen/crearPersona', personaPost);
  }

  getPersonas(): Observable<IPersonaGetDTO[]> {
    return this.http.get<IPersonaGetDTO[]>(this.myAppUrl + 'api/examen/listaPersonas');
  }
}
