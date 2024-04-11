import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })

export class authorService{
    private readonly SERVER_URL = "http://localhost:5066/api/Author";

    constructor(private httpClient: HttpClient) 
  { 

  }

  BuscarAutores()
  {
    return this.httpClient.get<any>(`${this.SERVER_URL}`);
  }

}