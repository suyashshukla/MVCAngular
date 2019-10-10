import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Home } from './Home';

@Injectable()

export class FormService {

  constructor(private http: HttpClient) { }

  contacts;

  formVisibility = false;
  formData: Home;
  url = "/api/data";

  showForm(fData:Home) {
    this.formVisibility = true;
    this.formData = fData;
  }

  closeForm(contact:Home) {
    this.formData = contact;
  }
   
 
  fetchURL() {
      return this.http.get<Home[]>(this.url);
    }

  getURL(id) {
    return this.http.get<Home>(this.url + "/" + id);
  }

  postURL(data) {
    return this.http.post<Home>(this.url,data);
  }

  putURL(data) {
    return this.http.put<Home>(this.url,data);
  }

  deleteURL(data) {
    return this.http.delete(this.url+"/"+data.id);
  }

  getMock() {
    return this.http.get('/assets/mock_contacts.json');
  }

  queryList(query) {
    return this.http.get(this.url + "?query=" + query);
  }
  


}
